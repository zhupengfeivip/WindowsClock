namespace WindowsClock
{
    partial class PanelDay
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelSolar = new System.Windows.Forms.Label();
            this.labelLunar = new System.Windows.Forms.Label();
            this.labelTerms = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSolar
            // 
            this.labelSolar.AutoSize = true;
            this.labelSolar.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelSolar.Location = new System.Drawing.Point(17, 2);
            this.labelSolar.Name = "labelSolar";
            this.labelSolar.Size = new System.Drawing.Size(20, 20);
            this.labelSolar.TabIndex = 0;
            this.labelSolar.Text = "1";
            // 
            // labelLunar
            // 
            this.labelLunar.AutoSize = true;
            this.labelLunar.Location = new System.Drawing.Point(13, 28);
            this.labelLunar.Name = "labelLunar";
            this.labelLunar.Size = new System.Drawing.Size(29, 12);
            this.labelLunar.TabIndex = 1;
            this.labelLunar.Text = "初一";
            // 
            // labelTerms
            // 
            this.labelTerms.AutoSize = true;
            this.labelTerms.Location = new System.Drawing.Point(24, 43);
            this.labelTerms.Name = "labelTerms";
            this.labelTerms.Size = new System.Drawing.Size(29, 12);
            this.labelTerms.TabIndex = 2;
            this.labelTerms.Text = "初一";
            // 
            // PanelDay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.labelTerms);
            this.Controls.Add(this.labelLunar);
            this.Controls.Add(this.labelSolar);
            this.Name = "PanelDay";
            this.Size = new System.Drawing.Size(56, 52);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSolar;
        private System.Windows.Forms.Label labelLunar;
        private System.Windows.Forms.Label labelTerms;
    }
}
