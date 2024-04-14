using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SuperMetroidRandomizer.IO;
using SuperMetroidRandomizer.Net;
using SuperMetroidRandomizer.Properties;
using SuperMetroidRandomizer.Random;
using SuperMetroidRandomizer.Rom;

namespace SuperMetroidRandomizer
{
    public enum Suitless
    {
        Disabled,
        Possible,
        Forced
    }

    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeSettings();
            InitializeComponent();
        }

        private void InitializeSettings()
        {
            Settings.Default.OutputFileV11 = Settings.Default.OutputFileV11;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            filenameV11.Text = Settings.Default.OutputFileV11;
            Text = string.Format("Super Metroid: Redesign Randomizer v{0}", RandomizerVersion.CurrentDisplay);
        }

        private void createV11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(seedV11.Text))
            {
                SetSeedBasedOnDifficulty();
            }

            ClearOutputV11();

            var difficulty = GetRandomizerDifficulty();

            this.CreateRom(difficulty);

            Settings.Default.Save();
        }

        private RandomizerOptions GetRandomizerOptions()
        {
            return new RandomizerOptions
            {
                cycleSaves = this.Cycle_Saves_Checkbox.Checked,
                earlierBombs = this.MoreBombsCheckbox.Checked,
                fastFanfares = this.FastFanfaresCheckbox.Checked,
                preventCommonSoftlocks = this.softlockHelpCheckbox.Checked,
            };
        }

        private void CreateRom(RandomizerDifficulty difficulty)
        {
            int parsedSeed;
            if (!int.TryParse(seedV11.Text, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutputV11("Seed must be numeric or blank.");
            }
            else
            {
                var romLocations = RomLocationsFactory.GetRomLocations(difficulty);
                RandomizerLog log = null;

                if (true)
                {
                    log = new RandomizerLog(string.Format(romLocations.SeedFileString, parsedSeed));
                }

                seedV11.Text = string.Format(romLocations.SeedFileString, parsedSeed);
                var randomizerV11 = new RandomizerV11(parsedSeed, romLocations, log);
                randomizerV11.CreateRom(filenameV11.Text, this.GetRandomizerOptions());

                var outputString = new StringBuilder();

                outputString.AppendFormat("Done!{0}{0}{0}Seed: ", Environment.NewLine);
                outputString.AppendFormat(romLocations.SeedFileString, parsedSeed);
                outputString.AppendFormat(" ({0} Difficulty){1}{1}", romLocations.DifficultyName, Environment.NewLine);

                WriteOutputV11(outputString.ToString());
            }
        }

        private void CreateSpoilerLog(RandomizerDifficulty difficulty, RandomizerOptions randomizerOptions)
        {
            int parsedSeed;

            if (!int.TryParse(seedV11.Text, out parsedSeed))
            {
                MessageBox.Show("Seed must be numeric or blank.", "Seed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                WriteOutputV11("Seed must be numeric or blank.");
            }
            else
            {
                var romPlms = RomLocationsFactory.GetRomLocations(difficulty);
                RandomizerLog log = new RandomizerLog(string.Format(romPlms.SeedFileString, parsedSeed));

                seedV11.Text = string.Format(romPlms.SeedFileString, parsedSeed);

                var randomizer = new RandomizerV11(parsedSeed, romPlms, log);
                WriteOutputV11(randomizer.CreateRom(filenameV11.Text, randomizerOptions, true));
            }
        }

        private RandomizerDifficulty GetRandomizerDifficulty()
        {
            RandomizerDifficulty difficulty;

            if (seedV11.Text.ToUpper().Contains("S"))
            {
                seedV11.Text = seedV11.Text.ToUpper().Replace("S", "");
                difficulty = RandomizerDifficulty.Speedrunner;
            }
            else
            {
                difficulty = RandomizerDifficulty.Speedrunner;
            }
            return difficulty;
        }

        public RandomizerDifficulty GetDifficultyFromString(string str)
        {
            switch (str)
            {
                case "Speedrunner":
                    return RandomizerDifficulty.Speedrunner;
                default:
                    return RandomizerDifficulty.Speedrunner;
            }
        }

        private void SetSeedBasedOnDifficulty()
        {
            seedV11.Text = string.Format("S{0:0000000}", (new SeedRandom()).Next(10000000));
        }

        private void ClearOutputV11()
        {
            outputV11.Text = "";
        }

        private void WriteOutputV11(string text)
        {
            outputV11.Text += text;
        }

        private void browseV11_Click(object sender, EventArgs e)
        {
            var info = new FileInfo(Regex.Replace(filenameV11.Text, "<.*>", ""));
            var saveFileDialog = new SaveFileDialog { Filter = "All files (*.*)|*.*", FilterIndex = 2, RestoreDirectory = true, InitialDirectory = info.DirectoryName, FileName = info.Name };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filenameV11.Text = saveFileDialog.FileName;
                MessageBox.Show("Remember to hit \"create\" to create the rom.", "Remember to create the rom!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        private void filenameV11_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.OutputFileV11 = filenameV11.Text;
            Settings.Default.Save();
        }

        private void filename_Leave(object sender, EventArgs e)
        {
            var senderText = (TextBox)sender;

            if (!senderText.Text.Contains("."))
            {
                senderText.Text += ".sfc";
            }
        }

        private void randomSpoiler_Click(object sender, EventArgs e)
        {
            SetSeedBasedOnDifficulty();

            ClearOutputV11();

            var difficulty = GetRandomizerDifficulty();
            CreateSpoilerLog(difficulty, this.GetRandomizerOptions());
        }

        private void Cycle_Saves_Checkbox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
