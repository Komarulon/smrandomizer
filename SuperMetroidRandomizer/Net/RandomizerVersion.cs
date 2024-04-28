using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SuperMetroidRandomizer.Net
{
    public static class RandomizerVersion
    {
        public static string Current = "2.5a";

        public static string CurrentDisplay
        {
            get
            {
                var retVal = Current;

                if (retVal.Contains("P"))
                {
                    retVal = string.Format("{0})", retVal.Replace("P", " (preview "));
                }

                return retVal;
            }
        }
    }
}
