using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LightMap
{
    public partial class LightMap : Form
    {
        private Settings settings = new Settings();

        public LightMap()
        {
            InitializeComponent();
            this.DragEnter += new DragEventHandler(LightMap_DragEnter);
            this.DragDrop += new DragEventHandler(LightMap_DragDrop);

            presetCombo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.Filter = "JSON Files (*.json)|*.json";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    optionsPanel.Visible = true;
                    selectJSONName.Text = openFileDialog1.FileName.ToString();
                    this.Width = 441;
                    this.Height = 441;
                    presetCombo.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Probably not a JSON file. Original error: " + ex.Message);
                }
            }
        }

        private void laserSpeed_ValueChanged(object sender, EventArgs e)
        {
            laserSpeedlabel.Text = "Laser Speed: " + laserSpeed.Value.ToString();
            settings.laserSpeed = laserSpeed.Value;
        }

        private void spawnSpeed_ValueChanged(object sender, EventArgs e)
        {
            switch (spawnSpeed.Value)
            {
                case 0:
                    spawnSpeedlabel.Text = "Spawn Speed: Slow";
                    settings.spawnSpeed = 16;
                    break;
                case 1:
                    spawnSpeedlabel.Text = "Spawn Speed: Normal";
                    settings.spawnSpeed = 8;
                    break;
                case 2:
                    spawnSpeedlabel.Text = "Spawn Speed: Fast";
                    settings.spawnSpeed = 4;
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (presetCombo.SelectedIndex)
            {
                case 0: // Default
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = true;
                    noteConvertPrecise.Checked = false;
                    laserSpeed.Value = 4;
                    laserSpeedlabel.Text = "Laser Speed: 4";
                    bigLights.Checked = true;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = true;
                    spawnSpeed.Value = 1;
                    spawnSpeedlabel.Text = "Spawn Speed: Normal";

                    break;
                case 1: // Minimal
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = true;
                    noteConvertPrecise.Checked = true;
                    laserSpeed.Value = 2;
                    laserSpeedlabel.Text = "Laser Speed: 2";
                    bigLights.Checked = true;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = false;
                    spawnSpeed.Value = 0;
                    spawnSpeedlabel.Text = "Spawn Speed: Slow";

                    break;
                case 2: // Super Minimal
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = false;
                    noteConvertPrecise.Checked = false;
                    laserSpeed.Value = 1;
                    laserSpeedlabel.Text = "Laser Speed: 1";
                    bigLights.Checked = true;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = false;
                    spawnSpeed.Value = 0;
                    spawnSpeedlabel.Text = "Spawn Speed: Slow";

                    break;
                case 3: // Dark 'n' Flashy
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = true;
                    noteConvertPrecise.Checked = false;
                    laserSpeed.Value = 3;
                    laserSpeedlabel.Text = "Laser Speed: 3";
                    bigLights.Checked = false;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = false;
                    spawnSpeed.Value = 1;
                    spawnSpeedlabel.Text = "Spawn Speed: Normal";

                    break;
                case 4: // Super Dark
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = true;
                    noteConvertPrecise.Checked = true;
                    laserSpeed.Value = 1;
                    laserSpeedlabel.Text = "Laser Speed: 1";
                    bigLights.Checked = false;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = false;
                    spawnSpeed.Value = 0;
                    spawnSpeedlabel.Text = "Spawn Speed: Slow";

                    break;
                case 5: // THERE WAS LIGHT
                    SetAutoChecksEnabled(false);

                    noteConvert.Checked = true;
                    noteConvertPrecise.Checked = false;
                    laserSpeed.Value = 8;
                    laserSpeedlabel.Text = "Laser Speed: 8";
                    bigLights.Checked = true;
                    ringSpins.Checked = true;
                    bigLightFade.Checked = false;
                    spawnSpeed.Value = 2;
                    spawnSpeedlabel.Text = "Spawn Speed: Fast";

                    break;
                case 6: // Custom
                    SetAutoChecksEnabled(true);
                    break;
            }
        }

        private void SetAutoChecksEnabled(bool enabled)
        {
            noteConvert.AutoCheck = enabled;
            noteConvertPrecise.AutoCheck = enabled;
            laserSpeed.Enabled = enabled;
            bigLights.AutoCheck = enabled;
            bigLightFade.AutoCheck = enabled;
            ringSpins.AutoCheck = enabled;
            spawnSpeed.Enabled = enabled;
        }

        private void noteConvert_CheckedChanged(object sender, EventArgs e)
        {
            settings.noteConvert = noteConvert.Checked;
        }

        private void noteConvertPrecise_CheckedChanged(object sender, EventArgs e)
        {
            settings.noteConvertPrecise = noteConvertPrecise.Checked;
        }

        private void bigLights_CheckedChanged(object sender, EventArgs e)
        {
            settings.bigLights = bigLights.Checked;
            switch (bigLights.Checked)
            {
                case true:
                    bigLightFade.Enabled = true;
                    break;
                case false:
                    bigLightFade.Checked = false;
                    settings.bigLightFade = false;
                    bigLightFade.Enabled = false;
                    break;
            }
        }

        private void bigLightFade_CheckedChanged(object sender, EventArgs e)
        {
            settings.bigLightFade = bigLightFade.Checked;
        }

        private void ringSpins_CheckedChanged(object sender, EventArgs e)
        {
            settings.ringSpins = ringSpins.Checked;
        }

        private void LightMap_Load(object sender, EventArgs e)
        {
            this.Width = 441;
            this.Height = 112;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(this.noteConvert, "Convert all note blocks to lights.");
            toolTip1.SetToolTip(this.noteConvertPrecise, "Convert only note blocks that land on whole beat numbers.");
            toolTip1.SetToolTip(this.laserSpeed, "Speed the laser lights move.");
            toolTip1.SetToolTip(this.bigLights, "Generate Big Lights.");
            toolTip1.SetToolTip(this.bigLightFade, "Fade out previous Big Light colour before lighting it with next colour.");
            toolTip1.SetToolTip(this.ringSpins, "Enable spinning of Ring Lights.");
            toolTip1.SetToolTip(this.spawnSpeed, "Distance between Big Lights/Ring Spins Every 4th beat, 8th beat, or 16th beat");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            LightMapMagic awesomeSauce = new LightMapMagic(settings);
            awesomeSauce.GenerateBeatMapEvents(selectJSONName.Text.TrimEnd());
        }

        private void LightMap_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                e.Effect = DragDropEffects.All;
        }

        private void LightMap_DragDrop(object sender, DragEventArgs e)
        {
            string[] fileList = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (string s in fileList)
            {
                //replace this with your own code
                selectJSONName.Text = String.Format("{0}{1}", s, Environment.NewLine);
                optionsPanel.Visible = true;
                this.Width = 441;
                this.Height = 441;
                presetCombo.SelectedIndex = 0;
            }

        }
    }
}
