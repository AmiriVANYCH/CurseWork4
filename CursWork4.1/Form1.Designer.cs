namespace CurseWork
{
    partial class Form1
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.nodeContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchPathsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shortestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minSwitchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transferPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datagramModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logicalChannelModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.nodeContext.SuspendLayout();
            this.generalContext.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nodeContext
            // 
            this.nodeContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testToolStripMenuItem,
            this.toolStripMenuItem2,
            this.removeToolStripMenuItem,
            this.searchPathsToolStripMenuItem,
            this.transferPackageToolStripMenuItem});
            this.nodeContext.Name = "contextMenuStrip1";
            this.nodeContext.Size = new System.Drawing.Size(189, 98);
            this.nodeContext.Text = "Передача пакета";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.testToolStripMenuItem.Text = "З\'єднати вузол/станцію";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(185, 6);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionToolStripMenuItem,
            this.switchToolStripMenuItem});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.removeToolStripMenuItem.Text = "Видалити";
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.connectionToolStripMenuItem.Text = "З\'єднання";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.removeConnectionToolStripMenuItem);
            // 
            // switchToolStripMenuItem
            // 
            this.switchToolStripMenuItem.Name = "switchToolStripMenuItem";
            this.switchToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.switchToolStripMenuItem.Text = "Вузол/Станцію";
            this.switchToolStripMenuItem.Click += new System.EventHandler(this.remuveSwitchToolStripMenuItem_Click);
            // 
            // searchPathsToolStripMenuItem
            // 
            this.searchPathsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shortestToolStripMenuItem,
            this.minSwitchToolStripMenuItem});
            this.searchPathsToolStripMenuItem.Name = "searchPathsToolStripMenuItem";
            this.searchPathsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.searchPathsToolStripMenuItem.Text = "Побудова маршруту";
            // 
            // shortestToolStripMenuItem
            // 
            this.shortestToolStripMenuItem.Name = "shortestToolStripMenuItem";
            this.shortestToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.shortestToolStripMenuItem.Text = "За меншою довжиною шляху";
            this.shortestToolStripMenuItem.Click += new System.EventHandler(this.shortestToolStripMenuItem_Click);
            // 
            // minSwitchToolStripMenuItem
            // 
            this.minSwitchToolStripMenuItem.Name = "minSwitchToolStripMenuItem";
            this.minSwitchToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.minSwitchToolStripMenuItem.Text = "За меншою кількістю вузлів";
            this.minSwitchToolStripMenuItem.Click += new System.EventHandler(this.minSwitchToolStripMenuItem_Click);
            // 
            // transferPackageToolStripMenuItem
            // 
            this.transferPackageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datagramModeToolStripMenuItem,
            this.logicalChannelModeToolStripMenuItem});
            this.transferPackageToolStripMenuItem.Name = "transferPackageToolStripMenuItem";
            this.transferPackageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.transferPackageToolStripMenuItem.Text = "Передача даних";
            // 
            // datagramModeToolStripMenuItem
            // 
            this.datagramModeToolStripMenuItem.Name = "datagramModeToolStripMenuItem";
            this.datagramModeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.datagramModeToolStripMenuItem.Text = "Дейтаграмний режим";
            this.datagramModeToolStripMenuItem.Click += new System.EventHandler(this.datagramModeToolStripMenuItem_Click);
            // 
            // logicalChannelModeToolStripMenuItem
            // 
            this.logicalChannelModeToolStripMenuItem.Name = "logicalChannelModeToolStripMenuItem";
            this.logicalChannelModeToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.logicalChannelModeToolStripMenuItem.Text = "Режим логічного каналу";
            this.logicalChannelModeToolStripMenuItem.Click += new System.EventHandler(this.logicalChannelModeToolStripMenuItem_Click);
            // 
            // generalContext
            // 
            this.generalContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test2ToolStripMenuItem, this.addStanceToolStripMenuItem});
            this.generalContext.Name = "contextMenuStrip2";
            this.generalContext.Size = new System.Drawing.Size(148, 26);
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.test2ToolStripMenuItem.Text = "Додати вузол";
            this.test2ToolStripMenuItem.Click += new System.EventHandler(this.test2ToolStripMenuItem_Click);

            // 
            // addStanceToolStripMenuItem
            // 
            this.addStanceToolStripMenuItem.Name = "addStanceToolStripMenuItem";
            this.addStanceToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.addStanceToolStripMenuItem.Text = "Додати станцію";
            this.addStanceToolStripMenuItem.Click += new System.EventHandler(this.addStanceToolStripMenuItem_Click);

            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.statusStrip1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1096, 544);
            this.panel2.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Кількість вузлів:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(105, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.ContextMenuStrip = this.generalContext;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1096, 544);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            

            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FloralWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1096, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem1,
            this.очиститьToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.файлToolStripMenuItem.Text = "Меню";
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.загрузитьToolStripMenuItem.Text = "Завантажити граф";
            this.загрузитьToolStripMenuItem.Click += new System.EventHandler(this.загрузитьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.сохранитьToolStripMenuItem.Text = "Зберегти граф";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.очиститьToolStripMenuItem.Text = "Очистити екран";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.exitToolStripMenuItem.Text = "Вихід";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML data|*.xml";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "xml";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "XML Data|*.xml";
            //
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1096, 568);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Побудова мережі";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.nodeContext.ResumeLayout(false);
            this.generalContext.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip nodeContext;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip generalContext;
        private System.Windows.Forms.ToolStripMenuItem addStanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchPathsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shortestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem minSwitchToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem transferPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datagramModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logicalChannelModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

