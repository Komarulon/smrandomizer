using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsFactory
    {
        public static IRomLocations GetRomLocations(RandomizerOptions randomizerOptions)
        {
            return new RomLocationsSpeedrunner(randomizerOptions);
        }
    }
}
