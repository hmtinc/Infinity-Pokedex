namespace Pokedex
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pokemonLabel = new System.Windows.Forms.Label();
            this.sortLabel = new System.Windows.Forms.Label();
            this.toolLabel = new System.Windows.Forms.Label();
            this.pokemonListBox = new System.Windows.Forms.ListBox();
            this.previewPictureBox = new System.Windows.Forms.PictureBox();
            this.closePictureBox = new System.Windows.Forms.PictureBox();
            this.exitPictureBox = new System.Windows.Forms.PictureBox();
            this.joystickPictureBox = new System.Windows.Forms.PictureBox();
            this.statPictureBox = new System.Windows.Forms.PictureBox();
            this.typeLabel = new System.Windows.Forms.Label();
            this.type2Label = new System.Windows.Forms.Label();
            this.hpLabel = new System.Windows.Forms.Label();
            this.attackLabel = new System.Windows.Forms.Label();
            this.defenseLabel = new System.Windows.Forms.Label();
            this.spaAttackLabel = new System.Windows.Forms.Label();
            this.spDefenseLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.evolveLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.aPictureBox = new System.Windows.Forms.PictureBox();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            this.xPictureBox = new System.Windows.Forms.PictureBox();
            this.yPictureBox = new System.Windows.Forms.PictureBox();
            this.bPictureBox = new System.Windows.Forms.PictureBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.aboutLabel = new System.Windows.Forms.Label();
            this.extraLabel = new System.Windows.Forms.Label();
            this.backLabel = new System.Windows.Forms.Label();
            this.pictureBoxType1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxType2 = new System.Windows.Forms.PictureBox();
            this.pokemonDataGridView = new System.Windows.Forms.DataGridView();
            this.backPictureBox = new System.Windows.Forms.PictureBox();
            this.pokemonBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.joystickPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pokemonLabel
            // 
            this.pokemonLabel.BackColor = System.Drawing.Color.Transparent;
            this.pokemonLabel.Location = new System.Drawing.Point(403, 379);
            this.pokemonLabel.Name = "pokemonLabel";
            this.pokemonLabel.Size = new System.Drawing.Size(121, 25);
            this.pokemonLabel.TabIndex = 0;
            this.pokemonLabel.Text = "View All Pokemon";
            this.pokemonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pokemonLabel.Click += new System.EventHandler(this.pokemonLabel_Click);
            // 
            // sortLabel
            // 
            this.sortLabel.BackColor = System.Drawing.Color.Transparent;
            this.sortLabel.Location = new System.Drawing.Point(403, 428);
            this.sortLabel.Name = "sortLabel";
            this.sortLabel.Size = new System.Drawing.Size(121, 25);
            this.sortLabel.TabIndex = 1;
            this.sortLabel.Text = "Search the Pokedex";
            this.sortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.sortLabel.Click += new System.EventHandler(this.sortLabel_Click);
            // 
            // toolLabel
            // 
            this.toolLabel.BackColor = System.Drawing.Color.Transparent;
            this.toolLabel.Location = new System.Drawing.Point(403, 481);
            this.toolLabel.Name = "toolLabel";
            this.toolLabel.Size = new System.Drawing.Size(121, 25);
            this.toolLabel.TabIndex = 2;
            this.toolLabel.Text = "Tools / Extras";
            this.toolLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolLabel.Click += new System.EventHandler(this.toolLabel_Click);
            // 
            // pokemonListBox
            // 
            this.pokemonListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pokemonListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pokemonListBox.ForeColor = System.Drawing.Color.White;
            this.pokemonListBox.FormattingEnabled = true;
            this.pokemonListBox.Location = new System.Drawing.Point(356, 392);
            this.pokemonListBox.Name = "pokemonListBox";
            this.pokemonListBox.Size = new System.Drawing.Size(215, 117);
            this.pokemonListBox.TabIndex = 3;
            this.pokemonListBox.Visible = false;
            this.pokemonListBox.SelectedIndexChanged += new System.EventHandler(this.pokemonListBox_SelectedIndexChanged);
            this.pokemonListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pokemonListBox_KeyDown);
            // 
            // previewPictureBox
            // 
            this.previewPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.previewPictureBox.Location = new System.Drawing.Point(394, 151);
            this.previewPictureBox.Name = "previewPictureBox";
            this.previewPictureBox.Size = new System.Drawing.Size(147, 107);
            this.previewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPictureBox.TabIndex = 4;
            this.previewPictureBox.TabStop = false;
            // 
            // closePictureBox
            // 
            this.closePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.closePictureBox.Location = new System.Drawing.Point(347, 361);
            this.closePictureBox.Name = "closePictureBox";
            this.closePictureBox.Size = new System.Drawing.Size(18, 16);
            this.closePictureBox.TabIndex = 5;
            this.closePictureBox.TabStop = false;
            this.closePictureBox.Click += new System.EventHandler(this.closePictureBox_Click);
            // 
            // exitPictureBox
            // 
            this.exitPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.exitPictureBox.Location = new System.Drawing.Point(615, 529);
            this.exitPictureBox.Name = "exitPictureBox";
            this.exitPictureBox.Size = new System.Drawing.Size(64, 24);
            this.exitPictureBox.TabIndex = 7;
            this.exitPictureBox.TabStop = false;
            this.exitPictureBox.Click += new System.EventHandler(this.exitPictureBox_Click);
            // 
            // joystickPictureBox
            // 
            this.joystickPictureBox.Image = global::Pokedex.Properties.Resources.center;
            this.joystickPictureBox.Location = new System.Drawing.Point(205, 341);
            this.joystickPictureBox.Name = "joystickPictureBox";
            this.joystickPictureBox.Size = new System.Drawing.Size(111, 117);
            this.joystickPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.joystickPictureBox.TabIndex = 8;
            this.joystickPictureBox.TabStop = false;
            // 
            // statPictureBox
            // 
            this.statPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.statPictureBox.Location = new System.Drawing.Point(386, 151);
            this.statPictureBox.Name = "statPictureBox";
            this.statPictureBox.Size = new System.Drawing.Size(143, 128);
            this.statPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.statPictureBox.TabIndex = 9;
            this.statPictureBox.TabStop = false;
            this.statPictureBox.Visible = false;
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.BackColor = System.Drawing.Color.Transparent;
            this.typeLabel.ForeColor = System.Drawing.Color.White;
            this.typeLabel.Location = new System.Drawing.Point(403, 392);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(13, 13);
            this.typeLabel.TabIndex = 10;
            this.typeLabel.Text = "- ";
            this.typeLabel.Visible = false;
            // 
            // type2Label
            // 
            this.type2Label.AutoSize = true;
            this.type2Label.BackColor = System.Drawing.Color.Transparent;
            this.type2Label.ForeColor = System.Drawing.Color.White;
            this.type2Label.Location = new System.Drawing.Point(404, 405);
            this.type2Label.Name = "type2Label";
            this.type2Label.Size = new System.Drawing.Size(13, 13);
            this.type2Label.TabIndex = 11;
            this.type2Label.Text = "- ";
            this.type2Label.Visible = false;
            // 
            // hpLabel
            // 
            this.hpLabel.AutoSize = true;
            this.hpLabel.BackColor = System.Drawing.Color.Transparent;
            this.hpLabel.ForeColor = System.Drawing.Color.White;
            this.hpLabel.Location = new System.Drawing.Point(377, 415);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(13, 13);
            this.hpLabel.TabIndex = 12;
            this.hpLabel.Text = "- ";
            this.hpLabel.Visible = false;
            // 
            // attackLabel
            // 
            this.attackLabel.AutoSize = true;
            this.attackLabel.BackColor = System.Drawing.Color.Transparent;
            this.attackLabel.ForeColor = System.Drawing.Color.White;
            this.attackLabel.Location = new System.Drawing.Point(403, 425);
            this.attackLabel.Name = "attackLabel";
            this.attackLabel.Size = new System.Drawing.Size(13, 13);
            this.attackLabel.TabIndex = 13;
            this.attackLabel.Text = "- ";
            this.attackLabel.Visible = false;
            // 
            // defenseLabel
            // 
            this.defenseLabel.AutoSize = true;
            this.defenseLabel.BackColor = System.Drawing.Color.Transparent;
            this.defenseLabel.ForeColor = System.Drawing.Color.White;
            this.defenseLabel.Location = new System.Drawing.Point(408, 438);
            this.defenseLabel.Name = "defenseLabel";
            this.defenseLabel.Size = new System.Drawing.Size(13, 13);
            this.defenseLabel.TabIndex = 14;
            this.defenseLabel.Text = "- ";
            this.defenseLabel.Visible = false;
            // 
            // spaAttackLabel
            // 
            this.spaAttackLabel.AutoSize = true;
            this.spaAttackLabel.BackColor = System.Drawing.Color.Transparent;
            this.spaAttackLabel.ForeColor = System.Drawing.Color.White;
            this.spaAttackLabel.Location = new System.Drawing.Point(422, 450);
            this.spaAttackLabel.Name = "spaAttackLabel";
            this.spaAttackLabel.Size = new System.Drawing.Size(13, 13);
            this.spaAttackLabel.TabIndex = 15;
            this.spaAttackLabel.Text = "- ";
            this.spaAttackLabel.Visible = false;
            // 
            // spDefenseLabel
            // 
            this.spDefenseLabel.AutoSize = true;
            this.spDefenseLabel.BackColor = System.Drawing.Color.Transparent;
            this.spDefenseLabel.ForeColor = System.Drawing.Color.White;
            this.spDefenseLabel.Location = new System.Drawing.Point(402, 460);
            this.spDefenseLabel.Name = "spDefenseLabel";
            this.spDefenseLabel.Size = new System.Drawing.Size(13, 13);
            this.spDefenseLabel.TabIndex = 16;
            this.spDefenseLabel.Text = "- ";
            this.spDefenseLabel.Visible = false;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.BackColor = System.Drawing.Color.Transparent;
            this.speedLabel.ForeColor = System.Drawing.Color.White;
            this.speedLabel.Location = new System.Drawing.Point(397, 471);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(13, 13);
            this.speedLabel.TabIndex = 17;
            this.speedLabel.Text = "- ";
            this.speedLabel.Visible = false;
            // 
            // evolveLabel
            // 
            this.evolveLabel.AutoSize = true;
            this.evolveLabel.BackColor = System.Drawing.Color.Transparent;
            this.evolveLabel.ForeColor = System.Drawing.Color.White;
            this.evolveLabel.Location = new System.Drawing.Point(440, 483);
            this.evolveLabel.Name = "evolveLabel";
            this.evolveLabel.Size = new System.Drawing.Size(13, 13);
            this.evolveLabel.TabIndex = 18;
            this.evolveLabel.Text = "- ";
            this.evolveLabel.Visible = false;
            this.evolveLabel.Click += new System.EventHandler(this.evolveLabel_Click);
            // 
            // nameLabel
            // 
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.ForeColor = System.Drawing.Color.White;
            this.nameLabel.Location = new System.Drawing.Point(317, 112);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(294, 33);
            this.nameLabel.TabIndex = 19;
            this.nameLabel.Text = "Pokemon Name ";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aPictureBox
            // 
            this.aPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.aPictureBox.Location = new System.Drawing.Point(682, 396);
            this.aPictureBox.Name = "aPictureBox";
            this.aPictureBox.Size = new System.Drawing.Size(29, 29);
            this.aPictureBox.TabIndex = 20;
            this.aPictureBox.TabStop = false;
            this.aPictureBox.Click += new System.EventHandler(this.aPictureBox_Click);
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.loadingPictureBox.Image = global::Pokedex.Properties.Resources.loading1;
            this.loadingPictureBox.Location = new System.Drawing.Point(410, 159);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(101, 101);
            this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.loadingPictureBox.TabIndex = 21;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // xPictureBox
            // 
            this.xPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.xPictureBox.Location = new System.Drawing.Point(653, 365);
            this.xPictureBox.Name = "xPictureBox";
            this.xPictureBox.Size = new System.Drawing.Size(25, 27);
            this.xPictureBox.TabIndex = 22;
            this.xPictureBox.TabStop = false;
            this.xPictureBox.Click += new System.EventHandler(this.xPictureBox_Click);
            // 
            // yPictureBox
            // 
            this.yPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.yPictureBox.Location = new System.Drawing.Point(623, 396);
            this.yPictureBox.Name = "yPictureBox";
            this.yPictureBox.Size = new System.Drawing.Size(25, 27);
            this.yPictureBox.TabIndex = 23;
            this.yPictureBox.TabStop = false;
            this.yPictureBox.Click += new System.EventHandler(this.yPictureBox_Click);
            // 
            // bPictureBox
            // 
            this.bPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.bPictureBox.Location = new System.Drawing.Point(654, 425);
            this.bPictureBox.Name = "bPictureBox";
            this.bPictureBox.Size = new System.Drawing.Size(25, 27);
            this.bPictureBox.TabIndex = 24;
            this.bPictureBox.TabStop = false;
            this.bPictureBox.Click += new System.EventHandler(this.bPictureBox_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(371, 358);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(200, 20);
            this.searchTextBox.TabIndex = 25;
            this.searchTextBox.Visible = false;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.Click += new System.EventHandler(this.searchTextBox_Click);
            // 
            // aboutLabel
            // 
            this.aboutLabel.BackColor = System.Drawing.Color.Transparent;
            this.aboutLabel.Location = new System.Drawing.Point(402, 381);
            this.aboutLabel.Name = "aboutLabel";
            this.aboutLabel.Size = new System.Drawing.Size(121, 25);
            this.aboutLabel.TabIndex = 26;
            this.aboutLabel.Text = "About";
            this.aboutLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.aboutLabel.Visible = false;
            this.aboutLabel.Click += new System.EventHandler(this.aboutLabel_Click);
            // 
            // extraLabel
            // 
            this.extraLabel.BackColor = System.Drawing.Color.Transparent;
            this.extraLabel.Location = new System.Drawing.Point(404, 428);
            this.extraLabel.Name = "extraLabel";
            this.extraLabel.Size = new System.Drawing.Size(121, 25);
            this.extraLabel.TabIndex = 27;
            this.extraLabel.Text = "Data Grid View";
            this.extraLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.extraLabel.Visible = false;
            this.extraLabel.Click += new System.EventHandler(this.extraLabel_Click);
            // 
            // backLabel
            // 
            this.backLabel.BackColor = System.Drawing.Color.Transparent;
            this.backLabel.Location = new System.Drawing.Point(402, 481);
            this.backLabel.Name = "backLabel";
            this.backLabel.Size = new System.Drawing.Size(121, 25);
            this.backLabel.TabIndex = 28;
            this.backLabel.Text = "Back";
            this.backLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backLabel.Visible = false;
            this.backLabel.Click += new System.EventHandler(this.backLabel_Click);
            // 
            // pictureBoxType1
            // 
            this.pictureBoxType1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxType1.Location = new System.Drawing.Point(403, 390);
            this.pictureBoxType1.Name = "pictureBoxType1";
            this.pictureBoxType1.Size = new System.Drawing.Size(56, 14);
            this.pictureBoxType1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxType1.TabIndex = 29;
            this.pictureBoxType1.TabStop = false;
            this.pictureBoxType1.Visible = false;
            // 
            // pictureBoxType2
            // 
            this.pictureBoxType2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxType2.Location = new System.Drawing.Point(403, 405);
            this.pictureBoxType2.Name = "pictureBoxType2";
            this.pictureBoxType2.Size = new System.Drawing.Size(56, 14);
            this.pictureBoxType2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxType2.TabIndex = 30;
            this.pictureBoxType2.TabStop = false;
            this.pictureBoxType2.Visible = false;
            // 
            // pokemonDataGridView
            // 
            this.pokemonDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pokemonDataGridView.Location = new System.Drawing.Point(315, 113);
            this.pokemonDataGridView.Name = "pokemonDataGridView";
            this.pokemonDataGridView.Size = new System.Drawing.Size(299, 167);
            this.pokemonDataGridView.TabIndex = 31;
            this.pokemonDataGridView.Visible = false;
            // 
            // backPictureBox
            // 
            this.backPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.backPictureBox.Location = new System.Drawing.Point(394, 425);
            this.backPictureBox.Name = "backPictureBox";
            this.backPictureBox.Size = new System.Drawing.Size(141, 32);
            this.backPictureBox.TabIndex = 32;
            this.backPictureBox.TabStop = false;
            this.backPictureBox.Visible = false;
            this.backPictureBox.Click += new System.EventHandler(this.backPictureBox_Click);
            // 
            // pokemonBackgroundWorker
            // 
            this.pokemonBackgroundWorker.WorkerReportsProgress = true;
            this.pokemonBackgroundWorker.WorkerSupportsCancellation = true;
            this.pokemonBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.pokemonBackgroundWorker_DoWork);
            this.pokemonBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.pokemonBackgroundWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.BackgroundImage = global::Pokedex.Properties.Resources.MainScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(892, 617);
            this.Controls.Add(this.backPictureBox);
            this.Controls.Add(this.pokemonDataGridView);
            this.Controls.Add(this.pictureBoxType2);
            this.Controls.Add(this.pictureBoxType1);
            this.Controls.Add(this.backLabel);
            this.Controls.Add(this.extraLabel);
            this.Controls.Add(this.aboutLabel);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.bPictureBox);
            this.Controls.Add(this.yPictureBox);
            this.Controls.Add(this.xPictureBox);
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.aPictureBox);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.evolveLabel);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.spDefenseLabel);
            this.Controls.Add(this.spaAttackLabel);
            this.Controls.Add(this.defenseLabel);
            this.Controls.Add(this.attackLabel);
            this.Controls.Add(this.hpLabel);
            this.Controls.Add(this.type2Label);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.statPictureBox);
            this.Controls.Add(this.joystickPictureBox);
            this.Controls.Add(this.exitPictureBox);
            this.Controls.Add(this.closePictureBox);
            this.Controls.Add(this.previewPictureBox);
            this.Controls.Add(this.pokemonListBox);
            this.Controls.Add(this.toolLabel);
            this.Controls.Add(this.sortLabel);
            this.Controls.Add(this.pokemonLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pokedex";
            this.TransparencyKey = System.Drawing.Color.DeepSkyBlue;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.previewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.closePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exitPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.joystickPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxType2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pokemonDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label pokemonLabel;
        private System.Windows.Forms.Label sortLabel;
        private System.Windows.Forms.Label toolLabel;
        private System.Windows.Forms.ListBox pokemonListBox;
        private System.Windows.Forms.PictureBox previewPictureBox;
        private System.Windows.Forms.PictureBox closePictureBox;
        private System.Windows.Forms.PictureBox exitPictureBox;
        private System.Windows.Forms.PictureBox joystickPictureBox;
        private System.Windows.Forms.PictureBox statPictureBox;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.Label type2Label;
        private System.Windows.Forms.Label hpLabel;
        private System.Windows.Forms.Label attackLabel;
        private System.Windows.Forms.Label defenseLabel;
        private System.Windows.Forms.Label spaAttackLabel;
        private System.Windows.Forms.Label spDefenseLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label evolveLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.PictureBox aPictureBox;
        private System.Windows.Forms.PictureBox loadingPictureBox;
        private System.Windows.Forms.PictureBox xPictureBox;
        private System.Windows.Forms.PictureBox yPictureBox;
        private System.Windows.Forms.PictureBox bPictureBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Label aboutLabel;
        private System.Windows.Forms.Label extraLabel;
        private System.Windows.Forms.Label backLabel;
        private System.Windows.Forms.PictureBox pictureBoxType1;
        private System.Windows.Forms.PictureBox pictureBoxType2;
        private System.Windows.Forms.DataGridView pokemonDataGridView;
        private System.Windows.Forms.PictureBox backPictureBox;
        private System.ComponentModel.BackgroundWorker pokemonBackgroundWorker;

    }
}

