namespace LightMap
{
    partial class LightMap
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LightMap));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.selectJsonButton = new System.Windows.Forms.Button();
            this.selectJSONName = new System.Windows.Forms.TextBox();
            this.optionsPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.bigLightFade = new System.Windows.Forms.CheckBox();
            this.spawnSpeedlabel = new System.Windows.Forms.Label();
            this.spawnSpeed = new System.Windows.Forms.TrackBar();
            this.ringSpins = new System.Windows.Forms.CheckBox();
            this.bigLights = new System.Windows.Forms.CheckBox();
            this.laserSpeedlabel = new System.Windows.Forms.Label();
            this.laserSpeed = new System.Windows.Forms.TrackBar();
            this.noteConvertPrecise = new System.Windows.Forms.CheckBox();
            this.noteConvert = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.presetCombo = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.optionsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spawnSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // selectJsonButton
            // 
            this.selectJsonButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectJsonButton.Location = new System.Drawing.Point(21, 23);
            this.selectJsonButton.Name = "selectJsonButton";
            this.selectJsonButton.Size = new System.Drawing.Size(109, 23);
            this.selectJsonButton.TabIndex = 0;
            this.selectJsonButton.Text = "Select Difficulty JSON";
            this.selectJsonButton.UseVisualStyleBackColor = true;
            this.selectJsonButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // selectJSONName
            // 
            this.selectJSONName.Location = new System.Drawing.Point(136, 25);
            this.selectJSONName.Name = "selectJSONName";
            this.selectJSONName.ReadOnly = true;
            this.selectJSONName.Size = new System.Drawing.Size(269, 20);
            this.selectJSONName.TabIndex = 1;
            // 
            // optionsPanel
            // 
            this.optionsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.optionsPanel.Controls.Add(this.button1);
            this.optionsPanel.Controls.Add(this.bigLightFade);
            this.optionsPanel.Controls.Add(this.spawnSpeedlabel);
            this.optionsPanel.Controls.Add(this.spawnSpeed);
            this.optionsPanel.Controls.Add(this.ringSpins);
            this.optionsPanel.Controls.Add(this.bigLights);
            this.optionsPanel.Controls.Add(this.laserSpeedlabel);
            this.optionsPanel.Controls.Add(this.laserSpeed);
            this.optionsPanel.Controls.Add(this.noteConvertPrecise);
            this.optionsPanel.Controls.Add(this.noteConvert);
            this.optionsPanel.Controls.Add(this.label6);
            this.optionsPanel.Controls.Add(this.presetCombo);
            this.optionsPanel.Location = new System.Drawing.Point(18, 57);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new System.Drawing.Size(387, 313);
            this.optionsPanel.TabIndex = 14;
            this.optionsPanel.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 273);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "GO !";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // bigLightFade
            // 
            this.bigLightFade.AutoSize = true;
            this.bigLightFade.Location = new System.Drawing.Point(61, 171);
            this.bigLightFade.Name = "bigLightFade";
            this.bigLightFade.Size = new System.Drawing.Size(94, 17);
            this.bigLightFade.TabIndex = 10;
            this.bigLightFade.Text = "Big Light Fade";
            this.bigLightFade.UseVisualStyleBackColor = true;
            this.bigLightFade.CheckedChanged += new System.EventHandler(this.bigLightFade_CheckedChanged);
            // 
            // spawnSpeedlabel
            // 
            this.spawnSpeedlabel.Location = new System.Drawing.Point(163, 198);
            this.spawnSpeedlabel.Name = "spawnSpeedlabel";
            this.spawnSpeedlabel.Size = new System.Drawing.Size(133, 16);
            this.spawnSpeedlabel.TabIndex = 0;
            this.spawnSpeedlabel.Text = "Spawn Speed: Normal";
            // 
            // spawnSpeed
            // 
            this.spawnSpeed.Enabled = false;
            this.spawnSpeed.LargeChange = 2;
            this.spawnSpeed.Location = new System.Drawing.Point(61, 196);
            this.spawnSpeed.Maximum = 2;
            this.spawnSpeed.Name = "spawnSpeed";
            this.spawnSpeed.Size = new System.Drawing.Size(104, 45);
            this.spawnSpeed.TabIndex = 9;
            this.spawnSpeed.Value = 2;
            this.spawnSpeed.ValueChanged += new System.EventHandler(this.spawnSpeed_ValueChanged);
            // 
            // ringSpins
            // 
            this.ringSpins.AutoSize = true;
            this.ringSpins.Location = new System.Drawing.Point(61, 240);
            this.ringSpins.Name = "ringSpins";
            this.ringSpins.Size = new System.Drawing.Size(77, 17);
            this.ringSpins.TabIndex = 8;
            this.ringSpins.Text = "Ring Spins";
            this.ringSpins.UseVisualStyleBackColor = true;
            this.ringSpins.CheckedChanged += new System.EventHandler(this.ringSpins_CheckedChanged);
            // 
            // bigLights
            // 
            this.bigLights.AutoSize = true;
            this.bigLights.Location = new System.Drawing.Point(61, 148);
            this.bigLights.Name = "bigLights";
            this.bigLights.Size = new System.Drawing.Size(72, 17);
            this.bigLights.TabIndex = 7;
            this.bigLights.Text = "Big Lights";
            this.bigLights.UseVisualStyleBackColor = true;
            this.bigLights.CheckedChanged += new System.EventHandler(this.bigLights_CheckedChanged);
            // 
            // laserSpeedlabel
            // 
            this.laserSpeedlabel.AutoSize = true;
            this.laserSpeedlabel.Location = new System.Drawing.Point(160, 115);
            this.laserSpeedlabel.Name = "laserSpeedlabel";
            this.laserSpeedlabel.Size = new System.Drawing.Size(79, 13);
            this.laserSpeedlabel.TabIndex = 6;
            this.laserSpeedlabel.Text = "Laser Speed: 0";
            // 
            // laserSpeed
            // 
            this.laserSpeed.Cursor = System.Windows.Forms.Cursors.Default;
            this.laserSpeed.Enabled = false;
            this.laserSpeed.LargeChange = 1;
            this.laserSpeed.Location = new System.Drawing.Point(53, 110);
            this.laserSpeed.Maximum = 8;
            this.laserSpeed.Name = "laserSpeed";
            this.laserSpeed.Size = new System.Drawing.Size(104, 45);
            this.laserSpeed.TabIndex = 4;
            this.laserSpeed.ValueChanged += new System.EventHandler(this.laserSpeed_ValueChanged);
            // 
            // noteConvertPrecise
            // 
            this.noteConvertPrecise.AutoSize = true;
            this.noteConvertPrecise.Location = new System.Drawing.Point(61, 87);
            this.noteConvertPrecise.Name = "noteConvertPrecise";
            this.noteConvertPrecise.Size = new System.Drawing.Size(127, 17);
            this.noteConvertPrecise.TabIndex = 3;
            this.noteConvertPrecise.Text = "Note Convert Precise";
            this.noteConvertPrecise.UseVisualStyleBackColor = true;
            this.noteConvertPrecise.CheckedChanged += new System.EventHandler(this.noteConvertPrecise_CheckedChanged);
            // 
            // noteConvert
            // 
            this.noteConvert.AutoSize = true;
            this.noteConvert.Location = new System.Drawing.Point(61, 63);
            this.noteConvert.Name = "noteConvert";
            this.noteConvert.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.noteConvert.Size = new System.Drawing.Size(89, 17);
            this.noteConvert.TabIndex = 2;
            this.noteConvert.Text = "Note Convert";
            this.noteConvert.UseVisualStyleBackColor = true;
            this.noteConvert.CheckedChanged += new System.EventHandler(this.noteConvert_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Preset";
            // 
            // presetCombo
            // 
            this.presetCombo.FormattingEnabled = true;
            this.presetCombo.Items.AddRange(new object[] {
            "Default",
            "Minimal",
            "Super Minimal",
            "Dark \'n\' Flashy",
            "Super Dark",
            "THERE WAS LIGHT",
            "Custom"});
            this.presetCombo.Location = new System.Drawing.Point(61, 24);
            this.presetCombo.Name = "presetCombo";
            this.presetCombo.Size = new System.Drawing.Size(121, 21);
            this.presetCombo.TabIndex = 0;
            this.presetCombo.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::LightMap.Properties.Resources.settings;
            this.button2.Location = new System.Drawing.Point(400, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(23, 23);
            this.button2.TabIndex = 15;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            // 
            // LightMap
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 402);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.selectJSONName);
            this.Controls.Add(this.selectJsonButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LightMap";
            this.Text = "LightMap";
            this.Load += new System.EventHandler(this.LightMap_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.LightMap_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.LightMap_DragEnter);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spawnSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laserSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button selectJsonButton;
        private System.Windows.Forms.TextBox selectJSONName;
        private System.Windows.Forms.Panel optionsPanel;
        private System.Windows.Forms.ComboBox presetCombo;
        private System.Windows.Forms.TrackBar laserSpeed;
        private System.Windows.Forms.CheckBox noteConvertPrecise;
        private System.Windows.Forms.CheckBox noteConvert;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label laserSpeedlabel;
        private System.Windows.Forms.Label spawnSpeedlabel;
        private System.Windows.Forms.TrackBar spawnSpeed;
        private System.Windows.Forms.CheckBox ringSpins;
        private System.Windows.Forms.CheckBox bigLights;
        private System.Windows.Forms.CheckBox bigLightFade;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

