namespace Unit2
{
    partial class AddVehicleForm
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
            this._Cancel_Button = new System.Windows.Forms.Button();
            this._OK_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this._Course_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._Speed_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this._Scale_MaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // _Cancel_Button
            // 
            this._Cancel_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._Cancel_Button.Location = new System.Drawing.Point(300, 271);
            this._Cancel_Button.Name = "_Cancel_Button";
            this._Cancel_Button.Size = new System.Drawing.Size(75, 23);
            this._Cancel_Button.TabIndex = 0;
            this._Cancel_Button.Text = "Anuluj";
            this._Cancel_Button.UseVisualStyleBackColor = true;
            // 
            // _OK_Button
            // 
            this._OK_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._OK_Button.Location = new System.Drawing.Point(219, 271);
            this._OK_Button.Name = "_OK_Button";
            this._OK_Button.Size = new System.Drawing.Size(75, 23);
            this._OK_Button.TabIndex = 1;
            this._OK_Button.Text = "OK";
            this._OK_Button.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kurs:";
            // 
            // _Course_MaskedTextBox
            // 
            this._Course_MaskedTextBox.Location = new System.Drawing.Point(86, 12);
            this._Course_MaskedTextBox.Mask = "000";
            this._Course_MaskedTextBox.Name = "_Course_MaskedTextBox";
            this._Course_MaskedTextBox.Size = new System.Drawing.Size(47, 20);
            this._Course_MaskedTextBox.TabIndex = 3;
            this._Course_MaskedTextBox.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Prędkość:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Skala:";
            // 
            // _Speed_MaskedTextBox
            // 
            this._Speed_MaskedTextBox.Location = new System.Drawing.Point(86, 42);
            this._Speed_MaskedTextBox.Mask = "000";
            this._Speed_MaskedTextBox.Name = "_Speed_MaskedTextBox";
            this._Speed_MaskedTextBox.Size = new System.Drawing.Size(47, 20);
            this._Speed_MaskedTextBox.TabIndex = 6;
            this._Speed_MaskedTextBox.ValidatingType = typeof(int);
            // 
            // _Scale_MaskedTextBox
            // 
            this._Scale_MaskedTextBox.Location = new System.Drawing.Point(85, 76);
            this._Scale_MaskedTextBox.Mask = "000";
            this._Scale_MaskedTextBox.Name = "_Scale_MaskedTextBox";
            this._Scale_MaskedTextBox.Size = new System.Drawing.Size(47, 20);
            this._Scale_MaskedTextBox.TabIndex = 7;
            this._Scale_MaskedTextBox.ValidatingType = typeof(int);
            // 
            // AddVehicleForm
            // 
            this.AcceptButton = this._OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._Cancel_Button;
            this.ClientSize = new System.Drawing.Size(387, 301);
            this.Controls.Add(this._Scale_MaskedTextBox);
            this.Controls.Add(this._Speed_MaskedTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._Course_MaskedTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._OK_Button);
            this.Controls.Add(this._Cancel_Button);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddVehicleForm";
            this.ShowIcon = false;
            this.Text = "Dodanie pojazdu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _Cancel_Button;
        private System.Windows.Forms.Button _OK_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox _Course_MaskedTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox _Speed_MaskedTextBox;
        private System.Windows.Forms.MaskedTextBox _Scale_MaskedTextBox;
    }
}