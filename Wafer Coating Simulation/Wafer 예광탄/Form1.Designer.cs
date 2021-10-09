using WaferLineControlLib;

namespace Wafer_예광탄
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
            this.components = new System.ComponentModel.Container();
            this.btn_start = new System.Windows.Forms.Button();
            this.pn_wafer = new WaferPanel();
            this.tm_coating = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(78, 32);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(95, 32);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "시작";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pn_wafer
            // 
            this.pn_wafer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_wafer.Location = new System.Drawing.Point(53, 90);
            this.pn_wafer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pn_wafer.Name = "pn_wafer";
            this.pn_wafer.Size = new System.Drawing.Size(144, 144);
            this.pn_wafer.TabIndex = 1;
            this.pn_wafer.Wafer = null;
            this.pn_wafer.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_wafer_Paint);
            // 
            // tm_coating
            // 
            this.tm_coating.Tick += new System.EventHandler(this.tm_coating_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 297);
            this.Controls.Add(this.pn_wafer);
            this.Controls.Add(this.btn_start);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Wafer 예광탄";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start;
        private WaferPanel pn_wafer;
        private System.Windows.Forms.Timer tm_coating;
    }
}

