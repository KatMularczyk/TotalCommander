
namespace TotalCommander
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.list1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.list2 = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SortButton_list1_col1 = new System.Windows.Forms.Button();
            this.SortButton_list2_col1 = new System.Windows.Forms.Button();
            this.SortButton_list2_col2 = new System.Windows.Forms.Button();
            this.SortButton_list1_col2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(16, 31);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(69, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(552, 31);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(61, 24);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // list1
            // 
            this.list1.AllowDrop = true;
            this.list1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list1.HideSelection = false;
            this.list1.Location = new System.Drawing.Point(16, 64);
            this.list1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.list1.Name = "list1";
            this.list1.Size = new System.Drawing.Size(511, 474);
            this.list1.TabIndex = 3;
            this.list1.UseCompatibleStateImageBehavior = false;
            this.list1.View = System.Windows.Forms.View.Details;
            this.list1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.list1_ItemDrag);
            this.list1.DragDrop += new System.Windows.Forms.DragEventHandler(this.list1_DragDrop);
            this.list1.DragEnter += new System.Windows.Forms.DragEventHandler(this.list1_DragEnter);
            this.list1.DoubleClick += new System.EventHandler(this.list1_DoubleClick);
            this.list1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.list1_KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "CreationDate";
            this.columnHeader2.Width = 200;
            // 
            // list2
            // 
            this.list2.AllowDrop = true;
            this.list2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.list2.HideSelection = false;
            this.list2.Location = new System.Drawing.Point(536, 64);
            this.list2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.list2.Name = "list2";
            this.list2.Size = new System.Drawing.Size(511, 474);
            this.list2.TabIndex = 4;
            this.list2.UseCompatibleStateImageBehavior = false;
            this.list2.View = System.Windows.Forms.View.Details;
            this.list2.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.list2_ItemDrag);
            this.list2.DragDrop += new System.Windows.Forms.DragEventHandler(this.list2_DragDrop);
            this.list2.DragEnter += new System.Windows.Forms.DragEventHandler(this.list2_DragEnter);
            this.list2.DoubleClick += new System.EventHandler(this.list2_DoubleClick);
            this.list2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.list2_KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "CreationDate";
            this.columnHeader4.Width = 200;
            // 
            // SortButton_list1_col1
            // 
            this.SortButton_list1_col1.Location = new System.Drawing.Point(77, 75);
            this.SortButton_list1_col1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SortButton_list1_col1.Name = "SortButton_list1_col1";
            this.SortButton_list1_col1.Size = new System.Drawing.Size(21, 16);
            this.SortButton_list1_col1.TabIndex = 5;
            this.SortButton_list1_col1.Text = "^";
            this.SortButton_list1_col1.UseVisualStyleBackColor = true;
            this.SortButton_list1_col1.Click += new System.EventHandler(this.SortButton_list1_col1_Click);
            // 
            // SortButton_list2_col1
            // 
            this.SortButton_list2_col1.Location = new System.Drawing.Point(605, 75);
            this.SortButton_list2_col1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SortButton_list2_col1.Name = "SortButton_list2_col1";
            this.SortButton_list2_col1.Size = new System.Drawing.Size(24, 16);
            this.SortButton_list2_col1.TabIndex = 6;
            this.SortButton_list2_col1.Text = "^";
            this.SortButton_list2_col1.UseVisualStyleBackColor = true;
            this.SortButton_list2_col1.Click += new System.EventHandler(this.SortButton_list2_col1_Click);
            // 
            // SortButton_list2_col2
            // 
            this.SortButton_list2_col2.Location = new System.Drawing.Point(909, 75);
            this.SortButton_list2_col2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SortButton_list2_col2.Name = "SortButton_list2_col2";
            this.SortButton_list2_col2.Size = new System.Drawing.Size(24, 16);
            this.SortButton_list2_col2.TabIndex = 7;
            this.SortButton_list2_col2.Text = "^";
            this.SortButton_list2_col2.UseVisualStyleBackColor = true;
            this.SortButton_list2_col2.Click += new System.EventHandler(this.SortButton_list2_col2_Click);
            // 
            // SortButton_list1_col2
            // 
            this.SortButton_list1_col2.Location = new System.Drawing.Point(387, 75);
            this.SortButton_list1_col2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SortButton_list1_col2.Name = "SortButton_list1_col2";
            this.SortButton_list1_col2.Size = new System.Drawing.Size(24, 16);
            this.SortButton_list1_col2.TabIndex = 8;
            this.SortButton_list1_col2.Text = "^";
            this.SortButton_list1_col2.UseVisualStyleBackColor = true;
            this.SortButton_list1_col2.Click += new System.EventHandler(this.SortButton_list1_col2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.SortButton_list1_col2);
            this.Controls.Add(this.SortButton_list2_col2);
            this.Controls.Add(this.SortButton_list2_col1);
            this.Controls.Add(this.SortButton_list1_col1);
            this.Controls.Add(this.list2);
            this.Controls.Add(this.list1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListView list1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView list2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button SortButton_list1_col1;
        private System.Windows.Forms.Button SortButton_list2_col1;
        private System.Windows.Forms.Button SortButton_list2_col2;
        private System.Windows.Forms.Button SortButton_list1_col2;
    }
}

