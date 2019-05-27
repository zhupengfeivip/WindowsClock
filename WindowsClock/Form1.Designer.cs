namespace WindowsClock
{
    partial class Form1
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
            this.panelMonth1 = new WindowsClock.PanelMonth();
            this.SuspendLayout();
            // 
            // panelMonth1
            // 
            this.panelMonth1.Datetime = new System.DateTime(2019, 5, 24, 8, 34, 43, 842);
            this.panelMonth1.Location = new System.Drawing.Point(36, 31);
            this.panelMonth1.Name = "panelMonth1";
            this.panelMonth1.Size = new System.Drawing.Size(551, 503);
            this.panelMonth1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 605);
            this.Controls.Add(this.panelMonth1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private PanelMonth panelMonth1;
    }
}