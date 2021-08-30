
namespace 이미지_수신_서버
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbox_fno = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbox_km = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbox_fno
            // 
            this.lbox_fno.FormattingEnabled = true;
            this.lbox_fno.ItemHeight = 18;
            this.lbox_fno.Location = new System.Drawing.Point(46, 58);
            this.lbox_fno.Name = "lbox_fno";
            this.lbox_fno.Size = new System.Drawing.Size(195, 328);
            this.lbox_fno.TabIndex = 0;
            this.lbox_fno.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(302, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(427, 328);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbox_km
            // 
            this.lbox_km.FormattingEnabled = true;
            this.lbox_km.ItemHeight = 18;
            this.lbox_km.Location = new System.Drawing.Point(46, 429);
            this.lbox_km.Name = "lbox_km";
            this.lbox_km.Size = new System.Drawing.Size(683, 346);
            this.lbox_km.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 821);
            this.Controls.Add(this.lbox_km);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbox_fno);
            this.Name = "Form1";
            this.Text = "이미지 + KM 수신 서버";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbox_fno;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbox_km;
    }
}

