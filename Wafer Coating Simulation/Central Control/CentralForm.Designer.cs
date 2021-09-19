
namespace Central_Control
{
    partial class CentralForm
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
            this.tbox_fac_ip = new System.Windows.Forms.TextBox();
            this.tbox_fac_port = new System.Windows.Forms.TextBox();
            this.btn_set_fac = new System.Windows.Forms.Button();
            this.lv_line = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_set_me = new System.Windows.Forms.Button();
            this.tbox_me_port = new System.Windows.Forms.TextBox();
            this.tbox_me_ip = new System.Windows.Forms.TextBox();
            this.lb_wafer = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_pr = new System.Windows.Forms.Label();
            this.btn_wafer = new System.Windows.Forms.Button();
            this.btn_pr = new System.Windows.Forms.Button();
            this.tbar_wafer = new System.Windows.Forms.TrackBar();
            this.tbar_pr = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.lb_npr = new System.Windows.Forms.Label();
            this.tbar_drop = new System.Windows.Forms.TrackBar();
            this.tbar_spin = new System.Windows.Forms.TrackBar();
            this.lb_drop = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lb_spin = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_awafer = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_wafer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_pr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_spin)).BeginInit();
            this.SuspendLayout();
            // 
            // tbox_fac_ip
            // 
            this.tbox_fac_ip.Location = new System.Drawing.Point(53, 22);
            this.tbox_fac_ip.Name = "tbox_fac_ip";
            this.tbox_fac_ip.Size = new System.Drawing.Size(267, 28);
            this.tbox_fac_ip.TabIndex = 0;
            // 
            // tbox_fac_port
            // 
            this.tbox_fac_port.Location = new System.Drawing.Point(326, 22);
            this.tbox_fac_port.Name = "tbox_fac_port";
            this.tbox_fac_port.Size = new System.Drawing.Size(100, 28);
            this.tbox_fac_port.TabIndex = 1;
            // 
            // btn_set_fac
            // 
            this.btn_set_fac.Location = new System.Drawing.Point(432, 22);
            this.btn_set_fac.Name = "btn_set_fac";
            this.btn_set_fac.Size = new System.Drawing.Size(98, 28);
            this.btn_set_fac.TabIndex = 2;
            this.btn_set_fac.Text = "공장설정";
            this.btn_set_fac.UseVisualStyleBackColor = true;
            this.btn_set_fac.Click += new System.EventHandler(this.btn_set_fac_Click);
            // 
            // lv_line
            // 
            this.lv_line.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lv_line.HideSelection = false;
            this.lv_line.Location = new System.Drawing.Point(52, 112);
            this.lv_line.Name = "lv_line";
            this.lv_line.Size = new System.Drawing.Size(268, 363);
            this.lv_line.TabIndex = 3;
            this.lv_line.UseCompatibleStateImageBehavior = false;
            this.lv_line.View = System.Windows.Forms.View.Details;
            this.lv_line.SelectedIndexChanged += new System.EventHandler(this.lv_line_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "코팅할 Wafer";
            this.columnHeader2.Width = 167;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(353, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Wafer";
            // 
            // btn_set_me
            // 
            this.btn_set_me.Location = new System.Drawing.Point(432, 56);
            this.btn_set_me.Name = "btn_set_me";
            this.btn_set_me.Size = new System.Drawing.Size(98, 28);
            this.btn_set_me.TabIndex = 7;
            this.btn_set_me.Text = "관제설정";
            this.btn_set_me.UseVisualStyleBackColor = true;
            this.btn_set_me.Click += new System.EventHandler(this.btn_set_me_Click);
            // 
            // tbox_me_port
            // 
            this.tbox_me_port.Location = new System.Drawing.Point(326, 56);
            this.tbox_me_port.Name = "tbox_me_port";
            this.tbox_me_port.Size = new System.Drawing.Size(100, 28);
            this.tbox_me_port.TabIndex = 6;
            // 
            // tbox_me_ip
            // 
            this.tbox_me_ip.Location = new System.Drawing.Point(53, 56);
            this.tbox_me_ip.Name = "tbox_me_ip";
            this.tbox_me_ip.ReadOnly = true;
            this.tbox_me_ip.Size = new System.Drawing.Size(267, 28);
            this.tbox_me_ip.TabIndex = 5;
            // 
            // lb_wafer
            // 
            this.lb_wafer.AutoSize = true;
            this.lb_wafer.Location = new System.Drawing.Point(575, 123);
            this.lb_wafer.Name = "lb_wafer";
            this.lb_wafer.Size = new System.Drawing.Size(18, 18);
            this.lb_wafer.TabIndex = 8;
            this.lb_wafer.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(353, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "코팅액";
            // 
            // lb_pr
            // 
            this.lb_pr.AutoSize = true;
            this.lb_pr.Location = new System.Drawing.Point(575, 192);
            this.lb_pr.Name = "lb_pr";
            this.lb_pr.Size = new System.Drawing.Size(18, 18);
            this.lb_pr.TabIndex = 10;
            this.lb_pr.Text = "0";
            // 
            // btn_wafer
            // 
            this.btn_wafer.Location = new System.Drawing.Point(673, 123);
            this.btn_wafer.Name = "btn_wafer";
            this.btn_wafer.Size = new System.Drawing.Size(98, 27);
            this.btn_wafer.TabIndex = 11;
            this.btn_wafer.Text = "투입";
            this.btn_wafer.UseVisualStyleBackColor = true;
            this.btn_wafer.Click += new System.EventHandler(this.btn_wafer_Click);
            // 
            // btn_pr
            // 
            this.btn_pr.Location = new System.Drawing.Point(673, 192);
            this.btn_pr.Name = "btn_pr";
            this.btn_pr.Size = new System.Drawing.Size(98, 27);
            this.btn_pr.TabIndex = 12;
            this.btn_pr.Text = "투입";
            this.btn_pr.UseVisualStyleBackColor = true;
            this.btn_pr.Click += new System.EventHandler(this.btn_pr_Click);
            // 
            // tbar_wafer
            // 
            this.tbar_wafer.Location = new System.Drawing.Point(432, 123);
            this.tbar_wafer.Maximum = 200;
            this.tbar_wafer.Name = "tbar_wafer";
            this.tbar_wafer.Size = new System.Drawing.Size(104, 69);
            this.tbar_wafer.TabIndex = 13;
            this.tbar_wafer.Scroll += new System.EventHandler(this.tbar_wafer_Scroll);
            // 
            // tbar_pr
            // 
            this.tbar_pr.Location = new System.Drawing.Point(432, 192);
            this.tbar_pr.Maximum = 20;
            this.tbar_pr.Name = "tbar_pr";
            this.tbar_pr.Size = new System.Drawing.Size(104, 69);
            this.tbar_pr.TabIndex = 14;
            this.tbar_pr.Scroll += new System.EventHandler(this.tbar_pr_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(353, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 18);
            this.label5.TabIndex = 15;
            this.label5.Text = "현재 코팅액:";
            // 
            // lb_npr
            // 
            this.lb_npr.AutoSize = true;
            this.lb_npr.Location = new System.Drawing.Point(464, 267);
            this.lb_npr.Name = "lb_npr";
            this.lb_npr.Size = new System.Drawing.Size(18, 18);
            this.lb_npr.TabIndex = 16;
            this.lb_npr.Text = "0";
            // 
            // tbar_drop
            // 
            this.tbar_drop.Location = new System.Drawing.Point(432, 383);
            this.tbar_drop.Maximum = 100;
            this.tbar_drop.Minimum = 20;
            this.tbar_drop.Name = "tbar_drop";
            this.tbar_drop.Size = new System.Drawing.Size(104, 69);
            this.tbar_drop.TabIndex = 22;
            this.tbar_drop.Value = 20;
            this.tbar_drop.Scroll += new System.EventHandler(this.tbar_drop_Scroll);
            // 
            // tbar_spin
            // 
            this.tbar_spin.Location = new System.Drawing.Point(432, 314);
            this.tbar_spin.Maximum = 8000;
            this.tbar_spin.Minimum = 1000;
            this.tbar_spin.Name = "tbar_spin";
            this.tbar_spin.Size = new System.Drawing.Size(104, 69);
            this.tbar_spin.TabIndex = 21;
            this.tbar_spin.Value = 1000;
            this.tbar_spin.Scroll += new System.EventHandler(this.tbar_spin_Scroll);
            // 
            // lb_drop
            // 
            this.lb_drop.AutoSize = true;
            this.lb_drop.Location = new System.Drawing.Point(575, 383);
            this.lb_drop.Name = "lb_drop";
            this.lb_drop.Size = new System.Drawing.Size(28, 18);
            this.lb_drop.TabIndex = 20;
            this.lb_drop.Text = "20";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(353, 383);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 18);
            this.label8.TabIndex = 19;
            this.label8.Text = "낙하속도";
            // 
            // lb_spin
            // 
            this.lb_spin.AutoSize = true;
            this.lb_spin.Location = new System.Drawing.Point(575, 314);
            this.lb_spin.Name = "lb_spin";
            this.lb_spin.Size = new System.Drawing.Size(48, 18);
            this.lb_spin.TabIndex = 18;
            this.lb_spin.Text = "1000";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(353, 314);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 18);
            this.label10.TabIndex = 17;
            this.label10.Text = "회전속도";
            // 
            // lb_awafer
            // 
            this.lb_awafer.AutoSize = true;
            this.lb_awafer.Location = new System.Drawing.Point(472, 457);
            this.lb_awafer.Name = "lb_awafer";
            this.lb_awafer.Size = new System.Drawing.Size(18, 18);
            this.lb_awafer.TabIndex = 24;
            this.lb_awafer.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(353, 457);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(120, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "코팅한 Wafer:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(670, 383);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(28, 18);
            this.label13.TabIndex = 26;
            this.label13.Text = "ps";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(670, 314);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(39, 18);
            this.label14.TabIndex = 25;
            this.label14.Text = "rpm";
            // 
            // CentralForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lb_awafer);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbar_drop);
            this.Controls.Add(this.tbar_spin);
            this.Controls.Add(this.lb_drop);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lb_spin);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_npr);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbar_pr);
            this.Controls.Add(this.tbar_wafer);
            this.Controls.Add(this.btn_pr);
            this.Controls.Add(this.btn_wafer);
            this.Controls.Add(this.lb_pr);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lb_wafer);
            this.Controls.Add(this.btn_set_me);
            this.Controls.Add(this.tbox_me_port);
            this.Controls.Add(this.tbox_me_ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lv_line);
            this.Controls.Add(this.btn_set_fac);
            this.Controls.Add(this.tbox_fac_port);
            this.Controls.Add(this.tbox_fac_ip);
            this.Name = "CentralForm";
            this.Text = "CentralForm";
            this.Load += new System.EventHandler(this.CentralForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbar_wafer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_pr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_spin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbox_fac_ip;
        private System.Windows.Forms.TextBox tbox_fac_port;
        private System.Windows.Forms.Button btn_set_fac;
        private System.Windows.Forms.ListView lv_line;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_set_me;
        private System.Windows.Forms.TextBox tbox_me_port;
        private System.Windows.Forms.TextBox tbox_me_ip;
        private System.Windows.Forms.Label lb_wafer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_pr;
        private System.Windows.Forms.Button btn_wafer;
        private System.Windows.Forms.Button btn_pr;
        private System.Windows.Forms.TrackBar tbar_wafer;
        private System.Windows.Forms.TrackBar tbar_pr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lb_npr;
        private System.Windows.Forms.TrackBar tbar_drop;
        private System.Windows.Forms.TrackBar tbar_spin;
        private System.Windows.Forms.Label lb_drop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lb_spin;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_awafer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

