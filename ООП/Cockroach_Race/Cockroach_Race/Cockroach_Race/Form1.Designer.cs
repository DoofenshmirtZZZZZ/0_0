
namespace Cockroach_Race
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.FieldDraw = new System.Windows.Forms.Button();
            this.TimerBox = new System.Windows.Forms.TextBox();
            this.NCount = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // FieldDraw
            // 
            this.FieldDraw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FieldDraw.Location = new System.Drawing.Point(12, 13);
            this.FieldDraw.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.FieldDraw.Name = "FieldDraw";
            this.FieldDraw.Size = new System.Drawing.Size(303, 43);
            this.FieldDraw.TabIndex = 0;
            this.FieldDraw.Text = "Start";
            this.FieldDraw.UseVisualStyleBackColor = true;
            this.FieldDraw.Click += new System.EventHandler(this.FieldDraw_Click);
            // 
            // TimerBox
            // 
            this.TimerBox.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TimerBox.Location = new System.Drawing.Point(75, 73);
            this.TimerBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TimerBox.Name = "TimerBox";
            this.TimerBox.ReadOnly = true;
            this.TimerBox.Size = new System.Drawing.Size(240, 26);
            this.TimerBox.TabIndex = 1;
            // 
            // NCount
            // 
            this.NCount.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.NCount.Location = new System.Drawing.Point(12, 73);
            this.NCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NCount.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.NCount.Name = "NCount";
            this.NCount.Size = new System.Drawing.Size(57, 26);
            this.NCount.TabIndex = 2;
            this.NCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(321, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(871, 800);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label_result
            // 
            this.label_result.AutoSize = true;
            this.label_result.Location = new System.Drawing.Point(27, 123);
            this.label_result.Name = "label_result";
            this.label_result.Size = new System.Drawing.Size(0, 20);
            this.label_result.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1204, 841);
            this.Controls.Add(this.label_result);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.NCount);
            this.Controls.Add(this.TimerBox);
            this.Controls.Add(this.FieldDraw);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Race";
            ((System.ComponentModel.ISupportInitialize)(this.NCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FieldDraw;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox TimerBox;
        private System.Windows.Forms.NumericUpDown NCount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_result;
    }
}

