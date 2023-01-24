namespace OOP_Course_Project
{
    partial class FormSelectBy
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
            this.listBoxInformation = new System.Windows.Forms.ListBox();
            this.buttonSelection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxInformation
            // 
            this.listBoxInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxInformation.FormattingEnabled = true;
            this.listBoxInformation.ItemHeight = 16;
            this.listBoxInformation.Location = new System.Drawing.Point(0, 0);
            this.listBoxInformation.Name = "listBoxInformation";
            this.listBoxInformation.Size = new System.Drawing.Size(447, 336);
            this.listBoxInformation.TabIndex = 0;
            this.listBoxInformation.Click += new System.EventHandler(this.ListBoxInformation_Click);
            // 
            // buttonSelection
            // 
            this.buttonSelection.Location = new System.Drawing.Point(314, 268);
            this.buttonSelection.Name = "buttonSelection";
            this.buttonSelection.Size = new System.Drawing.Size(121, 56);
            this.buttonSelection.TabIndex = 1;
            this.buttonSelection.Text = "Select on Scene";
            this.buttonSelection.UseVisualStyleBackColor = true;
            this.buttonSelection.Visible = false;
            this.buttonSelection.Click += new System.EventHandler(this.ButtonSelection_Click);
            // 
            // FormSelectBy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 336);
            this.Controls.Add(this.buttonSelection);
            this.Controls.Add(this.listBoxInformation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSelectBy";
            this.Text = "Statistics";
            this.Load += new System.EventHandler(this.FormSelectBy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxInformation;
        private System.Windows.Forms.Button buttonSelection;
    }
}