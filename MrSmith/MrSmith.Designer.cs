namespace MrSmith
{
    partial class MrSmith
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LB_OUTPUT = new System.Windows.Forms.ListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LB_COMMANDS = new System.Windows.Forms.ListBox();
            this.TimerSpk = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.LB_OUTPUT, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(434, 536);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::MrSmith.Properties.Resources.bleu_robot;
            this.pictureBox1.Location = new System.Drawing.Point(3, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(428, 422);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // LB_OUTPUT
            // 
            this.LB_OUTPUT.BackColor = System.Drawing.Color.Black;
            this.LB_OUTPUT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_OUTPUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_OUTPUT.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LB_OUTPUT.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LB_OUTPUT.ForeColor = System.Drawing.Color.White;
            this.LB_OUTPUT.FormattingEnabled = true;
            this.LB_OUTPUT.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LB_OUTPUT.Location = new System.Drawing.Point(3, 484);
            this.LB_OUTPUT.Name = "LB_OUTPUT";
            this.LB_OUTPUT.Size = new System.Drawing.Size(428, 49);
            this.LB_OUTPUT.TabIndex = 17;
            this.LB_OUTPUT.TabStop = false;
            this.LB_OUTPUT.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LB_OUTPUT_DrawItem);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LB_COMMANDS, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(428, 47);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // LB_COMMANDS
            // 
            this.LB_COMMANDS.BackColor = System.Drawing.Color.Black;
            this.LB_COMMANDS.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LB_COMMANDS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_COMMANDS.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.LB_COMMANDS.Font = new System.Drawing.Font("Franklin Gothic Book", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LB_COMMANDS.ForeColor = System.Drawing.Color.White;
            this.LB_COMMANDS.FormattingEnabled = true;
            this.LB_COMMANDS.Location = new System.Drawing.Point(3, 3);
            this.LB_COMMANDS.Name = "LB_COMMANDS";
            this.LB_COMMANDS.Size = new System.Drawing.Size(422, 41);
            this.LB_COMMANDS.TabIndex = 19;
            this.LB_COMMANDS.TabStop = false;
            this.LB_COMMANDS.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.LB_COMMANDS_DrawItem);
            // 
            // TimerSpk
            // 
            this.TimerSpk.Enabled = true;
            this.TimerSpk.Interval = 1000;
            this.TimerSpk.Tick += new System.EventHandler(this.TimerSpk_Tick);
            // 
            // MrSmith
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(434, 536);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Cursor = System.Windows.Forms.Cursors.Cross;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(450, 575);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 575);
            this.Name = "MrSmith";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mrs. Smith";
            this.Load += new System.EventHandler(this.MrSmith_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Timer TimerSpk;
        private TableLayoutPanel tableLayoutPanel2;
        private ListBox LB_OUTPUT;
        private PictureBox pictureBox1;
        private ListBox LB_COMMANDS;
    }
}