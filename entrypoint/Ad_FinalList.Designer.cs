namespace entrypoint
{
    partial class Ad_FinalList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.appListDataGrid = new System.Windows.Forms.DataGridView();
            this.appListSort = new System.Windows.Forms.ComboBox();
            this.btnAppListSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.appListDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::entrypoint.Properties.Resources.close_svgrepo_com;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(193, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // appListDataGrid
            // 
            this.appListDataGrid.AllowUserToAddRows = false;
            this.appListDataGrid.AllowUserToDeleteRows = false;
            this.appListDataGrid.AllowUserToResizeColumns = false;
            this.appListDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appListDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.appListDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appListDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.appListDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appListDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.appListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.appListDataGrid.DefaultCellStyle = dataGridViewCellStyle19;
            this.appListDataGrid.Location = new System.Drawing.Point(24, 72);
            this.appListDataGrid.Name = "appListDataGrid";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appListDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.appListDataGrid.RowHeadersVisible = false;
            this.appListDataGrid.Size = new System.Drawing.Size(675, 425);
            this.appListDataGrid.TabIndex = 32;
            this.appListDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.appListDataGrid_CellContentClick);
            this.appListDataGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.appListDataGrid_CellFormatting);
            // 
            // appListSort
            // 
            this.appListSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.appListSort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appListSort.FormattingEnabled = true;
            this.appListSort.Items.AddRange(new object[] {
            "Sort by Examination Date (Asc)",
            "Sort by Last Name (A-Z)",
            "Sort by Average Score"});
            this.appListSort.Location = new System.Drawing.Point(396, 28);
            this.appListSort.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.appListSort.Name = "appListSort";
            this.appListSort.Size = new System.Drawing.Size(204, 25);
            this.appListSort.TabIndex = 31;
            this.appListSort.Text = "Sort by Examination Date(Asc)";
            this.appListSort.SelectedIndexChanged += new System.EventHandler(this.appListSort_SelectedIndexChanged);
            // 
            // btnAppListSearch
            // 
            this.btnAppListSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnAppListSearch.BackgroundImage = global::entrypoint.Properties.Resources.search_svgrepo_com;
            this.btnAppListSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppListSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppListSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppListSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnAppListSearch.Location = new System.Drawing.Point(225, 30);
            this.btnAppListSearch.Name = "btnAppListSearch";
            this.btnAppListSearch.Size = new System.Drawing.Size(24, 22);
            this.btnAppListSearch.TabIndex = 29;
            this.btnAppListSearch.UseVisualStyleBackColor = false;
            this.btnAppListSearch.Click += new System.EventHandler(this.btnAppListSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(24, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 25);
            this.textBox1.TabIndex = 28;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(606, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 27);
            this.button2.TabIndex = 34;
            this.button2.Text = "Filter";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Ad_FinalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 500);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.appListDataGrid);
            this.Controls.Add(this.appListSort);
            this.Controls.Add(this.btnAppListSearch);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Ad_FinalList";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appListDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView appListDataGrid;
        private System.Windows.Forms.ComboBox appListSort;
        private System.Windows.Forms.Button btnAppListSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
    }
}