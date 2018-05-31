namespace Wave
{
    partial class ChannelListItem
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
            this.labChannelTitle = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnChannelDel = new System.Windows.Forms.Button();
            this.btnChannelShow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // labChannelTitle
            // 
            this.labChannelTitle.AutoSize = true;
            this.labChannelTitle.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labChannelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(123)))), ((int)(((byte)(154)))));
            this.labChannelTitle.Location = new System.Drawing.Point(15, 7);
            this.labChannelTitle.Name = "labChannelTitle";
            this.labChannelTitle.Size = new System.Drawing.Size(39, 20);
            this.labChannelTitle.TabIndex = 0;
            this.labChannelTitle.Text = "CH1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImage = global::WaveOs.Properties.Resources.ch1;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox2.Location = new System.Drawing.Point(120, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 31);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox2_Paint);
            // 
            // btnChannelDel
            // 
            this.btnChannelDel.BackColor = System.Drawing.Color.Transparent;
            this.btnChannelDel.BackgroundImage = global::WaveOs.Properties.Resources.delete;
            this.btnChannelDel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChannelDel.FlatAppearance.BorderSize = 0;
            this.btnChannelDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChannelDel.Location = new System.Drawing.Point(1836, 2);
            this.btnChannelDel.Name = "btnChannelDel";
            this.btnChannelDel.Size = new System.Drawing.Size(31, 31);
            this.btnChannelDel.TabIndex = 0;
            this.btnChannelDel.UseVisualStyleBackColor = false;
            this.btnChannelDel.Click += new System.EventHandler(this.btnChannelDel_Click);
            // 
            // btnChannelShow
            // 
            this.btnChannelShow.BackColor = System.Drawing.Color.White;
            this.btnChannelShow.BackgroundImage = global::WaveOs.Properties.Resources.show;
            this.btnChannelShow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnChannelShow.FlatAppearance.BorderSize = 0;
            this.btnChannelShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChannelShow.Location = new System.Drawing.Point(65, 0);
            this.btnChannelShow.Name = "btnChannelShow";
            this.btnChannelShow.Size = new System.Drawing.Size(35, 35);
            this.btnChannelShow.TabIndex = 1;
            this.btnChannelShow.UseVisualStyleBackColor = false;
            this.btnChannelShow.Click += new System.EventHandler(this.btnChannelShow_Click);
            // 
            // ChannelListItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.labChannelTitle);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnChannelDel);
            this.Controls.Add(this.btnChannelShow);
            this.Name = "ChannelListItem";
            this.Size = new System.Drawing.Size(1870, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ChannelListItem_Paint);
            this.Enter += new System.EventHandler(this.ChannelListItem_Enter);
            this.Leave += new System.EventHandler(this.ChannelListItem_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labChannelTitle;
        private System.Windows.Forms.Button btnChannelShow;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnChannelDel;
    }
}
