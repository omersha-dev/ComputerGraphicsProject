namespace myOpenGL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			this.timerRepaint = new System.Windows.Forms.Timer(this.components);
			this.timerRUN = new System.Windows.Forms.Timer(this.components);
			this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// timerRepaint
			// 
			this.timerRepaint.Interval = 10;
			this.timerRepaint.Tick += new System.EventHandler(this.timerRepaint_Tick);
			// 
			// timerRUN
			// 
			this.timerRUN.Interval = 10;
			this.timerRUN.Tick += new System.EventHandler(this.timerRUN_Tick);
			// 
			// hScrollBar1
			// 
			this.hScrollBar1.LargeChange = 1;
			this.hScrollBar1.Location = new System.Drawing.Point(452, 357);
			this.hScrollBar1.Maximum = 200;
			this.hScrollBar1.Minimum = 1;
			this.hScrollBar1.Name = "hScrollBar1";
			this.hScrollBar1.Size = new System.Drawing.Size(115, 14);
			this.hScrollBar1.TabIndex = 4;
			this.hScrollBar1.Value = 10;
			this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(449, 333);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "timer delay";
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Location = new System.Drawing.Point(12, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(431, 403);
			this.panel1.TabIndex = 6;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			this.panel1.Resize += new System.EventHandler(this.panel1_Resize);
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(464, 16);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(83, 17);
			this.checkBox1.TabIndex = 7;
			this.checkBox1.Text = "Transparent";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Location = new System.Drawing.Point(464, 39);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(54, 17);
			this.checkBox2.TabIndex = 8;
			this.checkBox2.Text = "Inside";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(464, 62);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(62, 17);
			this.checkBox3.TabIndex = 10;
			this.checkBox3.Text = "Bounds";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(464, 89);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(56, 17);
			this.checkBox4.TabIndex = 11;
			this.checkBox4.Text = "Pause";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.ForeColor = System.Drawing.Color.Maroon;
			this.label4.Location = new System.Drawing.Point(449, 248);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(111, 68);
			this.label4.TabIndex = 14;
			this.label4.Text = "Press:                         X,x,                       Y,y,                   " +
    "     Z,z";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(579, 431);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.checkBox4);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.checkBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.hScrollBar1);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerRepaint;
        private System.Windows.Forms.Timer timerRUN;
        private System.Windows.Forms.HScrollBar hScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Label label4;
    }
}

