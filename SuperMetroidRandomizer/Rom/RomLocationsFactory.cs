using SuperMetroidRandomizer.Random;

namespace SuperMetroidRandomizer.Rom
{
    public class RomLocationsFactory
    {
        public static IRomLocations GetRomLocations(RandomizerDifficulty difficulty)
        {
            return new RomLocationsSpeedrunner();
        }
    }
}
