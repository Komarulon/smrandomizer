using System.Collections.Generic;
using System.IO;
using System.Linq;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer.Random
{
    public enum RandomizerDifficulty
    {
        Speedrunner,
    }

    public class RandomizerV11
    {
        private static SeedRandom random;
        private List<ItemType> haveItems;
        private List<ItemType> itemPool;
        private readonly int seed;
        private readonly IRomLocations romLocations;
        private readonly RandomizerLog log;
        private readonly byte[] unheaderedRomBytes;

        public RandomizerV11(byte[] unheaderedRomBytes, int seed, IRomLocations romLocations, RandomizerLog log)
        {
            random = new SeedRandom(seed);
            this.unheaderedRomBytes = unheaderedRomBytes;
            this.romLocations = romLocations;
            this.seed = seed;
            this.log = log;
        }

        public string CreateRom(string filename, RandomizerOptions randomizerOptions, bool spoilerOnly = false)
        {
            if (filename.Contains("\\") && !Directory.Exists(filename.Substring(0, filename.LastIndexOf('\\'))))
            {
                Directory.CreateDirectory(filename.Substring(0, filename.LastIndexOf('\\')));
            }

            GenerateItemList();
            GenerateItemPositions(randomizerOptions);

            // TODO: why is WriteRom called twice?
            WriteRom(filename, randomizerOptions);

            if (spoilerOnly)
            {
                return log?.GetLogOutput();
            }

            WriteRom(filename, randomizerOptions);

            return "";
        }

        private void WriteRom(string filename, RandomizerOptions randomizerOptions)
        {
            string usedFilename = FileName.Fix(filename, string.Format(romLocations.SeedFileString, seed));


            using (var rom = new FileStream(usedFilename, FileMode.OpenOrCreate))
            {
                // Overwrite the entire file with the redesign rom:
                //rom.Write(Resources.Super_Metroid___Redesign_v2_1_FINAL, 0, 4194304);

                // 4194304 is the size of the Redesign rom, not the vanilla rom
                byte[] superMetroidRomCopy = new byte[4194304];
                this.unheaderedRomBytes.CopyTo(superMetroidRomCopy, 0);
                using (var unheaderedVanillaRomStream = new MemoryStream(superMetroidRomCopy))
                {
                    IpsPatcher.PatchIps(unheaderedVanillaRomStream, Resources.Super_Metroid_Unheadered_to_Redesign_v2_1_FINAL);
                    unheaderedVanillaRomStream.Seek(0, SeekOrigin.Begin);
                    rom.Write(unheaderedVanillaRomStream.ToArray(), 0, 4194304);
                }


                IpsPatcher.PatchIps(rom, Resources.Redesign_Final_to_Redesign_Rando_From_Past);
                if (randomizerOptions.cycleSaves)
                {
                    IpsPatcher.PatchIps(rom, Resources.Redesign_Rando_From_Past_to_Rando_with_Rotating_Saves);
                }

                foreach (var location in romLocations.Locations)
                {
                    rom.Seek(location.Address, SeekOrigin.Begin);
                    var newItem = new byte[2];

                    switch (location.ItemStorageType)
                    {
                        case ItemStorageType.Normal:
                            newItem = StringToByteArray(location.Item.Normal);
                            break;
                        case ItemStorageType.Hidden:
                            newItem = StringToByteArray(location.Item.Hidden);
                            break;
                        case ItemStorageType.Chozo:
                            newItem = StringToByteArray(location.Item.Chozo);
                            break;
                    }

                    rom.Write(newItem, 0, 2);

                    if (location.Item.Type == ItemType.Nothing)
                    {
                        // give same index as morph ball
                        rom.Seek(location.Address + 4, SeekOrigin.Begin);
                        rom.Write(StringToByteArray("\x1a"), 0, 1);
                    }
                }

                WriteSeedInRom(rom);

                if (randomizerOptions.fastFanfares)
                {
                    IpsPatcher.PatchIps(rom, Resources.ShortMessageBoxesVer3);
                }

                if (randomizerOptions.preventCommonSoftlocks)
                {
                    IpsPatcher.PatchIps(rom, Resources.Redesign_Unlocked_Softlock_Prevention);
                }

                rom.Close();
            }

            if (log != null)
            {
                log.WriteLog(usedFilename);
            }
        }

        private void WriteSeedInRom(FileStream rom)
        {
            string seedStr = string.Format(romLocations.SeedRomString, RandomizerVersion.Current, seed.ToString().PadLeft(7, '0')).PadRight(21).Substring(0, 21);
            rom.Seek(0x7fc0, SeekOrigin.Begin);
            rom.Write(StringToByteArray(seedStr), 0, 21);
        }

        private static byte[] StringToByteArray(string input)
        {
            var retVal = new byte[input.Length];
            var i = 0;

            foreach (var ch in input)
            {
                retVal[i] = (byte)ch;
                i++;
            }

            return retVal;
        }

        private void GenerateItemPositions(RandomizerOptions randomizerOptions)
        {
            do
            {
                var currentLocations = romLocations.GetAvailableLocations(haveItems);
                var candidateItemList = new List<ItemType>();

                // Generate candidate item list
                foreach (var candidateItem in itemPool)
                {
                    haveItems.Add(candidateItem);

                    var newLocations = romLocations.GetAvailableLocations(haveItems);

                    if (newLocations.Count > currentLocations.Count)
                    {
                        romLocations.TryInsertCandidateItem(currentLocations, candidateItemList, candidateItem);
                    }

                    haveItems.Remove(candidateItem);
                }

                // Grab an item from the candidate list if there are any, otherwise, grab a random item
                if (candidateItemList.Count > 0)
                {
                    // Please give bombs early
                    if (randomizerOptions.earlierBombs && candidateItemList.Contains(ItemType.Bomb))
                    {
                        candidateItemList.Add(ItemType.Bomb);
                        candidateItemList.Add(ItemType.Bomb);
                    }

                    var insertedItem = candidateItemList[random.Next(candidateItemList.Count)];

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
                    currentLocations[insertedLocation].Item = new Item(insertedItem);

                    if (log != null)
                    {
                        log.AddOrderedItem(currentLocations[insertedLocation]);
                    }
                }
                else
                {
                    ItemType insertedItem = romLocations.GetInsertedItem(currentLocations, itemPool, random);

                    itemPool.Remove(insertedItem);
                    haveItems.Add(insertedItem);

                    int insertedLocation = romLocations.GetInsertedLocation(currentLocations, insertedItem, random);
                    currentLocations[insertedLocation].Item = new Item(insertedItem);
                }
            } while (itemPool.Count > 0);

            var unavailableLocations = romLocations.GetUnavailableLocations(haveItems);

            foreach (var unavailableLocation in unavailableLocations)
            {
                unavailableLocation.Item = new Item(ItemType.Nothing);
            }


            if (log != null)
            {
                log.AddGeneratedItems(romLocations.Locations);
            }
        }

        private void GenerateItemList()
        {
            romLocations.ResetLocations();
            haveItems = new List<ItemType>();
            itemPool = romLocations.GetItemPool(random);
            var unavailableLocations = romLocations.GetUnavailableLocations(itemPool);

            for (int i = itemPool.Count; i < 100 - unavailableLocations.Count; i++)
            {
                itemPool.Add(ItemType.Nothing);
            }
        }
    }
}
