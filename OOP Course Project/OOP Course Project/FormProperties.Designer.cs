namespace OOP_Course_Project
{
    partial class FormProperties
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
            this.TypeOfShape = new System.Windows.Forms.Label();
            this.Properties1 = new System.Windows.Forms.Label();
            this.Properties2 = new System.Windows.Forms.Label();
            this.Property1TextBox = new System.Windows.Forms.TextBox();
            this.Property2TextBox = new System.Windows.Forms.TextBox();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.Visualizer = new System.Windows.Forms.CheckBox();
            this.AdditionalInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.ColorGridButton = new System.Windows.Forms.Button();
            this.ColorFillButton = new System.Windows.Forms.Button();
            this.labelThickness = new System.Windows.Forms.Label();
            this.numericUpDownThickness = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).BeginInit();
            this.SuspendLayout();
            // 
            // TypeOfShape
            // 
            this.TypeOfShape.AutoSize = true;
            this.TypeOfShape.Location = new System.Drawing.Point(58, 24);
            this.TypeOfShape.Name = "TypeOfShape";
            this.TypeOfShape.Size = new System.Drawing.Size(49, 17);
            this.TypeOfShape.TabIndex = 0;
            this.TypeOfShape.Text = "Shape";
            // 
            // Properties1
            // 
            this.Properties1.AutoSize = true;
            this.Properties1.Location = new System.Drawing.Point(58, 93);
            this.Properties1.Name = "Properties1";
            this.Properties1.Size = new System.Drawing.Size(62, 17);
            this.Properties1.TabIndex = 1;
            this.Properties1.Text = "Property";
            // 
            // Properties2
            // 
            this.Properties2.AutoSize = true;
            this.Properties2.Location = new System.Drawing.Point(58, 183);
            this.Properties2.Name = "Properties2";
            this.Properties2.Size = new System.Drawing.Size(62, 17);
            this.Properties2.TabIndex = 2;
            this.Properties2.Text = "Property";
            // 
            // Property1TextBox
            // 
            this.Property1TextBox.Location = new System.Drawing.Point(61, 113);
            this.Property1TextBox.Name = "Property1TextBox";
            this.Property1TextBox.Size = new System.Drawing.Size(100, 22);
            this.Property1TextBox.TabIndex = 5;
            this.Property1TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Property2TextBox_KeyPress);
            // 
            // Property2TextBox
            // 
            this.Property2TextBox.Location = new System.Drawing.Point(61, 203);
            this.Property2TextBox.Name = "Property2TextBox";
            this.Property2TextBox.Size = new System.Drawing.Size(100, 22);
            this.Property2TextBox.TabIndex = 6;
            this.Property2TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Property2TextBox_KeyPress);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(497, 511);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(95, 26);
            this.buttonCancle.TabIndex = 10;
            this.buttonCancle.Text = "Cancle";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.ButtonCancle_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(752, 511);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(93, 26);
            this.buttonOK.TabIndex = 11;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // Visualizer
            // 
            this.Visualizer.AutoSize = true;
            this.Visualizer.Checked = true;
            this.Visualizer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Visualizer.Location = new System.Drawing.Point(593, 24);
            this.Visualizer.Name = "Visualizer";
            this.Visualizer.Size = new System.Drawing.Size(129, 21);
            this.Visualizer.TabIndex = 12;
            this.Visualizer.Text = "Visualize shape";
            this.Visualizer.UseVisualStyleBackColor = true;
            this.Visualizer.CheckedChanged += new System.EventHandler(this.Visualizer_CheckedChanged);
            // 
            // AdditionalInfoTextBox
            // 
            this.AdditionalInfoTextBox.Cursor = System.Windows.Forms.Cursors.No;
            this.AdditionalInfoTextBox.Location = new System.Drawing.Point(32, 281);
            this.AdditionalInfoTextBox.Name = "AdditionalInfoTextBox";
            this.AdditionalInfoTextBox.ReadOnly = true;
            this.AdditionalInfoTextBox.Size = new System.Drawing.Size(293, 163);
            this.AdditionalInfoTextBox.TabIndex = 13;
            this.AdditionalInfoTextBox.Text = "";
            // 
            // ColorGridButton
            // 
            this.ColorGridButton.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.ColorGridButton.Location = new System.Drawing.Point(32, 499);
            this.ColorGridButton.Name = "ColorGridButton";
            this.ColorGridButton.Size = new System.Drawing.Size(96, 23);
            this.ColorGridButton.TabIndex = 14;
            this.ColorGridButton.Text = "ColorGrid";
            this.ColorGridButton.UseVisualStyleBackColor = true;
            this.ColorGridButton.Click += new System.EventHandler(this.ColorFillButton_Click_1);
            // 
            // ColorFillButton
            // 
            this.ColorFillButton.Location = new System.Drawing.Point(153, 499);
            this.ColorFillButton.Name = "ColorFillButton";
            this.ColorFillButton.Size = new System.Drawing.Size(96, 23);
            this.ColorFillButton.TabIndex = 15;
            this.ColorFillButton.Text = "ColorFill";
            this.ColorFillButton.UseVisualStyleBackColor = true;
            this.ColorFillButton.Click += new System.EventHandler(this.ColorFillButton_Click_1);
            // 
            // labelThickness
            // 
            this.labelThickness.AutoSize = true;
            this.labelThickness.Location = new System.Drawing.Point(288, 480);
            this.labelThickness.Name = "labelThickness";
            this.labelThickness.Size = new System.Drawing.Size(72, 17);
            this.labelThickness.TabIndex = 16;
            this.labelThickness.Text = "Thickness";
            // 
            // numericUpDownThickness
            // 
            this.numericUpDownThickness.Location = new System.Drawing.Point(291, 499);
            this.numericUpDownThickness.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownThickness.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThickness.Name = "numericUpDownThickness";
            this.numericUpDownThickness.ReadOnly = true;
            this.numericUpDownThickness.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownThickness.TabIndex = 18;
            this.numericUpDownThickness.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThickness.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // FormProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 610);
            this.Controls.Add(this.numericUpDownThickness);
            this.Controls.Add(this.labelThickness);
            this.Controls.Add(this.ColorFillButton);
            this.Controls.Add(this.ColorGridButton);
            this.Controls.Add(this.AdditionalInfoTextBox);
            this.Controls.Add(this.Visualizer);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.Property2TextBox);
            this.Controls.Add(this.Property1TextBox);
            this.Controls.Add(this.Properties2);
            this.Controls.Add(this.Properties1);
            this.Controls.Add(this.TypeOfShape);
            this.Name = "FormProperties";
            this.Text = "FormProperties";
            this.Load += new System.EventHandler(this.FormProperties_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThickness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TypeOfShape;
        private System.Windows.Forms.Label Properties1;
        private System.Windows.Forms.Label Properties2;
        private System.Windows.Forms.TextBox Property1TextBox;
        private System.Windows.Forms.TextBox Property2TextBox;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox Visualizer;
        private System.Windows.Forms.RichTextBox AdditionalInfoTextBox;
        private System.Windows.Forms.Button ColorGridButton;
        private System.Windows.Forms.Button ColorFillButton;
        private System.Windows.Forms.Label labelThickness;
        private System.Windows.Forms.NumericUpDown numericUpDownThickness;
    }
}