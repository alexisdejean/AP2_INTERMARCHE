namespace AP2_INTERMARCHE
{
    partial class information_cmd_R
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
            tb_commande = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            tb_terminer = new ListView();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            SuspendLayout();
            // 
            // tb_commande
            // 
            tb_commande.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            tb_commande.Location = new Point(76, 85);
            tb_commande.Name = "tb_commande";
            tb_commande.Size = new Size(603, 403);
            tb_commande.TabIndex = 0;
            tb_commande.UseCompatibleStateImageBehavior = false;
            tb_commande.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Libelle";
            columnHeader2.TextAlign = HorizontalAlignment.Center;
            columnHeader2.Width = 300;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Nb produit";
            columnHeader3.TextAlign = HorizontalAlignment.Center;
            columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "status";
            columnHeader4.TextAlign = HorizontalAlignment.Center;
            columnHeader4.Width = 100;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 32);
            label1.Name = "label1";
            label1.Size = new Size(175, 20);
            label1.TabIndex = 1;
            label1.Text = "Commande non terminer";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1082, 32);
            label2.Name = "label2";
            label2.Size = new Size(146, 20);
            label2.TabIndex = 3;
            label2.Text = "Commande terminer";
            // 
            // tb_terminer
            // 
            tb_terminer.Columns.AddRange(new ColumnHeader[] { columnHeader5, columnHeader6, columnHeader7, columnHeader8 });
            tb_terminer.Location = new Point(833, 85);
            tb_terminer.Name = "tb_terminer";
            tb_terminer.Size = new Size(590, 403);
            tb_terminer.TabIndex = 4;
            tb_terminer.UseCompatibleStateImageBehavior = false;
            tb_terminer.View = View.Details;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "ID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Libelle";
            columnHeader6.TextAlign = HorizontalAlignment.Center;
            columnHeader6.Width = 300;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Nb produit";
            columnHeader7.TextAlign = HorizontalAlignment.Center;
            columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "status";
            columnHeader8.TextAlign = HorizontalAlignment.Center;
            columnHeader8.Width = 100;
            // 
            // information_cmd_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 618);
            Controls.Add(tb_terminer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tb_commande);
            Name = "information_cmd_R";
            Text = "information_cmd_R";
            Load += information_cmd_R_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView tb_commande;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Label label1;
        private Label label2;
        private ListView tb_terminer;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
    }
}