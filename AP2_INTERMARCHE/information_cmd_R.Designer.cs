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
            SuspendLayout();
            // 
            // tb_commande
            // 
            tb_commande.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            tb_commande.Location = new Point(75, 65);
            tb_commande.Name = "tb_commande";
            tb_commande.Size = new Size(785, 403);
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
            // information_cmd_R
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(929, 556);
            Controls.Add(tb_commande);
            Name = "information_cmd_R";
            Text = "information_cmd_R";
            Load += information_cmd_R_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView tb_commande;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
    }
}