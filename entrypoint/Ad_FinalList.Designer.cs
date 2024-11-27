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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.appListDataGrid = new System.Windows.Forms.DataGridView();
            this.appListSort = new System.Windows.Forms.ComboBox();
            this.btnAppListSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
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
            this.button1.Location = new System.Drawing.Point(230, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 19);
            this.button1.TabIndex = 33;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // appListDataGrid
            // 
            this.appListDataGrid.AllowUserToAddRows = false;
            this.appListDataGrid.AllowUserToDeleteRows = false;
            this.appListDataGrid.AllowUserToResizeColumns = false;
            this.appListDataGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appListDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.appListDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.appListDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.appListDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appListDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.appListDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.appListDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.appListDataGrid.Location = new System.Drawing.Point(61, 73);
            this.appListDataGrid.Name = "appListDataGrid";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.appListDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.appListDataGrid.RowHeadersVisible = false;
            this.appListDataGrid.Size = new System.Drawing.Size(661, 425);
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
            "Sort by First name (A-Z)"});
            this.appListSort.Location = new System.Drawing.Point(518, 31);
            this.appListSort.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.appListSort.Name = "appListSort";
            this.appListSort.Size = new System.Drawing.Size(204, 25);
            this.appListSort.TabIndex = 31;
            this.appListSort.Text = "Sort by Examination Date(Asc)";
            // 
            // btnAppListSearch
            // 
            this.btnAppListSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnAppListSearch.BackgroundImage = global::entrypoint.Properties.Resources.search_svgrepo_com;
            this.btnAppListSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAppListSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAppListSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAppListSearch.ForeColor = System.Drawing.Color.Transparent;
            this.btnAppListSearch.Location = new System.Drawing.Point(262, 31);
            this.btnAppListSearch.Name = "btnAppListSearch";
            this.btnAppListSearch.Size = new System.Drawing.Size(24, 22);
            this.btnAppListSearch.TabIndex = 29;
            this.btnAppListSearch.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(61, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(195, 25);
            this.textBox1.TabIndex = 28;
            // 
            // Ad_FinalList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 534);
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
    }
}