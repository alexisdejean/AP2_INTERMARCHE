namespace AP2_INTERMARCHE
{
    partial class attrib_com_R
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
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            listView2 = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            Zone = new ComboBox();
            Valider_attrib = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            listView1.Location = new Point(12, 51);
            listView1.Name = "listView1";
            listView1.Size = new Size(284, 315);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Libelle";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Status";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 90;
            // 
            // listView2
            // 
            listView2.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6 });
            listView2.Location = new Point(535, 51);
            listView2.Name = "listView2";
            listView2.Size = new Size(253, 315);
            listView2.TabIndex = 1;
            listView2.UseCompatibleStateImageBehavior = false;
            listView2.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ID";
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Nom";
            columnHeader5.TextAlign = HorizontalAlignment.Center;
            columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Prénom";
            columnHeader6.TextAlign = HorizontalAlignment.Right;
            columnHeader6.Width = 90;
            // 
            // Zone
            // 
            Zone.FormattingEnabled = true;
            Zone.Location = new Point(333, 111);
            Zone.Name = "Zone";
            Zone.Size = new Size(151, 28);
            Zone.TabIndex = 2;
            // 
            // Valider_attrib
            // 
            Valider_attrib.Location = new Point(360, 237);
            Valider_attrib.Name = "Valider_attrib";
            Valider_attrib.Size = new Size(94, 29);
            Valider_attrib.TabIndex = 3;
            Valider_attrib.Text = "Valider";
            Valider_attrib.UseVisualStyleBackColor = true;
            // 
            // attrib_com_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Valider_attrib);
            Controls.Add(Zone);
            Controls.Add(listView2);
            Controls.Add(listView1);
            Name = "attrib_com_R";
            Text = "attrib_com_R";
            ResumeLayout(false);
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ListView listView2;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ComboBox Zone;
        private Button Valider_attrib;
    }
}