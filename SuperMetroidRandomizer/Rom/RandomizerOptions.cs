namespace SuperMetroidRandomizer.Rom
{

    public struct RandomizerOptions
    {
        public bool cycleSaves { get; set; }
        public bool earlierBombs { get; set; }
        public bool fastFanfares { get; set; }
        public bool preventCommonSoftlocks{ get; set; }
        public RandomizerAlgorithm randomizerAlgorithm { get; set; }
    }

    public static class RandomizerAlgorithmUtil
    {
        private const string DessysOriginal = "Dessyreqt's Original";
        private const string KomaruProgressive = "Komaru's Progressive";
        public static string RandomizerAlgorithmToString(RandomizerAlgorithm randomizerAlgorithm)
        {
            switch (randomizerAlgorithm)
            {
                case RandomizerAlgorithm.DessysOriginal: return DessysOriginal;
                case RandomizerAlgorithm.KomaruProgressive: return KomaruProgressive;
            }
            return "";
        }

        public static RandomizerAlgorithm StringToRandomizerAlgorithm(string str)
        {
            switch (str)
            {
                case DessysOriginal: return  RandomizerAlgorithm.DessysOriginal;
                case KomaruProgressive: return RandomizerAlgorithm.KomaruProgressive;
            }
            throw new System.Exception("Unknown Randomizer Algorithm String");
        }
    }

    public enum RandomizerAlgorithm
    {
        DessysOriginal,
        KomaruProgressive
    }
}
