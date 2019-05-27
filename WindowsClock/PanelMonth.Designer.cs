namespace WindowsClock
{
    partial class PanelMonth
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
            this.panelSearch = new System.Windows.Forms.Panel();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.panelWeek = new System.Windows.Forms.Panel();
            this.panelWall = new System.Windows.Forms.Panel();
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSearch
            // 
            this.panelSearch.Controls.Add(this.dateTimePicker);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearch.Location = new System.Drawing.Point(0, 0);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(392, 27);
            this.panelSearch.TabIndex = 0;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(15, 3);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker.TabIndex = 0;
            // 
            // panelWeek
            // 
            this.panelWeek.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelWeek.Location = new System.Drawing.Point(0, 27);
            this.panelWeek.Name = "panelWeek";
            this.panelWeek.Size = new System.Drawing.Size(392, 25);
            this.panelWeek.TabIndex = 1;
            // 
            // panelWall
            // 
            this.panelWall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelWall.Location = new System.Drawing.Point(0, 52);
            this.panelWall.Name = "panelWall";
            this.panelWall.Size = new System.Drawing.Size(392, 365);
            this.panelWall.TabIndex = 2;
            // 
            // PanelMonth
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelWall);
            this.Controls.Add(this.panelWeek);
            this.Controls.Add(this.panelSearch);
            this.Name = "PanelMonth";
            this.Size = new System.Drawing.Size(392, 417);
            this.panelSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSearch;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.Panel panelWeek;
        private System.Windows.Forms.Panel panelWall;
    }
}
