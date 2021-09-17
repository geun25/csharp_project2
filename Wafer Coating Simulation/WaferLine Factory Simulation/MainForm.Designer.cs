
namespace WaferLine_Factory_Simulation
{
    partial class MainForm
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
            this.cb_ip = new System.Windows.Forms.ComboBox();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lv_line = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.lb_next_no = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lb_selno = new System.Windows.Forms.Label();
            this.cb_awafer = new System.Windows.Forms.ComboBox();
            this.lb_spin = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lb_drop = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lb_pr = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_line = new System.Windows.Forms.ComboBox();
            this.btn_manage = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ts_lb = new System.Windows.Forms.ToolStripStatusLabel();
            this.pn_awafer = new WaferLineControlLib.WaferPanel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cb_ip
            // 
            this.cb_ip.FormattingEnabled = true;
            this.cb_ip.Location = new System.Drawing.Point(58, 39);
            this.cb_ip.Name = "cb_ip";
            this.cb_ip.Size = new System.Drawing.Size(412, 26);
            this.cb_ip.TabIndex = 0;
            // 
            // tb_port
            // 
            this.tb_port.Location = new System.Drawing.Point(511, 39);
            this.tb_port.Name = "tb_port";
            this.tb_port.Size = new System.Drawing.Size(149, 28);
            this.tb_port.TabIndex = 1;
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(682, 35);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(89, 33);
            this.btn_set.TabIndex = 2;
            this.btn_set.Text = "설정";
            this.btn_set.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "라인";
            // 
            // lv_line
            // 
            this.lv_line.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_line.FullRowSelect = true;
            this.lv_line.HideSelection = false;
            this.lv_line.Location = new System.Drawing.Point(59, 166);
            this.lv_line.MultiSelect = false;
            this.lv_line.Name = "lv_line";
            this.lv_line.Size = new System.Drawing.Size(411, 249);
            this.lv_line.TabIndex = 4;
            this.lv_line.UseCompatibleStateImageBehavior = false;
            this.lv_line.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            this.columnHeader1.Width = 74;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "코팅전";
            this.columnHeader2.Width = 96;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "코팅후";
            this.columnHeader3.Width = 128;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 468);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "다음 라인:";
            // 
            // lb_next_no
            // 
            this.lb_next_no.AutoSize = true;
            this.lb_next_no.Location = new System.Drawing.Point(166, 468);
            this.lb_next_no.Name = "lb_next_no";
            this.lb_next_no.Size = new System.Drawing.Size(18, 18);
            this.lb_next_no.TabIndex = 6;
            this.lb_next_no.Text = "1";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(212, 461);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(89, 33);
            this.btn_add.TabIndex = 7;
            this.btn_add.Text = "추가";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(558, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "선택한 라인:";
            // 
            // lb_selno
            // 
            this.lb_selno.AutoSize = true;
            this.lb_selno.Location = new System.Drawing.Point(679, 143);
            this.lb_selno.Name = "lb_selno";
            this.lb_selno.Size = new System.Drawing.Size(18, 18);
            this.lb_selno.TabIndex = 9;
            this.lb_selno.Text = "0";
            // 
            // cb_awafer
            // 
            this.cb_awafer.FormattingEnabled = true;
            this.cb_awafer.Location = new System.Drawing.Point(561, 187);
            this.cb_awafer.Name = "cb_awafer";
            this.cb_awafer.Size = new System.Drawing.Size(210, 26);
            this.cb_awafer.TabIndex = 10;
            this.cb_awafer.SelectedIndexChanged += new System.EventHandler(this.cb_awafer_SelectedIndexChanged);
            // 
            // lb_spin
            // 
            this.lb_spin.AutoSize = true;
            this.lb_spin.Location = new System.Drawing.Point(978, 245);
            this.lb_spin.Name = "lb_spin";
            this.lb_spin.Size = new System.Drawing.Size(48, 18);
            this.lb_spin.TabIndex = 13;
            this.lb_spin.Text = "2000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(880, 245);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 18);
            this.label7.TabIndex = 12;
            this.label7.Text = "Spin:";
            // 
            // lb_drop
            // 
            this.lb_drop.AutoSize = true;
            this.lb_drop.Location = new System.Drawing.Point(978, 300);
            this.lb_drop.Name = "lb_drop";
            this.lb_drop.Size = new System.Drawing.Size(38, 18);
            this.lb_drop.TabIndex = 15;
            this.lb_drop.Text = "100";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(880, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 18);
            this.label9.TabIndex = 14;
            this.label9.Text = "Drop:";
            // 
            // lb_pr
            // 
            this.lb_pr.AutoSize = true;
            this.lb_pr.Location = new System.Drawing.Point(978, 355);
            this.lb_pr.Name = "lb_pr";
            this.lb_pr.Size = new System.Drawing.Size(18, 18);
            this.lb_pr.TabIndex = 17;
            this.lb_pr.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(880, 355);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 18);
            this.label11.TabIndex = 16;
            this.label11.Text = "코팅액:";
            // 
            // cb_line
            // 
            this.cb_line.FormattingEnabled = true;
            this.cb_line.Location = new System.Drawing.Point(562, 465);
            this.cb_line.Name = "cb_line";
            this.cb_line.Size = new System.Drawing.Size(328, 26);
            this.cb_line.TabIndex = 18;
            // 
            // btn_manage
            // 
            this.btn_manage.Location = new System.Drawing.Point(943, 458);
            this.btn_manage.Name = "btn_manage";
            this.btn_manage.Size = new System.Drawing.Size(89, 33);
            this.btn_manage.TabIndex = 19;
            this.btn_manage.Text = "관리";
            this.btn_manage.UseVisualStyleBackColor = true;
            this.btn_manage.Click += new System.EventHandler(this.btn_manage_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_lb});
            this.statusStrip1.Location = new System.Drawing.Point(0, 640);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1082, 32);
            this.statusStrip1.TabIndex = 20;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ts_lb
            // 
            this.ts_lb.Name = "ts_lb";
            this.ts_lb.Size = new System.Drawing.Size(328, 25);
            this.ts_lb.Text = "가장 최근에 발생한 사건을 보여줍니다.";
            // 
            // pn_awafer
            // 
            this.pn_awafer.Location = new System.Drawing.Point(561, 245);
            this.pn_awafer.Name = "pn_awafer";
            this.pn_awafer.Size = new System.Drawing.Size(210, 170);
            this.pn_awafer.TabIndex = 11;
            this.pn_awafer.Wafer = null;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 672);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btn_manage);
            this.Controls.Add(this.cb_line);
            this.Controls.Add(this.lb_pr);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lb_drop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lb_spin);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pn_awafer);
            this.Controls.Add(this.cb_awafer);
            this.Controls.Add(this.lb_selno);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.lb_next_no);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lv_line);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_set);
            this.Controls.Add(this.tb_port);
            this.Controls.Add(this.cb_ip);
            this.Name = "MainForm";
            this.Text = "WaferLine Factory MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cb_ip;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lv_line;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lb_next_no;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lb_selno;
        private System.Windows.Forms.ComboBox cb_awafer;
        private WaferLineControlLib.WaferPanel pn_awafer;
        private System.Windows.Forms.Label lb_spin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lb_drop;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lb_pr;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cb_line;
        private System.Windows.Forms.Button btn_manage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ts_lb;
    }
}

