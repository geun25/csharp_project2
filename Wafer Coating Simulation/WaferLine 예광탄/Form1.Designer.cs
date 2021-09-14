
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_wafer = new System.Windows.Forms.Label();
            this.tbar_wafer = new System.Windows.Forms.TrackBar();
            this.btn_wafer = new System.Windows.Forms.Button();
            this.btn_pr = new System.Windows.Forms.Button();
            this.tbar_pr = new System.Windows.Forms.TrackBar();
            this.lb_pr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbar_drop = new System.Windows.Forms.TrackBar();
            this.lb_drop = new System.Windows.Forms.Label();
            this.tbar_spin = new System.Windows.Forms.TrackBar();
            this.lb_spin = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_wcnt = new System.Windows.Forms.Label();
            this.pn_wafer = new WaferLineControlLib.DPanel();
            this.pn_pr = new WaferLineControlLib.DPanel();
            this.lb_pcnt = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.pn_npr = new WaferLineControlLib.DPanel();
            this.pn_nwafer = new WaferLineControlLib.WaferPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_awcnt = new System.Windows.Forms.Label();
            this.cb_awafer = new System.Windows.Forms.ComboBox();
            this.pn_awafer = new WaferLineControlLib.WaferPanel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.tm_coating = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tbar_wafer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_pr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_spin)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wafer";
            // 
            // lb_wafer
            // 
            this.lb_wafer.AutoSize = true;
            this.lb_wafer.Location = new System.Drawing.Point(309, 68);
            this.lb_wafer.Name = "lb_wafer";
            this.lb_wafer.Size = new System.Drawing.Size(18, 18);
            this.lb_wafer.TabIndex = 1;
            this.lb_wafer.Text = "0";
            // 
            // tbar_wafer
            // 
            this.tbar_wafer.Location = new System.Drawing.Point(179, 55);
            this.tbar_wafer.Maximum = 200;
            this.tbar_wafer.Name = "tbar_wafer";
            this.tbar_wafer.Size = new System.Drawing.Size(104, 69);
            this.tbar_wafer.TabIndex = 2;
            this.tbar_wafer.Scroll += new System.EventHandler(this.tbar_wafer_Scroll);
            // 
            // btn_wafer
            // 
            this.btn_wafer.Location = new System.Drawing.Point(382, 63);
            this.btn_wafer.Name = "btn_wafer";
            this.btn_wafer.Size = new System.Drawing.Size(76, 29);
            this.btn_wafer.TabIndex = 4;
            this.btn_wafer.Text = "투입";
            this.btn_wafer.UseVisualStyleBackColor = true;
            this.btn_wafer.Click += new System.EventHandler(this.btn_wafer_Click);
            // 
            // btn_pr
            // 
            this.btn_pr.Location = new System.Drawing.Point(382, 138);
            this.btn_pr.Name = "btn_pr";
            this.btn_pr.Size = new System.Drawing.Size(76, 29);
            this.btn_pr.TabIndex = 8;
            this.btn_pr.Text = "투입";
            this.btn_pr.UseVisualStyleBackColor = true;
            this.btn_pr.Click += new System.EventHandler(this.btn_pr_Click);
            // 
            // tbar_pr
            // 
            this.tbar_pr.Location = new System.Drawing.Point(179, 130);
            this.tbar_pr.Maximum = 20;
            this.tbar_pr.Name = "tbar_pr";
            this.tbar_pr.Size = new System.Drawing.Size(104, 69);
            this.tbar_pr.TabIndex = 7;
            this.tbar_pr.Scroll += new System.EventHandler(this.tbar_pr_Scroll);
            // 
            // lb_pr
            // 
            this.lb_pr.AutoSize = true;
            this.lb_pr.Location = new System.Drawing.Point(309, 143);
            this.lb_pr.Name = "lb_pr";
            this.lb_pr.Size = new System.Drawing.Size(18, 18);
            this.lb_pr.TabIndex = 6;
            this.lb_pr.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "코팅액";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(532, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 10;
            this.label2.Text = "낙하속도";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(532, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "회전속도";
            // 
            // tbar_drop
            // 
            this.tbar_drop.Location = new System.Drawing.Point(658, 130);
            this.tbar_drop.Maximum = 100;
            this.tbar_drop.Minimum = 20;
            this.tbar_drop.Name = "tbar_drop";
            this.tbar_drop.Size = new System.Drawing.Size(104, 69);
            this.tbar_drop.TabIndex = 14;
            this.tbar_drop.Value = 20;
            this.tbar_drop.Scroll += new System.EventHandler(this.tbar_drop_Scroll);
            // 
            // lb_drop
            // 
            this.lb_drop.AutoSize = true;
            this.lb_drop.Location = new System.Drawing.Point(777, 143);
            this.lb_drop.Name = "lb_drop";
            this.lb_drop.Size = new System.Drawing.Size(28, 18);
            this.lb_drop.TabIndex = 13;
            this.lb_drop.Text = "20";
            // 
            // tbar_spin
            // 
            this.tbar_spin.Location = new System.Drawing.Point(658, 55);
            this.tbar_spin.Maximum = 8000;
            this.tbar_spin.Minimum = 1000;
            this.tbar_spin.Name = "tbar_spin";
            this.tbar_spin.Size = new System.Drawing.Size(104, 69);
            this.tbar_spin.TabIndex = 12;
            this.tbar_spin.Value = 1000;
            this.tbar_spin.Scroll += new System.EventHandler(this.tbar_spin_Scroll);
            // 
            // lb_spin
            // 
            this.lb_spin.AutoSize = true;
            this.lb_spin.Location = new System.Drawing.Point(777, 68);
            this.lb_spin.Name = "lb_spin";
            this.lb_spin.Size = new System.Drawing.Size(48, 18);
            this.lb_spin.TabIndex = 11;
            this.lb_spin.Text = "1000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(811, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 18);
            this.label5.TabIndex = 16;
            this.label5.Text = "ps";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(831, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 18);
            this.label6.TabIndex = 15;
            this.label6.Text = "rpm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 18);
            this.label7.TabIndex = 17;
            this.label7.Text = "Wafer";
            // 
            // lb_wcnt
            // 
            this.lb_wcnt.AutoSize = true;
            this.lb_wcnt.Location = new System.Drawing.Point(101, 274);
            this.lb_wcnt.Name = "lb_wcnt";
            this.lb_wcnt.Size = new System.Drawing.Size(18, 18);
            this.lb_wcnt.TabIndex = 18;
            this.lb_wcnt.Text = "0";
            // 
            // pn_wafer
            // 
            this.pn_wafer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_wafer.Location = new System.Drawing.Point(63, 312);
            this.pn_wafer.Name = "pn_wafer";
            this.pn_wafer.Size = new System.Drawing.Size(97, 200);
            this.pn_wafer.TabIndex = 19;
            this.pn_wafer.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_wafer_Paint);
            // 
            // pn_pr
            // 
            this.pn_pr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pn_pr.Location = new System.Drawing.Point(206, 312);
            this.pn_pr.Name = "pn_pr";
            this.pn_pr.Size = new System.Drawing.Size(97, 200);
            this.pn_pr.TabIndex = 22;
            this.pn_pr.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_pr_Paint);
            // 
            // lb_pcnt
            // 
            this.lb_pcnt.AutoSize = true;
            this.lb_pcnt.Location = new System.Drawing.Point(244, 274);
            this.lb_pcnt.Name = "lb_pcnt";
            this.lb_pcnt.Size = new System.Drawing.Size(18, 18);
            this.lb_pcnt.TabIndex = 21;
            this.lb_pcnt.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 230);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "코팅액";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(382, 214);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(111, 50);
            this.btn_start.TabIndex = 23;
            this.btn_start.Text = "시작";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // pn_npr
            // 
            this.pn_npr.Location = new System.Drawing.Point(403, 285);
            this.pn_npr.Name = "pn_npr";
            this.pn_npr.Size = new System.Drawing.Size(65, 57);
            this.pn_npr.TabIndex = 24;
            this.pn_npr.Paint += new System.Windows.Forms.PaintEventHandler(this.pn_npr_Paint);
            // 
            // pn_nwafer
            // 
            this.pn_nwafer.Location = new System.Drawing.Point(373, 367);
            this.pn_nwafer.Name = "pn_nwafer";
            this.pn_nwafer.Size = new System.Drawing.Size(142, 145);
            this.pn_nwafer.TabIndex = 25;
            this.pn_nwafer.Wafer = null;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(635, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 18);
            this.label8.TabIndex = 26;
            this.label8.Text = "Wafer(후)";
            // 
            // lb_awcnt
            // 
            this.lb_awcnt.AutoSize = true;
            this.lb_awcnt.Location = new System.Drawing.Point(744, 230);
            this.lb_awcnt.Name = "lb_awcnt";
            this.lb_awcnt.Size = new System.Drawing.Size(18, 18);
            this.lb_awcnt.TabIndex = 27;
            this.lb_awcnt.Text = "0";
            // 
            // cb_awafer
            // 
            this.cb_awafer.FormattingEnabled = true;
            this.cb_awafer.Location = new System.Drawing.Point(638, 274);
            this.cb_awafer.Name = "cb_awafer";
            this.cb_awafer.Size = new System.Drawing.Size(157, 26);
            this.cb_awafer.TabIndex = 28;
            this.cb_awafer.SelectedIndexChanged += new System.EventHandler(this.cb_awafer_SelectedIndexChanged);
            // 
            // pn_awafer
            // 
            this.pn_awafer.Location = new System.Drawing.Point(658, 367);
            this.pn_awafer.Name = "pn_awafer";
            this.pn_awafer.Size = new System.Drawing.Size(142, 145);
            this.pn_awafer.TabIndex = 26;
            this.pn_awafer.Wafer = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_lb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 608);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(907, 32);
            this.statusStrip1.TabIndex = 29;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_lb
            // 
            this.ts_lb.Name = "ts_lb";
            this.ts_lb.Size = new System.Drawing.Size(202, 25);
            this.ts_lb.Text = "상태변화를 나타냅니다.";
            // 
            // tm_coating
            // 
            this.tm_coating.Tick += new System.EventHandler(this.tm_coating_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 640);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pn_awafer);
            this.Controls.Add(this.cb_awafer);
            this.Controls.Add(this.lb_awcnt);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pn_nwafer);
            this.Controls.Add(this.pn_npr);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.pn_pr);
            this.Controls.Add(this.lb_pcnt);
            this.Controls.Add(this.pn_wafer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_wcnt);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbar_drop);
            this.Controls.Add(this.lb_drop);
            this.Controls.Add(this.tbar_spin);
            this.Controls.Add(this.lb_spin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_pr);
            this.Controls.Add(this.tbar_pr);
            this.Controls.Add(this.lb_pr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_wafer);
            this.Controls.Add(this.tbar_wafer);
            this.Controls.Add(this.lb_wafer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "WaferLine 예광탄";
            ((System.ComponentModel.ISupportInitialize)(this.tbar_wafer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_pr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_spin)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_wafer;
        private System.Windows.Forms.TrackBar tbar_wafer;
        private System.Windows.Forms.Button btn_wafer;
        private System.Windows.Forms.Button btn_pr;
        private System.Windows.Forms.TrackBar tbar_pr;
        private System.Windows.Forms.Label lb_pr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar tbar_drop;
        private System.Windows.Forms.Label lb_drop;
        private System.Windows.Forms.TrackBar tbar_spin;
        private System.Windows.Forms.Label lb_spin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_wcnt;
        private WaferLineControlLib.DPanel pn_wafer;
        private WaferLineControlLib.DPanel pn_pr;
        private System.Windows.Forms.Label lb_pcnt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_start;
        private WaferLineControlLib.DPanel pn_npr;
        private WaferLineControlLib.WaferPanel pn_nwafer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_awcnt;
        private System.Windows.Forms.ComboBox cb_awafer;
        private WaferLineControlLib.WaferPanel pn_awafer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts_lb;
        private System.Windows.Forms.Timer tm_coating;
    }
}

