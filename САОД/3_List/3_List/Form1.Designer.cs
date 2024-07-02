
namespace _3_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox = new System.Windows.Forms.ListBox();
            this.new_node = new System.Windows.Forms.TextBox();
            this.add_end = new System.Windows.Forms.Button();
            this.add_begin = new System.Windows.Forms.Button();
            this.show_all = new System.Windows.Forms.Button();
            this.add_before = new System.Windows.Forms.Button();
            this.new_node_index = new System.Windows.Forms.TextBox();
            this.index_add = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.index_get = new System.Windows.Forms.TextBox();
            this.get_by_index = new System.Windows.Forms.Button();
            this.remove = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.count = new System.Windows.Forms.Button();
            this.test_button = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 20;
            this.listBox.Location = new System.Drawing.Point(298, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(468, 324);
            this.listBox.TabIndex = 0;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // new_node
            // 
            this.new_node.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.new_node.Location = new System.Drawing.Point(122, 30);
            this.new_node.Name = "new_node";
            this.new_node.Size = new System.Drawing.Size(170, 26);
            this.new_node.TabIndex = 1;
            // 
            // add_end
            // 
            this.add_end.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_end.Location = new System.Drawing.Point(19, 70);
            this.add_end.Name = "add_end";
            this.add_end.Size = new System.Drawing.Size(120, 36);
            this.add_end.TabIndex = 2;
            this.add_end.Text = "Add End";
            this.add_end.UseVisualStyleBackColor = true;
            this.add_end.Click += new System.EventHandler(this.add_end_Click);
            // 
            // add_begin
            // 
            this.add_begin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_begin.Location = new System.Drawing.Point(172, 70);
            this.add_begin.Name = "add_begin";
            this.add_begin.Size = new System.Drawing.Size(120, 36);
            this.add_begin.TabIndex = 3;
            this.add_begin.Text = "Add Begin";
            this.add_begin.UseVisualStyleBackColor = true;
            this.add_begin.Click += new System.EventHandler(this.add_begin_Click);
            // 
            // show_all
            // 
            this.show_all.BackColor = System.Drawing.Color.Tan;
            this.show_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_all.Location = new System.Drawing.Point(299, 350);
            this.show_all.Name = "show_all";
            this.show_all.Size = new System.Drawing.Size(261, 36);
            this.show_all.TabIndex = 4;
            this.show_all.Text = "SHOW";
            this.show_all.UseVisualStyleBackColor = false;
            this.show_all.Click += new System.EventHandler(this.show_all_Click);
            // 
            // add_before
            // 
            this.add_before.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.add_before.Location = new System.Drawing.Point(15, 200);
            this.add_before.Name = "add_before";
            this.add_before.Size = new System.Drawing.Size(120, 36);
            this.add_before.TabIndex = 5;
            this.add_before.Text = "Add Before";
            this.add_before.UseVisualStyleBackColor = true;
            this.add_before.Click += new System.EventHandler(this.add_before_Click);
            // 
            // new_node_index
            // 
            this.new_node_index.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.new_node_index.Location = new System.Drawing.Point(122, 147);
            this.new_node_index.Name = "new_node_index";
            this.new_node_index.Size = new System.Drawing.Size(170, 26);
            this.new_node_index.TabIndex = 6;
            // 
            // index_add
            // 
            this.index_add.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.index_add.Location = new System.Drawing.Point(150, 200);
            this.index_add.Name = "index_add";
            this.index_add.Size = new System.Drawing.Size(120, 26);
            this.index_add.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "New Node";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "New Node";
            // 
            // index_get
            // 
            this.index_get.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.index_get.Location = new System.Drawing.Point(70, 250);
            this.index_get.Name = "index_get";
            this.index_get.Size = new System.Drawing.Size(61, 26);
            this.index_get.TabIndex = 10;
            // 
            // get_by_index
            // 
            this.get_by_index.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.get_by_index.Location = new System.Drawing.Point(150, 250);
            this.get_by_index.Name = "get_by_index";
            this.get_by_index.Size = new System.Drawing.Size(120, 36);
            this.get_by_index.TabIndex = 11;
            this.get_by_index.Text = "GetByIndex";
            this.get_by_index.UseVisualStyleBackColor = true;
            this.get_by_index.Click += new System.EventHandler(this.get_by_index_Click);
            // 
            // remove
            // 
            this.remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remove.Location = new System.Drawing.Point(150, 300);
            this.remove.Name = "remove";
            this.remove.Size = new System.Drawing.Size(120, 36);
            this.remove.TabIndex = 12;
            this.remove.Text = "Remove";
            this.remove.UseVisualStyleBackColor = true;
            this.remove.Click += new System.EventHandler(this.remove_Click);
            // 
            // clear
            // 
            this.clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clear.Location = new System.Drawing.Point(150, 350);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(120, 36);
            this.clear.TabIndex = 13;
            this.clear.Text = "Clear";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // count
            // 
            this.count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.count.Location = new System.Drawing.Point(15, 350);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(120, 36);
            this.count.TabIndex = 14;
            this.count.Text = "Count";
            this.count.UseVisualStyleBackColor = true;
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // test_button
            // 
            this.test_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.test_button.Location = new System.Drawing.Point(15, 300);
            this.test_button.Name = "test_button";
            this.test_button.Size = new System.Drawing.Size(120, 36);
            this.test_button.TabIndex = 15;
            this.test_button.Text = "TEST";
            this.test_button.UseVisualStyleBackColor = true;
            this.test_button.Click += new System.EventHandler(this.test_button_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "index";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(778, 413);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.test_button);
            this.Controls.Add(this.count);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.remove);
            this.Controls.Add(this.get_by_index);
            this.Controls.Add(this.index_get);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.index_add);
            this.Controls.Add(this.new_node_index);
            this.Controls.Add(this.add_before);
            this.Controls.Add(this.show_all);
            this.Controls.Add(this.add_begin);
            this.Controls.Add(this.add_end);
            this.Controls.Add(this.new_node);
            this.Controls.Add(this.listBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MyList";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.TextBox new_node;
        private System.Windows.Forms.Button add_end;
        private System.Windows.Forms.Button add_begin;
        private System.Windows.Forms.Button show_all;
        private System.Windows.Forms.Button add_before;
        private System.Windows.Forms.TextBox new_node_index;
        private System.Windows.Forms.TextBox index_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox index_get;
        private System.Windows.Forms.Button get_by_index;
        private System.Windows.Forms.Button remove;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button count;
        private System.Windows.Forms.Button test_button;
        private System.Windows.Forms.Label label3;
    }
}

