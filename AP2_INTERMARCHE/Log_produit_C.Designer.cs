namespace AP2_INTERMARCHE
{
    partial class Log_produit_C
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
            List_Logs = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            SuspendLayout();
            // 
            // List_Logs
            // 
            List_Logs.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            List_Logs.Location = new Point(46, 35);
            List_Logs.Name = "List_Logs";
            List_Logs.Size = new Size(700, 378);
            List_Logs.TabIndex = 0;
            List_Logs.UseCompatibleStateImageBehavior = false;
            List_Logs.View = View.Details;
            List_Logs.SelectedIndexChanged += List_Logs_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "id";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Message";
            columnHeader2.Width = 120;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Code palette";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Code stockage";
            columnHeader4.Width = 160;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Produit";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Quantitée";
            // 
            // Log_produit_C
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(List_Logs);
            Name = "Log_produit_C";
            Text = "Log_produit_C";
            Load += Log_produit_C_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView List_Logs;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
    }
}