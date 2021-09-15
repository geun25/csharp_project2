
namespace WaferLine_예광탄
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
            this.waferLineControl1 = new WaferLineControlLib.WaferLineControl();
            this.SuspendLayout();
            // 
            // waferLineControl1
            // 
            this.waferLineControl1.Line = null;
            this.waferLineControl1.Location = new System.Drawing.Point(12, 31);
            this.waferLineControl1.Name = "waferLineControl1";
            this.waferLineControl1.Size = new System.Drawing.Size(900, 555);
            this.waferLineControl1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 640);
            this.Controls.Add(this.waferLineControl1);
            this.Name = "Form1";
            this.Text = "WaferLine 예광탄";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WaferLineControlLib.WaferLineControl waferLineControl1;
    }
}

