
namespace SavannaLifeGame
{
    partial class SavannaLifeGame
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
            this.savannaPictureBox = new System.Windows.Forms.PictureBox();
            this.entitiesComboBox = new System.Windows.Forms.ComboBox();
            this.addEntityCheckBox = new System.Windows.Forms.CheckBox();
            this.addEntityGroupBox = new System.Windows.Forms.GroupBox();
            this.randomEntitySpawnComboBox = new System.Windows.Forms.ComboBox();
            this.spawnRateTrackBar = new System.Windows.Forms.TrackBar();
            this.spawnEntitiesRandomlyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.entityInfoTextBox = new System.Windows.Forms.TextBox();
            this.entityInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.saveLoadGroupBox = new System.Windows.Forms.GroupBox();
            this.loadButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.playPauseGroupBox = new System.Windows.Forms.GroupBox();
            this.clearFieldGroupBox = new System.Windows.Forms.GroupBox();
            this.clearEntitesButton = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.removeEntityGroupBox = new System.Windows.Forms.GroupBox();
            this.removeEntityButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.savannaPictureBox)).BeginInit();
            this.addEntityGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spawnRateTrackBar)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.entityInfoGroupBox.SuspendLayout();
            this.saveLoadGroupBox.SuspendLayout();
            this.playPauseGroupBox.SuspendLayout();
            this.clearFieldGroupBox.SuspendLayout();
            this.removeEntityGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // savannaPictureBox
            // 
            this.savannaPictureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(167)))), ((int)(((byte)(103)))));
            this.savannaPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.savannaPictureBox.Location = new System.Drawing.Point(12, 12);
            this.savannaPictureBox.Name = "savannaPictureBox";
            this.savannaPictureBox.Size = new System.Drawing.Size(640, 420);
            this.savannaPictureBox.TabIndex = 0;
            this.savannaPictureBox.TabStop = false;
            this.savannaPictureBox.Click += new System.EventHandler(this.savannaPictureBox_Click);
            this.savannaPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.savannaPictureBox_Paint);
            // 
            // entitiesComboBox
            // 
            this.entitiesComboBox.FormattingEnabled = true;
            this.entitiesComboBox.Items.AddRange(new object[] {
            "Grass",
            "Gazelle",
            "Leopard",
            "Hippopotamus"});
            this.entitiesComboBox.Location = new System.Drawing.Point(17, 19);
            this.entitiesComboBox.Name = "entitiesComboBox";
            this.entitiesComboBox.Size = new System.Drawing.Size(170, 21);
            this.entitiesComboBox.TabIndex = 2;
            // 
            // addEntityCheckBox
            // 
            this.addEntityCheckBox.AutoSize = true;
            this.addEntityCheckBox.Location = new System.Drawing.Point(17, 46);
            this.addEntityCheckBox.Name = "addEntityCheckBox";
            this.addEntityCheckBox.Size = new System.Drawing.Size(113, 17);
            this.addEntityCheckBox.TabIndex = 3;
            this.addEntityCheckBox.Text = "Add entity on click";
            this.addEntityCheckBox.UseVisualStyleBackColor = true;
            // 
            // addEntityGroupBox
            // 
            this.addEntityGroupBox.Controls.Add(this.entitiesComboBox);
            this.addEntityGroupBox.Controls.Add(this.addEntityCheckBox);
            this.addEntityGroupBox.Location = new System.Drawing.Point(663, 65);
            this.addEntityGroupBox.Name = "addEntityGroupBox";
            this.addEntityGroupBox.Size = new System.Drawing.Size(205, 74);
            this.addEntityGroupBox.TabIndex = 4;
            this.addEntityGroupBox.TabStop = false;
            this.addEntityGroupBox.Text = "Add entity";
            // 
            // randomEntitySpawnComboBox
            // 
            this.randomEntitySpawnComboBox.FormattingEnabled = true;
            this.randomEntitySpawnComboBox.Items.AddRange(new object[] {
            "Grass",
            "Gazelle",
            "Leopard",
            "Hippopotamus"});
            this.randomEntitySpawnComboBox.Location = new System.Drawing.Point(17, 19);
            this.randomEntitySpawnComboBox.Name = "randomEntitySpawnComboBox";
            this.randomEntitySpawnComboBox.Size = new System.Drawing.Size(170, 21);
            this.randomEntitySpawnComboBox.TabIndex = 5;
            // 
            // spawnRateTrackBar
            // 
            this.spawnRateTrackBar.Location = new System.Drawing.Point(17, 46);
            this.spawnRateTrackBar.Name = "spawnRateTrackBar";
            this.spawnRateTrackBar.Size = new System.Drawing.Size(170, 45);
            this.spawnRateTrackBar.TabIndex = 6;
            // 
            // spawnEntitiesRandomlyCheckBox
            // 
            this.spawnEntitiesRandomlyCheckBox.AutoSize = true;
            this.spawnEntitiesRandomlyCheckBox.Location = new System.Drawing.Point(17, 83);
            this.spawnEntitiesRandomlyCheckBox.Name = "spawnEntitiesRandomlyCheckBox";
            this.spawnEntitiesRandomlyCheckBox.Size = new System.Drawing.Size(133, 17);
            this.spawnEntitiesRandomlyCheckBox.TabIndex = 7;
            this.spawnEntitiesRandomlyCheckBox.Text = "Spawn random entities";
            this.spawnEntitiesRandomlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.randomEntitySpawnComboBox);
            this.groupBox1.Controls.Add(this.spawnEntitiesRandomlyCheckBox);
            this.groupBox1.Controls.Add(this.spawnRateTrackBar);
            this.groupBox1.Location = new System.Drawing.Point(663, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(205, 110);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Spawn";
            // 
            // entityInfoTextBox
            // 
            this.entityInfoTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.entityInfoTextBox.Location = new System.Drawing.Point(17, 20);
            this.entityInfoTextBox.Name = "entityInfoTextBox";
            this.entityInfoTextBox.ReadOnly = true;
            this.entityInfoTextBox.Size = new System.Drawing.Size(821, 20);
            this.entityInfoTextBox.TabIndex = 10;
            // 
            // entityInfoGroupBox
            // 
            this.entityInfoGroupBox.Controls.Add(this.entityInfoTextBox);
            this.entityInfoGroupBox.Location = new System.Drawing.Point(12, 438);
            this.entityInfoGroupBox.Name = "entityInfoGroupBox";
            this.entityInfoGroupBox.Size = new System.Drawing.Size(856, 56);
            this.entityInfoGroupBox.TabIndex = 11;
            this.entityInfoGroupBox.TabStop = false;
            this.entityInfoGroupBox.Text = "Entity info";
            // 
            // saveLoadGroupBox
            // 
            this.saveLoadGroupBox.Controls.Add(this.loadButton);
            this.saveLoadGroupBox.Controls.Add(this.saveButton);
            this.saveLoadGroupBox.Location = new System.Drawing.Point(663, 379);
            this.saveLoadGroupBox.Name = "saveLoadGroupBox";
            this.saveLoadGroupBox.Size = new System.Drawing.Size(205, 53);
            this.saveLoadGroupBox.TabIndex = 12;
            this.saveLoadGroupBox.TabStop = false;
            this.saveLoadGroupBox.Text = "Save or load a game";
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(107, 18);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(80, 23);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(17, 18);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(80, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // playPauseButton
            // 
            this.playPauseButton.Location = new System.Drawing.Point(17, 17);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(170, 23);
            this.playPauseButton.TabIndex = 0;
            this.playPauseButton.Text = "Play";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // playPauseGroupBox
            // 
            this.playPauseGroupBox.Controls.Add(this.playPauseButton);
            this.playPauseGroupBox.Location = new System.Drawing.Point(663, 6);
            this.playPauseGroupBox.Name = "playPauseGroupBox";
            this.playPauseGroupBox.Size = new System.Drawing.Size(205, 53);
            this.playPauseGroupBox.TabIndex = 9;
            this.playPauseGroupBox.TabStop = false;
            this.playPauseGroupBox.Text = "Play or pause";
            // 
            // clearFieldGroupBox
            // 
            this.clearFieldGroupBox.Controls.Add(this.clearEntitesButton);
            this.clearFieldGroupBox.Location = new System.Drawing.Point(663, 320);
            this.clearFieldGroupBox.Name = "clearFieldGroupBox";
            this.clearFieldGroupBox.Size = new System.Drawing.Size(205, 53);
            this.clearFieldGroupBox.TabIndex = 10;
            this.clearFieldGroupBox.TabStop = false;
            this.clearFieldGroupBox.Text = "Clear field";
            // 
            // clearEntitesButton
            // 
            this.clearEntitesButton.Location = new System.Drawing.Point(17, 17);
            this.clearEntitesButton.Name = "clearEntitesButton";
            this.clearEntitesButton.Size = new System.Drawing.Size(170, 23);
            this.clearEntitesButton.TabIndex = 0;
            this.clearEntitesButton.Text = "Clear";
            this.clearEntitesButton.UseVisualStyleBackColor = true;
            this.clearEntitesButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // removeEntityGroupBox
            // 
            this.removeEntityGroupBox.Controls.Add(this.removeEntityButton);
            this.removeEntityGroupBox.Location = new System.Drawing.Point(663, 261);
            this.removeEntityGroupBox.Name = "removeEntityGroupBox";
            this.removeEntityGroupBox.Size = new System.Drawing.Size(205, 53);
            this.removeEntityGroupBox.TabIndex = 11;
            this.removeEntityGroupBox.TabStop = false;
            this.removeEntityGroupBox.Text = "Remove selected entity";
            // 
            // removeEntityButton
            // 
            this.removeEntityButton.Location = new System.Drawing.Point(17, 17);
            this.removeEntityButton.Name = "removeEntityButton";
            this.removeEntityButton.Size = new System.Drawing.Size(170, 23);
            this.removeEntityButton.TabIndex = 0;
            this.removeEntityButton.Text = "Remove";
            this.removeEntityButton.UseVisualStyleBackColor = true;
            this.removeEntityButton.Click += new System.EventHandler(this.removeEntityButton_Click);
            // 
            // SavannaLifeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 506);
            this.Controls.Add(this.removeEntityGroupBox);
            this.Controls.Add(this.clearFieldGroupBox);
            this.Controls.Add(this.saveLoadGroupBox);
            this.Controls.Add(this.savannaPictureBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.playPauseGroupBox);
            this.Controls.Add(this.entityInfoGroupBox);
            this.Controls.Add(this.addEntityGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SavannaLifeGame";
            this.Text = "Savanna Life Game";
            ((System.ComponentModel.ISupportInitialize)(this.savannaPictureBox)).EndInit();
            this.addEntityGroupBox.ResumeLayout(false);
            this.addEntityGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spawnRateTrackBar)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.entityInfoGroupBox.ResumeLayout(false);
            this.entityInfoGroupBox.PerformLayout();
            this.saveLoadGroupBox.ResumeLayout(false);
            this.playPauseGroupBox.ResumeLayout(false);
            this.clearFieldGroupBox.ResumeLayout(false);
            this.removeEntityGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox savannaPictureBox;
        private System.Windows.Forms.ComboBox entitiesComboBox;
        private System.Windows.Forms.CheckBox addEntityCheckBox;
        private System.Windows.Forms.GroupBox addEntityGroupBox;
        private System.Windows.Forms.ComboBox randomEntitySpawnComboBox;
        private System.Windows.Forms.TrackBar spawnRateTrackBar;
        private System.Windows.Forms.CheckBox spawnEntitiesRandomlyCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox entityInfoTextBox;
        private System.Windows.Forms.GroupBox entityInfoGroupBox;
        private System.Windows.Forms.GroupBox saveLoadGroupBox;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.GroupBox playPauseGroupBox;
        private System.Windows.Forms.GroupBox clearFieldGroupBox;
        private System.Windows.Forms.Button clearEntitesButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.GroupBox removeEntityGroupBox;
        private System.Windows.Forms.Button removeEntityButton;
    }
}

