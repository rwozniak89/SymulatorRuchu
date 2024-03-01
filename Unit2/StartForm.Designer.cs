namespace Unit2
{
    partial class StartForm
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
            this.components = new System.ComponentModel.Container();
            this._PictureBox = new System.Windows.Forms.PictureBox();
            this._TurnLeftLargeButton = new System.Windows.Forms.Button();
            this._TurnRightLargeButton = new System.Windows.Forms.Button();
            this._StopButton = new System.Windows.Forms.Button();
            this._SpeedPlusPlusButton = new System.Windows.Forms.Button();
            this._SpeedMinusMinusButton = new System.Windows.Forms.Button();
            this._SpeedPlusButton = new System.Windows.Forms.Button();
            this._SpeedMinusButton = new System.Windows.Forms.Button();
            this._TurnRightSmallButton = new System.Windows.Forms.Button();
            this._TurnLeftSmallButton = new System.Windows.Forms.Button();
            this._TurningControlGroupBox = new System.Windows.Forms.GroupBox();
            this.@__SpeedControlGroupBox = new System.Windows.Forms.GroupBox();
            this._VehiclesDataGridView = new System.Windows.Forms.DataGridView();
            this.NameOf = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Course = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._FocusedVehicleGroupBox = new System.Windows.Forms.GroupBox();
            this._PropertyGrid = new System.Windows.Forms.PropertyGrid();
            this._SplitContainer = new System.Windows.Forms.SplitContainer();
            this._AddTrain_Button = new System.Windows.Forms.Button();
            this._Copy_Button = new System.Windows.Forms.Button();
            this._RemoveSelected_Button = new System.Windows.Forms.Button();
            this._AddByGeneration_Button = new System.Windows.Forms.Button();
            this._AddBike_Button = new System.Windows.Forms.Button();
            this._AddCar_Button = new System.Windows.Forms.Button();
            this._AddAircraft_Button = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.plikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Save_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._Close_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vehicleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._XUCVehicle = new Unit2.XUCVehicle();
            this.vehicleBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.vehicleBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox)).BeginInit();
            this._TurningControlGroupBox.SuspendLayout();
            this.@__SpeedControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._VehiclesDataGridView)).BeginInit();
            this._FocusedVehicleGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainer)).BeginInit();
            this._SplitContainer.Panel1.SuspendLayout();
            this._SplitContainer.Panel2.SuspendLayout();
            this._SplitContainer.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // _PictureBox
            // 
            this._PictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._PictureBox.Location = new System.Drawing.Point(12, 25);
            this._PictureBox.Name = "_PictureBox";
            this._PictureBox.Size = new System.Drawing.Size(839, 637);
            this._PictureBox.TabIndex = 0;
            this._PictureBox.TabStop = false;
            this._PictureBox.SizeChanged += new System.EventHandler(this._PictureBox_SizeChanged);
            // 
            // _TurnLeftLargeButton
            // 
            this._TurnLeftLargeButton.Location = new System.Drawing.Point(9, 19);
            this._TurnLeftLargeButton.Name = "_TurnLeftLargeButton";
            this._TurnLeftLargeButton.Size = new System.Drawing.Size(58, 23);
            this._TurnLeftLargeButton.TabIndex = 1;
            this._TurnLeftLargeButton.Text = "<<=";
            this._TurnLeftLargeButton.UseVisualStyleBackColor = true;
            this._TurnLeftLargeButton.Click += new System.EventHandler(this._TurnLeftButton_Click);
            // 
            // _TurnRightLargeButton
            // 
            this._TurnRightLargeButton.Location = new System.Drawing.Point(73, 19);
            this._TurnRightLargeButton.Name = "_TurnRightLargeButton";
            this._TurnRightLargeButton.Size = new System.Drawing.Size(58, 23);
            this._TurnRightLargeButton.TabIndex = 2;
            this._TurnRightLargeButton.Text = "=>>";
            this._TurnRightLargeButton.UseVisualStyleBackColor = true;
            this._TurnRightLargeButton.Click += new System.EventHandler(this._TurnRightButton_Click);
            // 
            // _StopButton
            // 
            this._StopButton.Location = new System.Drawing.Point(6, 19);
            this._StopButton.Name = "_StopButton";
            this._StopButton.Size = new System.Drawing.Size(58, 23);
            this._StopButton.TabIndex = 3;
            this._StopButton.Text = "Stop";
            this._StopButton.UseVisualStyleBackColor = true;
            this._StopButton.Click += new System.EventHandler(this._StopButton_Click);
            // 
            // _SpeedPlusPlusButton
            // 
            this._SpeedPlusPlusButton.Location = new System.Drawing.Point(70, 19);
            this._SpeedPlusPlusButton.Name = "_SpeedPlusPlusButton";
            this._SpeedPlusPlusButton.Size = new System.Drawing.Size(58, 23);
            this._SpeedPlusPlusButton.TabIndex = 4;
            this._SpeedPlusPlusButton.Text = "++";
            this._SpeedPlusPlusButton.UseVisualStyleBackColor = true;
            this._SpeedPlusPlusButton.Click += new System.EventHandler(this._SpeedPlusPlusButton_Click);
            // 
            // _SpeedMinusMinusButton
            // 
            this._SpeedMinusMinusButton.Location = new System.Drawing.Point(136, 19);
            this._SpeedMinusMinusButton.Name = "_SpeedMinusMinusButton";
            this._SpeedMinusMinusButton.Size = new System.Drawing.Size(58, 23);
            this._SpeedMinusMinusButton.TabIndex = 5;
            this._SpeedMinusMinusButton.Text = "- -";
            this._SpeedMinusMinusButton.UseVisualStyleBackColor = true;
            this._SpeedMinusMinusButton.Click += new System.EventHandler(this._SpeedMinusMinusButton_Click);
            // 
            // _SpeedPlusButton
            // 
            this._SpeedPlusButton.Location = new System.Drawing.Point(70, 48);
            this._SpeedPlusButton.Name = "_SpeedPlusButton";
            this._SpeedPlusButton.Size = new System.Drawing.Size(58, 23);
            this._SpeedPlusButton.TabIndex = 6;
            this._SpeedPlusButton.Text = "+";
            this._SpeedPlusButton.UseVisualStyleBackColor = true;
            this._SpeedPlusButton.Click += new System.EventHandler(this._SpeedPlusButton_Click);
            // 
            // _SpeedMinusButton
            // 
            this._SpeedMinusButton.Location = new System.Drawing.Point(134, 48);
            this._SpeedMinusButton.Name = "_SpeedMinusButton";
            this._SpeedMinusButton.Size = new System.Drawing.Size(58, 23);
            this._SpeedMinusButton.TabIndex = 7;
            this._SpeedMinusButton.Text = "-";
            this._SpeedMinusButton.UseVisualStyleBackColor = true;
            this._SpeedMinusButton.Click += new System.EventHandler(this._SpeedMinusButton_Click);
            // 
            // _TurnRightSmallButton
            // 
            this._TurnRightSmallButton.Location = new System.Drawing.Point(73, 48);
            this._TurnRightSmallButton.Name = "_TurnRightSmallButton";
            this._TurnRightSmallButton.Size = new System.Drawing.Size(58, 23);
            this._TurnRightSmallButton.TabIndex = 9;
            this._TurnRightSmallButton.Text = "=>";
            this._TurnRightSmallButton.UseVisualStyleBackColor = true;
            this._TurnRightSmallButton.Click += new System.EventHandler(this._TurnRightSmallButton_Click);
            // 
            // _TurnLeftSmallButton
            // 
            this._TurnLeftSmallButton.Location = new System.Drawing.Point(9, 48);
            this._TurnLeftSmallButton.Name = "_TurnLeftSmallButton";
            this._TurnLeftSmallButton.Size = new System.Drawing.Size(58, 23);
            this._TurnLeftSmallButton.TabIndex = 8;
            this._TurnLeftSmallButton.Text = "<=";
            this._TurnLeftSmallButton.UseVisualStyleBackColor = true;
            this._TurnLeftSmallButton.Click += new System.EventHandler(this._TurnLeftSmallButton_Click);
            // 
            // _TurningControlGroupBox
            // 
            this._TurningControlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._TurningControlGroupBox.Controls.Add(this._TurnRightLargeButton);
            this._TurningControlGroupBox.Controls.Add(this._TurnRightSmallButton);
            this._TurningControlGroupBox.Controls.Add(this._TurnLeftLargeButton);
            this._TurningControlGroupBox.Controls.Add(this._TurnLeftSmallButton);
            this._TurningControlGroupBox.Location = new System.Drawing.Point(6, 223);
            this._TurningControlGroupBox.Name = "_TurningControlGroupBox";
            this._TurningControlGroupBox.Size = new System.Drawing.Size(197, 88);
            this._TurningControlGroupBox.TabIndex = 10;
            this._TurningControlGroupBox.TabStop = false;
            this._TurningControlGroupBox.Text = "Kontrola kierunku";
            // 
            // __SpeedControlGroupBox
            // 
            this.@__SpeedControlGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.@__SpeedControlGroupBox.Controls.Add(this._StopButton);
            this.@__SpeedControlGroupBox.Controls.Add(this._SpeedPlusPlusButton);
            this.@__SpeedControlGroupBox.Controls.Add(this._SpeedMinusButton);
            this.@__SpeedControlGroupBox.Controls.Add(this._SpeedMinusMinusButton);
            this.@__SpeedControlGroupBox.Controls.Add(this._SpeedPlusButton);
            this.@__SpeedControlGroupBox.Location = new System.Drawing.Point(3, 129);
            this.@__SpeedControlGroupBox.Name = "__SpeedControlGroupBox";
            this.@__SpeedControlGroupBox.Size = new System.Drawing.Size(200, 88);
            this.@__SpeedControlGroupBox.TabIndex = 11;
            this.@__SpeedControlGroupBox.TabStop = false;
            this.@__SpeedControlGroupBox.Text = "Kontrola prędkości";
            // 
            // _VehiclesDataGridView
            // 
            this._VehiclesDataGridView.AutoGenerateColumns = false;
            this._VehiclesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._VehiclesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.NameOf,
            this.Course});
            this._VehiclesDataGridView.DataSource = this.vehicleBindingSource;
            this._VehiclesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this._VehiclesDataGridView.Location = new System.Drawing.Point(0, 0);
            this._VehiclesDataGridView.Name = "_VehiclesDataGridView";
            this._VehiclesDataGridView.Size = new System.Drawing.Size(449, 325);
            this._VehiclesDataGridView.TabIndex = 12;
            this._VehiclesDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this._VehiclesDataGridView_RowEnter);
            // 
            // NameOf
            // 
            this.NameOf.DataPropertyName = "NameOf";
            this.NameOf.HeaderText = "Nazwa";
            this.NameOf.Name = "NameOf";
            this.NameOf.ReadOnly = true;
            // 
            // Course
            // 
            this.Course.DataPropertyName = "Course";
            this.Course.HeaderText = "Kurs";
            this.Course.Name = "Course";
            // 
            // _FocusedVehicleGroupBox
            // 
            this._FocusedVehicleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._FocusedVehicleGroupBox.Controls.Add(this._XUCVehicle);
            this._FocusedVehicleGroupBox.Location = new System.Drawing.Point(6, 37);
            this._FocusedVehicleGroupBox.Name = "_FocusedVehicleGroupBox";
            this._FocusedVehicleGroupBox.Size = new System.Drawing.Size(119, 86);
            this._FocusedVehicleGroupBox.TabIndex = 17;
            this._FocusedVehicleGroupBox.TabStop = false;
            this._FocusedVehicleGroupBox.Text = "Wskazany pojazd";
            // 
            // _PropertyGrid
            // 
            this._PropertyGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._PropertyGrid.Location = new System.Drawing.Point(243, 8);
            this._PropertyGrid.Name = "_PropertyGrid";
            this._PropertyGrid.Size = new System.Drawing.Size(206, 297);
            this._PropertyGrid.TabIndex = 18;
            // 
            // _SplitContainer
            // 
            this._SplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._SplitContainer.Location = new System.Drawing.Point(857, 25);
            this._SplitContainer.Name = "_SplitContainer";
            this._SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // _SplitContainer.Panel1
            // 
            this._SplitContainer.Panel1.Controls.Add(this._VehiclesDataGridView);
            // 
            // _SplitContainer.Panel2
            // 
            this._SplitContainer.Panel2.Controls.Add(this._AddTrain_Button);
            this._SplitContainer.Panel2.Controls.Add(this._Copy_Button);
            this._SplitContainer.Panel2.Controls.Add(this._RemoveSelected_Button);
            this._SplitContainer.Panel2.Controls.Add(this._AddByGeneration_Button);
            this._SplitContainer.Panel2.Controls.Add(this._AddBike_Button);
            this._SplitContainer.Panel2.Controls.Add(this._AddCar_Button);
            this._SplitContainer.Panel2.Controls.Add(this._AddAircraft_Button);
            this._SplitContainer.Panel2.Controls.Add(this._FocusedVehicleGroupBox);
            this._SplitContainer.Panel2.Controls.Add(this._PropertyGrid);
            this._SplitContainer.Panel2.Controls.Add(this.@__SpeedControlGroupBox);
            this._SplitContainer.Panel2.Controls.Add(this._TurningControlGroupBox);
            this._SplitContainer.Size = new System.Drawing.Size(449, 637);
            this._SplitContainer.SplitterDistance = 325;
            this._SplitContainer.TabIndex = 19;
            // 
            // _AddTrain_Button
            // 
            this._AddTrain_Button.Location = new System.Drawing.Point(128, 65);
            this._AddTrain_Button.Name = "_AddTrain_Button";
            this._AddTrain_Button.Size = new System.Drawing.Size(106, 23);
            this._AddTrain_Button.TabIndex = 24;
            this._AddTrain_Button.Text = "Dodaj pociąg";
            this._AddTrain_Button.UseVisualStyleBackColor = true;
            this._AddTrain_Button.Click += new System.EventHandler(this._AddTrain_Button_Click);
            // 
            // _Copy_Button
            // 
            this._Copy_Button.Location = new System.Drawing.Point(131, 113);
            this._Copy_Button.Name = "_Copy_Button";
            this._Copy_Button.Size = new System.Drawing.Size(75, 23);
            this._Copy_Button.TabIndex = 22;
            this._Copy_Button.Text = "Kopiuj";
            this._Copy_Button.UseVisualStyleBackColor = true;
            this._Copy_Button.Click += new System.EventHandler(this._Copy_Button_Click);
            // 
            // _RemoveSelected_Button
            // 
            this._RemoveSelected_Button.Location = new System.Drawing.Point(9, 8);
            this._RemoveSelected_Button.Name = "_RemoveSelected_Button";
            this._RemoveSelected_Button.Size = new System.Drawing.Size(106, 23);
            this._RemoveSelected_Button.TabIndex = 23;
            this._RemoveSelected_Button.Text = "Usuń zaznaczone";
            this._RemoveSelected_Button.UseVisualStyleBackColor = true;
            this._RemoveSelected_Button.Click += new System.EventHandler(this._RemoveSelected_Button_Click);
            // 
            // _AddByGeneration_Button
            // 
            this._AddByGeneration_Button.Location = new System.Drawing.Point(131, 94);
            this._AddByGeneration_Button.Name = "_AddByGeneration_Button";
            this._AddByGeneration_Button.Size = new System.Drawing.Size(103, 23);
            this._AddByGeneration_Button.TabIndex = 22;
            this._AddByGeneration_Button.Text = "Wygeneruj";
            this._AddByGeneration_Button.UseVisualStyleBackColor = true;
            this._AddByGeneration_Button.Click += new System.EventHandler(this._AddByGeneration_Button_Click);
            // 
            // _AddBike_Button
            // 
            this._AddBike_Button.Location = new System.Drawing.Point(128, 8);
            this._AddBike_Button.Name = "_AddBike_Button";
            this._AddBike_Button.Size = new System.Drawing.Size(106, 23);
            this._AddBike_Button.TabIndex = 21;
            this._AddBike_Button.Text = "Dodaj rower";
            this._AddBike_Button.UseVisualStyleBackColor = true;
            this._AddBike_Button.Click += new System.EventHandler(this._AddBike_Button_Click);
            // 
            // _AddCar_Button
            // 
            this._AddCar_Button.Location = new System.Drawing.Point(128, 27);
            this._AddCar_Button.Name = "_AddCar_Button";
            this._AddCar_Button.Size = new System.Drawing.Size(106, 23);
            this._AddCar_Button.TabIndex = 20;
            this._AddCar_Button.Text = "Dodaj samochód";
            this._AddCar_Button.UseVisualStyleBackColor = true;
            this._AddCar_Button.Click += new System.EventHandler(this._AddCar_Button_Click);
            // 
            // _AddAircraft_Button
            // 
            this._AddAircraft_Button.Location = new System.Drawing.Point(128, 46);
            this._AddAircraft_Button.Name = "_AddAircraft_Button";
            this._AddAircraft_Button.Size = new System.Drawing.Size(103, 23);
            this._AddAircraft_Button.TabIndex = 19;
            this._AddAircraft_Button.Text = "Dodaj samolot";
            this._AddAircraft_Button.UseVisualStyleBackColor = true;
            this._AddAircraft_Button.Click += new System.EventHandler(this._AddAircraft_Button_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1318, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.plikToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1318, 24);
            this.menuStrip2.TabIndex = 21;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // plikToolStripMenuItem
            // 
            this.plikToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._Open_ToolStripMenuItem,
            this._Save_ToolStripMenuItem,
            this._Close_ToolStripMenuItem});
            this.plikToolStripMenuItem.Name = "plikToolStripMenuItem";
            this.plikToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.plikToolStripMenuItem.Text = "Plik";
            // 
            // _Open_ToolStripMenuItem
            // 
            this._Open_ToolStripMenuItem.Name = "_Open_ToolStripMenuItem";
            this._Open_ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._Open_ToolStripMenuItem.Text = "Otwórz";
            this._Open_ToolStripMenuItem.Click += new System.EventHandler(this._Open_ToolStripMenuItem_Click);
            // 
            // _Save_ToolStripMenuItem
            // 
            this._Save_ToolStripMenuItem.Name = "_Save_ToolStripMenuItem";
            this._Save_ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._Save_ToolStripMenuItem.Text = "Zapisz";
            this._Save_ToolStripMenuItem.Click += new System.EventHandler(this._Save_ToolStripMenuItem_Click);
            // 
            // _Close_ToolStripMenuItem
            // 
            this._Close_ToolStripMenuItem.Name = "_Close_ToolStripMenuItem";
            this._Close_ToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this._Close_ToolStripMenuItem.Text = "Zamknij";
            this._Close_ToolStripMenuItem.Click += new System.EventHandler(this._Close_ToolStripMenuItem_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // vehicleBindingSource
            // 
            this.vehicleBindingSource.DataSource = typeof(Unit2.Vehicle);
            // 
            // _XUCVehicle
            // 
            this._XUCVehicle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._XUCVehicle.Location = new System.Drawing.Point(6, 19);
            this._XUCVehicle.Name = "_XUCVehicle";
            this._XUCVehicle.Presentation = null;
            this._XUCVehicle.Size = new System.Drawing.Size(107, 61);
            this._XUCVehicle.TabIndex = 20;
            // 
            // vehicleBindingSource1
            // 
            this.vehicleBindingSource1.DataSource = typeof(Unit2.Vehicle);
            // 
            // vehicleBindingSource2
            // 
            this.vehicleBindingSource2.DataSource = typeof(Unit2.Vehicle);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1318, 674);
            this.Controls.Add(this._SplitContainer);
            this.Controls.Add(this._PictureBox);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StartForm";
            this.Text = "Symulator ruchu";
            ((System.ComponentModel.ISupportInitialize)(this._PictureBox)).EndInit();
            this._TurningControlGroupBox.ResumeLayout(false);
            this.@__SpeedControlGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._VehiclesDataGridView)).EndInit();
            this._FocusedVehicleGroupBox.ResumeLayout(false);
            this._SplitContainer.Panel1.ResumeLayout(false);
            this._SplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SplitContainer)).EndInit();
            this._SplitContainer.ResumeLayout(false);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vehicleBindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _PictureBox;
        private System.Windows.Forms.Button _TurnLeftLargeButton;
        private System.Windows.Forms.Button _TurnRightLargeButton;
        private System.Windows.Forms.Button _StopButton;
        private System.Windows.Forms.Button _SpeedPlusPlusButton;
        private System.Windows.Forms.Button _SpeedMinusMinusButton;
        private System.Windows.Forms.Button _SpeedPlusButton;
        private System.Windows.Forms.Button _SpeedMinusButton;
        private System.Windows.Forms.Button _TurnRightSmallButton;
        private System.Windows.Forms.Button _TurnLeftSmallButton;
        private System.Windows.Forms.GroupBox _TurningControlGroupBox;
        private System.Windows.Forms.GroupBox __SpeedControlGroupBox;
        private System.Windows.Forms.DataGridView _VehiclesDataGridView;
        private System.Windows.Forms.BindingSource vehicleBindingSource;
        private System.Windows.Forms.GroupBox _FocusedVehicleGroupBox;
        private System.Windows.Forms.PropertyGrid _PropertyGrid;
        private System.Windows.Forms.BindingSource vehicleBindingSource1;
        private System.Windows.Forms.BindingSource vehicleBindingSource2;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameOf;
        private System.Windows.Forms.DataGridViewTextBoxColumn Course;
        private System.Windows.Forms.SplitContainer _SplitContainer;
        private XUCVehicle _XUCVehicle;
        private System.Windows.Forms.Button _AddBike_Button;
        private System.Windows.Forms.Button _AddCar_Button;
        private System.Windows.Forms.Button _AddAircraft_Button;
        private System.Windows.Forms.Button _AddByGeneration_Button;
        private System.Windows.Forms.Button _RemoveSelected_Button;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem plikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _Open_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _Save_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _Close_ToolStripMenuItem;
        private System.Windows.Forms.Button _Copy_Button;
        private System.Windows.Forms.Button _AddTrain_Button;
    }
}

