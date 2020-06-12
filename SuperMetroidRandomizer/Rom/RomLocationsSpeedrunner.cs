using System;
using System.Collections.Generic;
using System.Linq;
using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsSpeedrunner : IRomLocations
    {
        public List<Location> Locations { get; set; }
        public string DifficultyName { get { return "Speedrunner"; } }
        public string SeedFileString { get { return "S{0:0000000}"; } }
        public string SeedRomString { get { return "SMRv{0} S{1}"; } }

        public void ResetLocations()
        {
            Locations = new List<Location>
                       {
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Landing Site)",
                                   Address = 0x7FC36,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Bomb Torizo)",
                                   Address = 0x7C889,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && (CanDestroyBombWalls(have)
                                            || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Parlor)",
                                   Address = 0x78060,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Parlor)",
                                   Address = 0x7806C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanPassBombPassages(have)
                                       && CanJumpHigh(have)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Parlor)",
                                   Address = 0x780C0,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Parlor, tsundere)",
                                   Address = 0x78090,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Parlor, blue gate)",
                                   Address = 0x78096,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.WaveBeam)
                                       && have.Contains(ItemType.MorphingBall)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (East Crateria Chain)",
                                   Address = 0x78106,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && have.Contains(ItemType.SpeedBooster)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Lost Caverns)",
                                   Address = 0x7EE5B,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Lost Caverns)",
                                   Address = 0x7EE61,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (East Crateria Guardian)",
                                   Address = 0x7FA10,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.WaveBeam)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Gravity Suit",
                                   Address = 0x7FB88,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Energy Tank (Crateria green gates)",
                                   Address = 0x7FB50,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                                       && (CanFly(have)
                                            || have.Contains(ItemType.HiJumpBoots)
                                                && have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria Depths super ceiling)",
                                   Address = 0x7F0EA,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                                       && (CanFly (have)
                                            || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria map)",
                                   Address = 0x78280,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria awakening)",
                                   Address = 0x783EE,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && (CanPassBombPassages(have)
                                            || (have.Contains(ItemType.MorphingBall)
                                                && have.Contains(ItemType.SpeedBooster))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria courtyard tunnel)",
                                   Address = 0x7EEF2,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && (CanFly(have) || CanJumpHigh(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Bomb",
                                   Address = 0x7812C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && ((CanDbj(have)
                                            && (CanDestroyBombWalls(have)
                                                || have.Contains(ItemType.WaveBeam)))
                                            || have.Contains(ItemType.SpeedBooster)
                                            || have.Contains(ItemType.GravitySuit)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Purple Crateria lower depths access)",
                                   Address = 0x7FC68,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && (CanFly(have) || CanJumpHigh(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Reserve Tank (Crateria)",
                                   Address = 0x7EFA7,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria Depths entrance)",
                                   Address = 0x7FBDB,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && (CanPassBombPassages(have)
                                            && have.Contains(ItemType.SpeedBooster)
                                            && (CanFly(have) || CanJumpHigh(have)))
                                           || (CanAccessEastCrateria(have)
                                                && CanOpenPurpleDoors(have)
                                                && have.Contains(ItemType.GrappleBeam)
                                                && (have.Contains(ItemType.GravitySuit)
                                                    || have.Contains(ItemType.SpaceJump))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (West Crateria chain)",
                                   Address = 0x79B88,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Purple Crateria bat cave)",
                                   Address = 0x7F08B,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanPassBombPassages(have)
                                       && (CanFly(have)
                                            || (CanJumpHigh(have)
                                                && have.Contains(ItemType.IceBeam))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Purple Crateria one-shot spark)",
                                   Address = 0x7F0A3,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (CanFly(have) || CanJumpHigh(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Spazer",
                                   Address = 0x781EE,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Spazer)",
                                   Address = 0x781E8,
                                   CanAccess =
                                       have =>
                                       CanDbj(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria west of landing site)",
                                   Address = 0x780D4,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && CanIbj(have)
                                       && ((have.Contains(ItemType.SpeedBooster)
                                            && have.Contains(ItemType.HiJumpBoots))
                                            || have.Contains(ItemType.SpaceJump)
                                            || have.Contains(ItemType.IceBeam)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria west of landing site)",
                                   Address = 0x780E6,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanDestroyBombWalls(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (Brinstar-Crateria elevator)",
                                   Address = 0x7EBDC,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar bat cave)",
                                   Address = 0x7EC30,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && (CanFly(have)
                                            || have.Contains(ItemType.SpeedBooster))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (West Brinstar Guardian left)",
                                   Address = 0x7EC3C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanDefeatKraid(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (West Brinstar Guardian right)",
                                   Address = 0x7EC36,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanDefeatKraid(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar-Crateria elevator)",
                                   Address = 0x7EC0C,
                                   CanAccess =
                                       have =>
                                       CanDbj(have)
                                       && CanPassBombPassages(have)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (Brinstar spikes)",
                                   Address = 0x784E4,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar Diagon Alley)",
                                   Address = 0x787D0,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && have.Contains(ItemType.SpeedBooster)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (West Brinstar Guardian)",
                                   Address = 0x7852C,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanDefeatKraid(have)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Wall-Jump Boots",
                                   Address = 0x7EAB6,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar Dachora access)",
                                   Address = 0x78582,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Charge Beam",
                                   Address = 0x7896E,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (Charge)",
                                   Address = 0x7865C,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (Spore Spawn)",
                                   Address = 0x7EBA8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria awakening)",
                                   Address = 0x78784,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && (CanIbj(have)
                                            || have.Contains(ItemType.HiJumpBoots)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar junction)",
                                   Address = 0x787B6,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && (CanPassBombPassages(have)
                                            || (have.Contains(ItemType.SpaceJump)
                                                && have.Contains(ItemType.ScrewAttack)))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (Brinstar Diagon Alley)",
                                   Address = 0x78576,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar-Norfair tube)",
                                   Address = 0x7FF43,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && CanUsePowerBombs(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                            || (CanAccessVariaSuit(have)
                                                && ((have.Contains(ItemType.VariaSuit)
                                                    && (have.Contains(ItemType.GrappleBeam)
                                                        || have.Contains(ItemType.SpaceJump)
                                                        || EnergyReserveCount(have) >= 3))
                                                    || (EnergyReserveCount(have) >= 3
                                                        && (have.Contains(ItemType.GrappleBeam)
                                                            || have.Contains(ItemType.SpaceJump)))))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Brinstar fish tank)",
                                   Address = 0x787FA,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.MorphingBall)
                                       && CanDestroyBombWalls(have)
                                       && (have.Contains(ItemType.IceBeam)
                                            || (CanFly(have)
                                                && have.Contains(ItemType.GravitySuit))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (first)",
                                   Address = 0x7FC7C,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria first missile)",
                                   Address = 0x7FC70,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Brinstar small sidehopper alley)",
                                   Address = 0x78824,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Hi-Jump Boots",
                                   ItemStorageType = ItemStorageType.Chozo,
                                   Address = 0x7EA48,
                                   CanAccess =
                                       have =>
                                       CanOpenPurpleDoors(have)
                                       && CanPassBombPassages(have)
                                       && (have.Contains(ItemType.GrappleBeam)
                                            || (have.Contains(ItemType.GravitySuit)
                                                && CanFly(have))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Hi-Jump)",
                                   Address = 0x784BE,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && have.Contains(ItemType.MorphingBall),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (Warehouse top)",
                                   Address = 0x7BD99,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "X-Ray Scope",
                                   Address = 0x78876,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Red Brinstar Samus eaters)",
                                   Address = 0x7889E,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && CanDbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Red Brinstar land guardian)",
                                   Address = 0x78898,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && CanUsePowerBombs(have)
                                       && CanDbj(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Power Bomb (Red Brinstar top entrance)",
                                   Address = 0x78BE2,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && CanUsePowerBombs(have)
                                       && (have.Contains(ItemType.SpaceJump)
                                            || (have.Contains(ItemType.HiJumpBoots)
                                                && have.Contains(ItemType.SpeedBooster))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Red Brinstar underwater)",
                                   Address = 0x7FC8A,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Red Brinstar zebbos)",
                                   Address = 0x7899C,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Super Missile (Warehouse entrance)",
                                   Address = 0x789BC,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have)
                                       && (CanDefeatKraid(have)
                                       || (have.Contains(ItemType.SuperMissile)
                                            && CanUsePowerBombs(have))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Missile (Warehouse entrance)",
                                   Address = 0x789A4,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Reserve Tank (Brinstar)",
                                   Address = 0x78A74,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Varia Suit",
                                   Address = 0x7FDD8,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessVariaSuit(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (Lower Norfair entrance)",
                                   Address = 0x7B9FD,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                            || have.Contains(ItemType.HiJumpBoots))
                                                && CanFly(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Ice Beam",
                                   Address = 0x78B24,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Ridley gate shaft)",
                                   Address = 0x78F5C,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Speed Booster",
                                   Address = 0x782B2,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Norfair sine room)",
                                   Address = 0x78BCE,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && CanUsePowerBombs(have)
                                       && CanOpenPurpleDoors(have)
                                       && have.Contains(ItemType.GravitySuit),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Super Missile (Crocomire)",
                                   Address = 0x78344,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanPassBombPassages(have)
                                       && (CanFly(have)
                                            || CanJumpHigh(have)
                                            || (have.Contains(ItemType.IceBeam)
                                                && have.Contains(ItemType.ChargeBeam))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Crocomire)",
                                   Address = 0x78C04,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanDbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Lower Norfair top)",
                                   Address = 0x7D944,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Lower Norfair shinespark)",
                                   Address = 0x7BD19,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Grapple)",
                                   Address = 0x7EA40,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanEscapeGrappleGauntlet(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                            || EnergyReserveCount(have) >= 1),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Grapple)",
                                   Address = 0x7EA3A,
                                   CanAccess =
                                       have =>
                                       CanEscapeGrappleGauntlet(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Grapple)",
                                   Address = 0x79108,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanEscapeGrappleGauntlet(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Grappling Beam",
                                   Address = 0x7E9E2,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanEscapeGrappleGauntlet(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (West Norfair sanctum, hidden)",
                                   Address = 0x7F258,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (have.Contains(ItemType.IceBeam)
                                            || have.Contains(ItemType.GravitySuit)
                                            || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (West Norfair sanctum)",
                                   Address = 0x7F252,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Super Missile (West Norfair sanctum)",
                                   Address = 0x7C240,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (West Norfair sanctum, chozo)",
                                   Address = 0x7C2EF,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (have.Contains(ItemType.GrappleBeam)
                                            || have.Contains(ItemType.SpaceJump)
                                            || have.Contains(ItemType.ScrewAttack))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (East Norfair Guardian)",
                                   Address = 0x7F3E7,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanEscapeGrappleGauntlet(have)
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair-Brinstar tube lava)",
                                   Address = 0x78BC0,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                            || EnergyReserveCount(have) >= 1),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Bob Jr.)",
                                   Address = 0x78C9C,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && have.Contains(ItemType.VariaSuit)
                                       && CanUsePowerBombs(have)
                                       && ((have.Contains(ItemType.GravitySuit)
                                            && CanDefeatKraid(have))
                                           || (CanOpenPurpleDoors(have)
                                               && (have.Contains(ItemType.GrappleBeam)
                                               || have.Contains(ItemType.SpaceJump))))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (East Norfair Alcoon hideout)",
                                   Address = 0x78CA8,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && have.Contains(ItemType.VariaSuit)
                                       && CanUsePowerBombs(have)
                                       && ((have.Contains(ItemType.GravitySuit)
                                            && CanDefeatKraid(have))
                                           || (CanOpenPurpleDoors(have)
                                               && (have.Contains(ItemType.GrappleBeam)
                                               || have.Contains(ItemType.SpaceJump))))
                                       && (CanIbj(have)
                                            || (have.Contains(ItemType.WaveBeam)
                                                && (CanFly(have)
                                                    || (have.Contains(ItemType.HiJumpBoots)
                                                        && have.Contains(ItemType.SpeedBooster)
                                                        && have.Contains(ItemType.IceBeam)))))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Wave Beam",
                                   Address = 0x78CCA,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                            || CanFly(have))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Pantry)",
                                   Address = 0x78CDA,
                                   CanAccess =
                                       have =>
                                       CanDefeatKraid(have)
                                       && have.Contains(ItemType.VariaSuit)
                                       && CanUsePowerBombs(have)
                                       && ((have.Contains(ItemType.GravitySuit)
                                            && CanDefeatKraid(have))
                                           || (CanOpenPurpleDoors(have)
                                               && (have.Contains(ItemType.GrappleBeam)
                                               || have.Contains(ItemType.SpaceJump))))
                                       && (CanFly(have)
                                           || have.Contains(ItemType.SpeedBooster))
                                       && (have.Contains(ItemType.SpaceJump)
                                           || (have.Contains(ItemType.HiJumpBoots)
                                               && have.Contains(ItemType.ScrewAttack)))
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Bob Jr. underpass)",
                                   Address = 0x78CF2,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanUsePowerBombs(have)
                                       && CanDbj(have)
                                       && ((have.Contains(ItemType.GravitySuit)
                                            && CanDefeatKraid(have))
                                           || (CanOpenPurpleDoors(have)
                                               && (have.Contains(ItemType.GrappleBeam)
                                               || have.Contains(ItemType.SpaceJump)))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (Lower Norfair violas)",
                                   Address = 0x78D24,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (East Norfair maze)",
                                   Address = 0x78D24,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have)
                                       && CanDbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (Norfair-Brinstar elevator)",
                                   Address = 0x78E36,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                           || EnergyReserveCount(have) >= 3),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Power Bomb (Golden Torizo)",
                                   ItemStorageType = ItemStorageType.Hidden,
                                   Address = 0x78E50,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && CanDefeatRidley(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Ridley gate room)",
                                   Address = 0x78EDC,
                                   CanAccess =
                                       have =>
                                       CanDefeatRidley(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Plasma Beam",
                                   Address = 0x7BD3F,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatRidley(have)
                                       && have.Contains(ItemType.GravitySuit),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Lower Norfair puromi hall)",
                                   Address = 0x7BD39,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Super Missile (Lower Norfair holtz tease)",
                                   Address = 0x7B5B6,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessLowerNorfair(have)
                                       && (CanSbj(have) || CanIbj(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Screw Attack",
                                   Address = 0x78CB0,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have)
                                       && (have.Contains(ItemType.SpeedBooster)
                                            || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Missile (Lower Norfair desgeega boost room)",
                                   Address = 0x79036,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatRidley(have)
                                       && (have.Contains(ItemType.GravitySuit)
                                            || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.LowerNorfair,
                                   Name = "Energy Tank (Ridley)",
                                   Address = 0x79108,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatRidley(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (East Norfair Indiana Jones)",
                                   Address = 0x7B9E3,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Super Missile (East Norfair Guardian)",
                                   Address = 0x7B9EF,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have)
                                       && CanJumpHigh(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (Crateria east courtyard)",
                                   Address = 0x7F987,
                                   CanAccess =
                                       have =>
                                       CanUsePowerBombs(have)
                                       && CanOpenMissileDoors(have)
                                       && (CanFly(have)
                                            || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (East Crateria green doors)",
                                   Address = 0x7F9EE,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && CanPassBombPassages(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (East Crateria buried treasure)",
                                   Address = 0x7FAA0,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessCrateriaDepths(have)
                                       && have.Contains(ItemType.WaveBeam)
                                       && CanDestroyBombWalls(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Reserve Tank (Norfair)",
                                   Address = 0x78C7A,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanUsePowerBombs(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.GravitySuit)
                                       && CanFly(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Power Bomb (East Crateria maze)",
                                   Address = 0x7FE47,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && CanPassBombPassages(have)
                                       && CanUsePowerBombs(have)
                                       && CanSbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Crateria,
                                   Name = "Morphing Ball",
                                   Address = 0x7C2BF,
                                   CanAccess =
                                       have =>
                                       true,
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (West Norfair morph lock)",
                                   Address = 0x7815A,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanSbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (Maridia-Brinstar tube)",
                                   Address = 0x7FD98,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (Maridia speedball)",
                                   Address = 0x7D903,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have)
                                       && CanFly(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (West Maridia sandfall)",
                                   Address = 0x79020,
                                   CanAccess =
                                        have =>
                                        // Needed to get to the location where the item is:
                                        CanAccessMaridia(have)
                                        && ((CanUsePowerBombs(have)
                                            || have.Contains(ItemType.GrappleBeam)
                                            || have.Contains(ItemType.SpaceJump))) 

                                            // To make the jump across the gap you need either Hi-Jump + Space, or Screw
                                        && ((have.Contains(ItemType.HiJumpBoots) && have.Contains(ItemType.SpaceJump))
                                            || have.Contains(ItemType.ScrewAttack)

                                            // ... you could chain it across and shinespark up ... ( ͡° ͜ʖ ͡°)
                                            // || (have.Contains(ItemType.SpeedBooster) && have.Contains(ItemType.SpaceJump)) 
                                            )
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Maridia Ridley tube)",
                                   Address = 0x7C47D,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && CanDefeatRidley(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon sandfall)",
                                   Address = 0x7CF39,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Draygon sandfall access)",
                                   Address = 0x7F7DE,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (East Maridia NEStroid item room)",
                                   Address = 0x7F7FC,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have)
                                       || (CanLeaveCentralMaridia(have)
                                            && have.Contains(ItemType.Bomb)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (West Maridia chain)",
                                   ItemStorageType = ItemStorageType.Chozo,
                                   Address = 0x7C4BD,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && (have.Contains(ItemType.SpaceJump)
                                            || (CanDefeatDraygon(have)
                                                && CanDbj(have))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia-Brinstar tube)",
                                   Address = 0x7C4F5,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && CanUsePowerBombs(have)
                                       && (CanFly(have) || CanJumpHigh(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Botwoon sandfall)",
                                   Address = 0x7C3F5,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && have.Contains(ItemType.SpaceJump),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia sandcanyon)",
                                   Address = 0x7FDCA,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && (CanLeaveCentralMaridia(have)
                                            || have.Contains(ItemType.GrappleBeam)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Reserve Tank (Maridia)",
                                   Address = 0x7FDAC,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (West Maridia chain)",
                                   Address = 0x7902E,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster)
                                       && have.Contains(ItemType.HiJumpBoots),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (West Maridia ramps)",
                                   Address = 0x7C4DD,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && CanDbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (West Maridia sandpit left)",
                                   Address = 0x7C4A9,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (West Maridia sandpit right)",
                                   Address = 0x7C4AF,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (West Maridia sandpit)",
                                   Address = 0x7C4B5,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Botwoon)",
                                   ItemStorageType = ItemStorageType.Chozo,
                                   Address = 0x7F63B,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && CanPassBombPassages(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (West Maridia chain)",
                                   Address = 0x7FF6F,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (West Maridia red gates)",
                                   Address = 0x7FF7B,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Power Bomb (West Maridia gate hall)",
                                   Address = 0x7C603,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have)
                                       && have.Contains(ItemType.Bomb),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (Maridia uterus room)",
                                   Address = 0x7BDF9,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessMaridia(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (East Maridia shinespark)",
                                   Address = 0x7D599,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Energy Tank (Draygon sandfall)",
                                   Address = 0x7D585,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       (CanAccessEastMaridia(have)
                                       && (CanFly(have) || have.Contains(ItemType.SpeedBooster))
                                       && CanPassBombPassages(have))
                                       || (CanLeaveCentralMaridia(have)
                                            && have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (East Maridia chain)",
                                   Address = 0x7D571,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SpeedBooster)
                                       && CanFly(have)
                                       && CanDbj(have)
                                       && (CanLeaveCentralMaridia(have)
                                            || CanAccessEastMaridia(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (East Maridia mocktroid cave)",
                                   Address = 0x7C5C1,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have)
                                       && (CanFly(have)
                                            || (CanJumpHigh(have)
                                                || have.Contains(ItemType.SpeedBooster))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (East Maridia mocktroid hall)",
                                   Address = 0x7D53D,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have)
                                       && (CanFly(have) || CanJumpHigh(have))
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Super Missile (East Maridia Draygon lock)",
                                   Address = 0x7D7C2,
                                   CanAccess =
                                       have =>
                                       CanDefeatDraygon(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (East Maridia shaft ceiling)",
                                   Address = 0x7D50B,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have)
                                       && (CanFly(have) || CanJumpHigh(have)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Missile (East Maridia top)",
                                   Address = 0x7C6C9,
                                   CanAccess =
                                       have =>
                                       CanAccessEastMaridia(have)
                                       && CanFly(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Beam Combo",
                                   Address = 0x7C791,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanLeaveCentralMaridia(have)
                                       && (CanFly(have) || (CanPassBombPassages(have)
                                                            && CanJumpHigh(have)))
                                       && (CanDefeatDraygon(have) && have.Contains(ItemType.Bomb)
                                            || (have.Contains(ItemType.ChargeBeam)
                                            && have.Contains(ItemType.WaveBeam))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Maridia,
                                   Name = "Space Jump",
                                   Address = 0x7FDFE,
                                   ItemStorageType = ItemStorageType.Chozo,
                                   CanAccess =
                                       have =>
                                       CanDefeatBotwoon(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Magmoor Tunnel)",
                                   Address = 0x78E04,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanPassBombPassages(have)
                                       && CanAccessLowerNorfair(have)
                                       && have.Contains(ItemType.SpeedBooster),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (Magmoor Tunnel)",
                                   Address = 0x78E0A,
                                   CanAccess =
                                       have =>
                                       CanAccessNorfair(have)
                                       && CanPassBombPassages(have)
                                       && CanDbj(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Power Bomb (Early PB maze)",
                                   Address = 0x78044,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && (have.Contains(ItemType.WaveBeam)
                                            || have.Contains(ItemType.ChargeBeam))
                                       && (have.Contains(ItemType.Bomb)
                                            || have.Contains(ItemType.SpaceJump)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Missile (West Norfair Ridley face)",
                                   Address = 0x78D0C,
                                   CanAccess =
                                       have =>
                                       CanAccessWestNorfair(have)
                                       && CanUsePowerBombs(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = true,
                                   Region = Region.Norfair,
                                   Name = "Energy Tank (East Norfair cavern storage)",
                                   ItemStorageType = ItemStorageType.Chozo,
                                   Address = 0x7B725,
                                   CanAccess =
                                       have =>
                                       CanAccessEastNorfair(have)
                                       && (have.Contains(ItemType.GrappleBeam)
                                            || have.Contains(ItemType.SpaceJump)
                                            || (have.Contains(ItemType.ScrewAttack)
                                                && have.Contains(ItemType.HiJumpBoots))
                                            || (have.Contains(ItemType.GravitySuit)
                                                && CanIbj(have))),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Super Missile (Crateria west courtyard)",
                                   Address = 0x7F950,
                                   CanAccess =
                                       have =>
                                       have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have)
                                       && (CanFly(have) || CanJumpHigh(have))
                                       && CanPassBombPassages(have)
                                       && CanOpenPurpleDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (Crateria west courtyard)",
                                   Address = 0x7F94A,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && (CanFly(have) || have.Contains(ItemType.SpeedBooster)),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Brinstar,
                                   Name = "Energy Tank (Brinstar bat cave)",
                                   Address = 0x7EBEE,
                                   CanAccess =
                                       have =>
                                       CanOpenMissileDoors(have),
                               },
                           new Location
                               {
                                   NoHidden = true,
                                   GravityOkay = false,
                                   Region = Region.Crateria,
                                   Name = "Missile (East Crateria wall)",
                                   Address = 0x7FE53,
                                   ItemStorageType = ItemStorageType.Hidden,
                                   CanAccess =
                                       have =>
                                       CanAccessEastCrateria(have)
                                       && have.Contains(ItemType.SuperMissile)
                                       && CanOpenMissileDoors(have),
                               },
                       };
        }

        private static bool CanAccessEastCrateria(List<ItemType> have)
        {
            return CanOpenMissileDoors(have)
                && (CanFly(have)
                    || have.Contains(ItemType.SpeedBooster)
                    || (CanPassBombPassages(have)
                        && CanDbj(have)));
        }

        private static bool CanAccessCrateriaDepths(List<ItemType> have)
        {
            return CanAccessEastCrateria(have)
                && have.Contains(ItemType.SuperMissile)
                && have.Contains(ItemType.GravitySuit)
                && (CanFly(have) || CanJumpHigh(have))
                && (CanFly(have)
                    || have.Contains(ItemType.SpeedBooster)
                    || CanOpenPurpleDoors(have))
                && (have.Contains(ItemType.SpeedBooster)
                    || (have.Contains(ItemType.GrappleBeam)
                        && CanOpenPurpleDoors(have)));
        }

        private static bool CanOpenPurpleDoors(List<ItemType> have)
        {
            return MissileSuperCount(have) >= 5;
        }

        private static int MissileSuperCount(List<ItemType> have)
        {
            var missileCount = have.Count(x => x == ItemType.Missile);
            var superCount = Math.Min(have.Count(x => x == ItemType.SuperMissile), missileCount + 1);
            return missileCount + superCount;
        }

        private static bool CanDefeatRidley(List<ItemType> have)
        {
            return CanAccessLowerNorfair(have)
                && have.Contains(ItemType.ChargeBeam)
                && EnergyReserveCount(have) >= 2;
        }

        private static bool CanDefeatDraygon(List<ItemType> have)
        {
            return CanLeaveCentralMaridia(have)
                && CanFly(have)
                && CanDefeatBotwoon(have)
                && (have.Contains(ItemType.SpaceJump)
                    || (have.Contains(ItemType.HiJumpBoots)
                        && have.Contains(ItemType.ScrewAttack)));
        }

        private static bool CanPassWorstRoomInTheGame(List<ItemType> have)
        {
            return (have.Contains(ItemType.SpaceJump)
                       || have.Contains(ItemType.HiJumpBoots)
                       || have.Contains(ItemType.IceBeam));
        }

        private static bool CanIbj(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                && have.Contains(ItemType.MorphingBall));
        }

        private static bool CanCrystalFlash(List<ItemType> have)
        {
            return have.Count(x => x == ItemType.Missile) >= 2
                && have.Count(x => x == ItemType.SuperMissile) >= 2
                && have.Count(x => x == ItemType.PowerBomb) >= 3;
        }

        private static bool CanDefeatBotwoon(List<ItemType> have)
        {
            return CanAccessMaridia(have)
                && have.Contains(ItemType.SpeedBooster)
                && CanOpenPurpleDoors(have)
                && (CanLeaveCentralMaridia(have)
                    || have.Contains(ItemType.GrappleBeam));
        }

        private static bool CanAccessEastMaridia(List<ItemType> have)
        {
            return (CanAccessCrateriaDepths(have)
                    && have.Contains(ItemType.SpeedBooster)
                    && CanUsePowerBombs(have)
                    && (CanFly(have)
                        || CanDefeatKraid(have)))
                || (CanLeaveCentralMaridia(have)
                    && CanFly(have)
                    && (have.Contains(ItemType.SpaceJump)
                        || (have.Contains(ItemType.HiJumpBoots)
                            && have.Contains(ItemType.ScrewAttack))));
        }

        private static bool CanAccessMaridia(List<ItemType> have)
        {
            return have.Contains(ItemType.GravitySuit)
                && have.Contains(ItemType.MorphingBall)
                && (CanFly(have) || CanJumpHigh(have))
                && have.Contains(ItemType.SuperMissile)
                && CanOpenMissileDoors(have)
                && CanPassBombPassages(have);
        }

        private static bool CanLeaveCentralMaridia(List<ItemType> have)
        {
            return CanAccessMaridia(have)
                && CanUsePowerBombs(have);
        }

        private static bool CanEscapeGrappleGauntlet(List<ItemType> have)
        {
            return CanAccessEastNorfair(have)
                && (have.Contains(ItemType.HiJumpBoots)
                    || (CanIbj(have)
                        && have.Contains(ItemType.GravitySuit))
                    || have.Contains(ItemType.SpaceJump)
                    || have.Contains(ItemType.GrappleBeam));
        }

        private static bool CanAccessLowerNorfair(List<ItemType> have)
        {
            return CanAccessEastNorfair(have)
                && ((have.Contains(ItemType.GravitySuit)
                    && CanOpenPurpleDoors(have)
                    && CanPassWorstRoomInTheGame(have))
                    || have.Contains(ItemType.HiJumpBoots))
                && CanFly(have);
        }

        private static bool CanAccessEastNorfair(List<ItemType> have)
        {
            return CanDefeatKraid(have)
                && have.Contains(ItemType.VariaSuit)
                && CanUsePowerBombs(have)
                && CanDbj(have)
                && (have.Contains(ItemType.GrappleBeam)
                    || CanFly(have))
                && ((have.Contains(ItemType.GravitySuit)
                    && CanDefeatKraid(have))
                    || (CanOpenPurpleDoors(have)
                        && (have.Contains(ItemType.GrappleBeam)
                            || have.Contains(ItemType.SpaceJump))));
        }

        private static bool CanAccessNorfair(List<ItemType> have)
        {
            return CanDefeatKraid(have)
                && (have.Contains(ItemType.VariaSuit)
                    || EnergyReserveCount(have) >= 3);
        }

        private static bool CanAccessWestNorfair(List<ItemType> have)
        {
            return have.Contains(ItemType.VariaSuit)
                && CanClipWestNorfairTube(have);
        }

        private static int EnergyReserveCount(List<ItemType> have)
        {
            var energyTankCount = have.Count(x => x == ItemType.EnergyTank);
            var reserveTankCount = Math.Min(have.Count(x => x == ItemType.ReserveTank), energyTankCount + 1);
            return energyTankCount + reserveTankCount;
        }

        private static bool CanAccessNorfairElevator(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && CanOpenMissileDoors(have)
                && (CanPassBombPassages(have)
                    || CanUsePowerBombs(have));
        }

        private static bool CanAccessVariaSuit(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && (CanPassBombPassages(have)
                    || CanUsePowerBombs(have))
                && (CanFly(have)
                    || have.Contains(ItemType.IceBeam));
        }

        private static bool CanDefeatBombTorizo(List<ItemType> have)
        {
            return CanAccessEastCrateria(have)
                && have.Contains(ItemType.Bomb);
        }

        private static bool CanClipWestNorfairTube(List<ItemType> have)
        {
            return CanLeaveWestNorfairTube(have)
                && have.Contains(ItemType.GravitySuit)
                && have.Contains(ItemType.HiJumpBoots);
        }

        private static bool CanLeaveWestNorfairTube(List<ItemType> have)
        {
            return (CanFly(have) || CanJumpHigh(have))
                && CanOpenMissileDoors(have)
                && (have.Contains(ItemType.GrappleBeam)
                    || have.Contains(ItemType.SpaceJump)
                    || (have.Contains(ItemType.GravitySuit)
                        && CanIbj(have)
                        && have.Contains(ItemType.VariaSuit)))
                && (have.Contains(ItemType.VariaSuit)
                    || EnergyReserveCount(have) >= 3);
        }

        private static bool CanBreakWestNorfairTube(List<ItemType> have)
        {
            return CanUsePowerBombs(have)
                && CanOpenMissileDoors(have)
                && have.Contains(ItemType.SuperMissile);
        }

        private static bool CanEnterWestNorfairTube(List<ItemType> have)
        {
            return CanBreakWestNorfairTube(have)
                && (have.Contains(ItemType.GrappleBeam)
                    || have.Contains(ItemType.SpaceJump)
                    || have.Contains(ItemType.VariaSuit));
        }

        private static bool CanHellRun(List<ItemType> have)
        {
            return have.Contains(ItemType.VariaSuit)
                || EnergyReserveCount(have) >= 3;
        }

        private static bool CanDefeatKraid(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && CanOpenMissileDoors(have)
                && (CanPassBombPassages(have)
                    || (CanUsePowerBombs(have)
                        && CanBombJump(have)));
        }

        private static bool CanPassBombPassages(List<ItemType> have)
        {
            return have.Contains(ItemType.MorphingBall)
                && (have.Contains(ItemType.Bomb)
                    || have.Count(x => x == ItemType.PowerBomb) >= 3);
        }

        private static bool CanDbj(List<ItemType> have)
        {
            return have.Contains(ItemType.MorphingBall)
                && (have.Contains(ItemType.Bomb)
                    || have.Contains(ItemType.HiJumpBoots));
        }

        private static bool CanSbj(List<ItemType> have)
        {
            return have.Contains(ItemType.HiJumpBoots)
                && CanPassBombPassages(have);
        }

        private static bool CanBombJump(List<ItemType> have)
        {
            return CanPassBombPassages(have)
                || CanDbj(have);
        }

        private static bool CanFly(List<ItemType> have)
        {
            return CanIbj(have)
                || have.Contains(ItemType.SpaceJump);
        }

        private static bool CanJumpHigh(List<ItemType> have)
        {
            return have.Contains(ItemType.HiJumpBoots)
                || have.Contains(ItemType.SpaceJump);
        }

        private static bool CanUsePowerBombs(List<ItemType> have)
        {
            return have.Contains(ItemType.PowerBomb)
                && have.Contains(ItemType.MorphingBall);
        }

        private static bool CanOpenMissileDoors(List<ItemType> have)
        {
            return have.Contains(ItemType.Missile)
                && have.Contains(ItemType.MorphingBall);
        }

        private static bool CanDestroyBombWalls(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Contains(ItemType.PowerBomb)
                    && have.Contains(ItemType.MorphingBall))
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanEnterAndLeaveGauntlet(List<ItemType> have)
        {
            return (have.Contains(ItemType.Bomb)
                    && have.Contains(ItemType.MorphingBall))
                || (have.Count(x => x == ItemType.PowerBomb) >= 2
                    && have.Contains(ItemType.MorphingBall))
                || have.Contains(ItemType.ScrewAttack);
        }

        private static bool CanDefeatPhantoon(List<ItemType> have)
        {
            return CanAccessWs(have);
        }

        private static bool CanAccessWs(List<ItemType> have)
        {
            return have.Contains(ItemType.SuperMissile)
                && CanUsePowerBombs(have);
        }

        public RomLocationsSpeedrunner()
        {
            ResetLocations();
        }

        public List<Location> GetAvailableLocations(List<ItemType> haveItems)
        {
            var retVal = (from Location location in Locations where (location.Item == null) && location.CanAccess(haveItems) select location).ToList();
            var currentWeight = (from item in retVal orderby item.Weight descending select item.Weight).First() + 1;

            foreach (var item in retVal.Where(item => item.Weight == 0))
            {
                item.Weight = currentWeight;
            }

            var addedItems = new List<List<Location>>();
            for (int i = 1; i < currentWeight; i++)
            {
                addedItems.Add(retVal.Where(x => x.Weight > i).ToList());
            }

            foreach (var list in addedItems)
            {
                retVal.AddRange(list);
            }

            return retVal;
        }

        public List<Location> GetUnavailableLocations(List<ItemType> haveItems)
        {
            return (from Location location in Locations where location.Item == null && !location.CanAccess(haveItems) select location).ToList();
        }

        public void TryInsertCandidateItem(List<Location> currentLocations, List<ItemType> candidateItemList, ItemType candidateItem)
        {
            // only try gravity if gravity is okay in this spot
            // only insert multiples of an item into the candidate list if we aren't looking at the morph ball slot.
            if (!(candidateItem == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay)) && (currentLocations.All(x => x.Name != "Morphing Ball") || !candidateItemList.Contains(candidateItem)))
            {
                candidateItemList.Add(candidateItem);
            }
        }

        public int GetInsertedLocation(List<Location> currentLocations, ItemType insertedItem, SeedRandom random)
        {
            int retVal;

            do
            {
                retVal = random.Next(currentLocations.Count);
            } while (insertedItem == ItemType.GravitySuit && !currentLocations[retVal].GravityOkay);

            return retVal;
        }

        public ItemType GetInsertedItem(List<Location> currentLocations, List<ItemType> itemPool, SeedRandom random)
        {
            ItemType retVal;

            do
            {
                retVal = itemPool[random.Next(itemPool.Count)];
            } while (retVal == ItemType.GravitySuit && !currentLocations.Any(x => x.GravityOkay));

            return retVal;
        }

        public List<ItemType> GetItemPool(SeedRandom random)
        {
            return new List<ItemType>
                       {
                           ItemType.MorphingBall,
                           ItemType.Bomb,
                           ItemType.ChargeBeam,
                           ItemType.Spazer,
                           ItemType.VariaSuit,
                           ItemType.HiJumpBoots,
                           ItemType.SpeedBooster,
                           ItemType.WaveBeam,
                           ItemType.GrappleBeam,
                           ItemType.GravitySuit,
                           ItemType.SpaceJump,
                           ItemType.BeamCombo,
                           ItemType.PlasmaBeam,
                           ItemType.IceBeam,
                           ItemType.ScrewAttack,
                           ItemType.XRayScope,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.ReserveTank,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.Missile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.SuperMissile,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.PowerBomb,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                           ItemType.EnergyTank,
                       };
        }
    }
}
