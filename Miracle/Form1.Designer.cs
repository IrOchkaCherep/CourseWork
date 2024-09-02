
namespace Miracle
{
    partial class Menu
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
            this.ToHashTable = new System.Windows.Forms.Button();
            this.ToTree = new System.Windows.Forms.Button();
            this.ToSearch = new System.Windows.Forms.Button();
            this.ToDebug = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Subject = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Group = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.count = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToHashTable
            // 
            this.ToHashTable.Location = new System.Drawing.Point(305, 20);
            this.ToHashTable.Name = "ToHashTable";
            this.ToHashTable.Size = new System.Drawing.Size(270, 60);
            this.ToHashTable.TabIndex = 0;
            this.ToHashTable.Text = "Список Студентов";
            this.ToHashTable.UseVisualStyleBackColor = true;
            this.ToHashTable.Click += new System.EventHandler(this.ToHashTable_Click);
            // 
            // ToTree
            // 
            this.ToTree.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ToTree.Location = new System.Drawing.Point(590, 20);
            this.ToTree.Name = "ToTree";
            this.ToTree.Size = new System.Drawing.Size(270, 60);
            this.ToTree.TabIndex = 1;
            this.ToTree.Text = "Список комиссий";
            this.ToTree.UseVisualStyleBackColor = true;
            this.ToTree.Click += new System.EventHandler(this.ToTree_Click);
            // 
            // ToSearch
            // 
            this.ToSearch.Location = new System.Drawing.Point(20, 20);
            this.ToSearch.Name = "ToSearch";
            this.ToSearch.Size = new System.Drawing.Size(270, 60);
            this.ToSearch.TabIndex = 2;
            this.ToSearch.Text = "Поиск";
            this.ToSearch.UseVisualStyleBackColor = true;
            // 
            // ToDebug
            // 
            this.ToDebug.Location = new System.Drawing.Point(875, 20);
            this.ToDebug.Name = "ToDebug";
            this.ToDebug.Size = new System.Drawing.Size(270, 60);
            this.ToDebug.TabIndex = 3;
            this.ToDebug.Text = "Отладка\r\n";
            this.ToDebug.UseVisualStyleBackColor = true;
            this.ToDebug.Click += new System.EventHandler(this.ToDebug_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column1,
            this.Column3});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView1.Location = new System.Drawing.Point(590, 97);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(555, 609);
            this.dataGridView1.TabIndex = 7;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "№";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 30;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Фио";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 200;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Тип занятия";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Subject);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.Group);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(20, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(555, 125);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Введите параметры поиска";
            // 
            // Subject
            // 
            this.Subject.Location = new System.Drawing.Point(145, 69);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(390, 27);
            this.Subject.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(16, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Группа:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(16, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Дисциплина:";
            // 
            // Group
            // 
            this.Group.Location = new System.Drawing.Point(145, 36);
            this.Group.Name = "Group";
            this.Group.Size = new System.Drawing.Size(390, 27);
            this.Group.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(112, 585);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 70);
            this.button1.TabIndex = 27;
            this.button1.Text = "Выполнить\r\n";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(20, 686);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Количество сравнений при поиске:";
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(332, 684);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(56, 22);
            this.count.TabIndex = 29;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1167, 728);
            this.Controls.Add(this.count);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ToDebug);
            this.Controls.Add(this.ToSearch);
            this.Controls.Add(this.ToTree);
            this.Controls.Add(this.ToHashTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Есть гнев, торг, отрицание, дипрессия, а есть курсач";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ToHashTable;
        private System.Windows.Forms.Button ToTree;
        private System.Windows.Forms.Button ToSearch;
        private System.Windows.Forms.Button ToDebug;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.TextBox Group;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox count;
    }
}