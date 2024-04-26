namespace MyTextEditor
{
    partial class EditorForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTexttoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newFormOpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFilelStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveOtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editortoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findNextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoMulToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findLookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFontSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filetoolStripMenuItem,
            this.editortoolStripMenuItem,
            this.formatToolStripMenuItem,
            this.findLookToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 32);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filetoolStripMenuItem
            // 
            this.filetoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTexttoolStripMenuItem,
            this.newFormToolStripMenuItem,
            this.newFormOpenToolStripMenuItem,
            this.openFilelStripMenuItem4,
            this.saveToolStripMenuItem,
            this.saveOtherToolStripMenuItem});
            this.filetoolStripMenuItem.Name = "filetoolStripMenuItem";
            this.filetoolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.filetoolStripMenuItem.Text = "文件";
            // 
            // newTexttoolStripMenuItem
            // 
            this.newTexttoolStripMenuItem.Name = "newTexttoolStripMenuItem";
            this.newTexttoolStripMenuItem.Size = new System.Drawing.Size(323, 34);
            this.newTexttoolStripMenuItem.Text = "新建(Ctrl+N)";
            // 
            // newFormToolStripMenuItem
            // 
            this.newFormToolStripMenuItem.Name = "newFormToolStripMenuItem";
            this.newFormToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
            this.newFormToolStripMenuItem.Text = "新窗口(Ctrl+M)";
            // 
            // newFormOpenToolStripMenuItem
            // 
            this.newFormOpenToolStripMenuItem.Name = "newFormOpenToolStripMenuItem";
            this.newFormOpenToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
            this.newFormOpenToolStripMenuItem.Text = "新窗口打开(Ctrl+Shift+N)";
            // 
            // openFilelStripMenuItem4
            // 
            this.openFilelStripMenuItem4.Name = "openFilelStripMenuItem4";
            this.openFilelStripMenuItem4.Size = new System.Drawing.Size(323, 34);
            this.openFilelStripMenuItem4.Text = "打开(Ctrl+O)";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
            this.saveToolStripMenuItem.Text = "保存(Ctrl+S)";
            // 
            // saveOtherToolStripMenuItem
            // 
            this.saveOtherToolStripMenuItem.Name = "saveOtherToolStripMenuItem";
            this.saveOtherToolStripMenuItem.Size = new System.Drawing.Size(323, 34);
            this.saveOtherToolStripMenuItem.Text = "另存为(Ctrl+Shift+S)";
            // 
            // editortoolStripMenuItem
            // 
            this.editortoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.allSelectToolStripMenuItem,
            this.findToolStripMenuItem,
            this.findUpToolStripMenuItem,
            this.findNextToolStripMenuItem,
            this.replaceToolStripMenuItem,
            this.dataTimeToolStripMenuItem});
            this.editortoolStripMenuItem.Name = "editortoolStripMenuItem";
            this.editortoolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.editortoolStripMenuItem.Text = "编辑";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.copyToolStripMenuItem.Text = "复制";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.pasteToolStripMenuItem.Text = "粘贴";
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.cutToolStripMenuItem.Text = "剪切";
            // 
            // allSelectToolStripMenuItem
            // 
            this.allSelectToolStripMenuItem.Name = "allSelectToolStripMenuItem";
            this.allSelectToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.allSelectToolStripMenuItem.Text = "全选";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.findToolStripMenuItem.Text = "查找(Ctrl+F)";
            // 
            // findUpToolStripMenuItem
            // 
            this.findUpToolStripMenuItem.Name = "findUpToolStripMenuItem";
            this.findUpToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.findUpToolStripMenuItem.Text = "查找上一个(Ctrl+Shif+U)";
            // 
            // findNextToolStripMenuItem
            // 
            this.findNextToolStripMenuItem.Name = "findNextToolStripMenuItem";
            this.findNextToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.findNextToolStripMenuItem.Text = "查找下一个(Ctrl+Shift+D)";
            // 
            // replaceToolStripMenuItem
            // 
            this.replaceToolStripMenuItem.Name = "replaceToolStripMenuItem";
            this.replaceToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.replaceToolStripMenuItem.Text = "替换(Ctrl+H)";
            // 
            // dataTimeToolStripMenuItem
            // 
            this.dataTimeToolStripMenuItem.Name = "dataTimeToolStripMenuItem";
            this.dataTimeToolStripMenuItem.Size = new System.Drawing.Size(322, 34);
            this.dataTimeToolStripMenuItem.Text = "时间/日期(Ctrl+D)";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoMulToolStripMenuItem,
            this.selectFontToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.formatToolStripMenuItem.Text = "格式";
            // 
            // autoMulToolStripMenuItem
            // 
            this.autoMulToolStripMenuItem.Name = "autoMulToolStripMenuItem";
            this.autoMulToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.autoMulToolStripMenuItem.Text = "自动换行(Alt+R)";
            // 
            // selectFontToolStripMenuItem
            // 
            this.selectFontToolStripMenuItem.Name = "selectFontToolStripMenuItem";
            this.selectFontToolStripMenuItem.Size = new System.Drawing.Size(244, 34);
            this.selectFontToolStripMenuItem.Text = "字体(Alt+F)";
            // 
            // findLookToolStripMenuItem
            // 
            this.findLookToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem,
            this.stateToolStripMenuItem});
            this.findLookToolStripMenuItem.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.findLookToolStripMenuItem.Name = "findLookToolStripMenuItem";
            this.findLookToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.findLookToolStripMenuItem.Text = "查看";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFontSizeToolStripMenuItem,
            this.subFontToolStripMenuItem,
            this.DefaultSizeToolStripMenuItem});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.sizeToolStripMenuItem.Text = "缩放";
            // 
            // addFontSizeToolStripMenuItem
            // 
            this.addFontSizeToolStripMenuItem.Name = "addFontSizeToolStripMenuItem";
            this.addFontSizeToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
            this.addFontSizeToolStripMenuItem.Text = "放大字号(Ctrl+1)";
            // 
            // subFontToolStripMenuItem
            // 
            this.subFontToolStripMenuItem.Name = "subFontToolStripMenuItem";
            this.subFontToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
            this.subFontToolStripMenuItem.Text = "缩小字号(Ctrl+2)";
            // 
            // DefaultSizeToolStripMenuItem
            // 
            this.DefaultSizeToolStripMenuItem.Name = "DefaultSizeToolStripMenuItem";
            this.DefaultSizeToolStripMenuItem.Size = new System.Drawing.Size(249, 34);
            this.DefaultSizeToolStripMenuItem.Text = "恢复默认(Ctrl+0)";
            // 
            // stateToolStripMenuItem
            // 
            this.stateToolStripMenuItem.Name = "stateToolStripMenuItem";
            this.stateToolStripMenuItem.Size = new System.Drawing.Size(164, 34);
            this.stateToolStripMenuItem.Text = "状态栏";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(62, 28);
            this.helpToolStripMenuItem.Text = "帮助";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(146, 34);
            this.aboutToolStripMenuItem.Text = "关于";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 420);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 30);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Location = new System.Drawing.Point(555, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(617, 0);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 26);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.HideSelection = false;
            this.textBox1.Location = new System.Drawing.Point(0, 32);
            this.textBox1.MaxLength = 3276700;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(800, 388);
            this.textBox1.TabIndex = 5;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EditorForm";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTexttoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFilelStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem editortoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveOtherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findNextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoMulToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findLookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFontSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem newFormOpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DefaultSizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}

