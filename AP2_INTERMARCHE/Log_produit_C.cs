using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class Log_produit_C : Form
    {
        public Log_produit_C()
        {
            InitializeComponent();
        }

        private void Log_produit_C_Load(object sender, EventArgs e) // PROCÉDURE NON CONFIGURÉE
        {
            string connexion = global.connection;
            using SqlConnection link = new SqlConnection(connexion);
            using SqlCommand commande = new SqlCommand("AfficherLesLogs", link);
            {
                commande.CommandType = CommandType.StoredProcedure;
                link.Open();
                SqlDataReader datereader = commande.ExecuteReader();
                int id = 0;
                string libelle = "";
                int codePalette = 0;
                int codePaletteStockage = 0;
                string libelle_produit = "";
                int quantitee = 0;
                while (datereader.Read())
                {
                    MessageBox.Show(datereader.GetString(4), "Information");
                    id = datereader.GetInt32(0);
                    libelle = datereader.GetString(1);
                    codePalette = datereader.GetInt32(2);
                    codePaletteStockage = datereader.GetInt32(3);
                    libelle_produit = datereader.GetString(4);
                    quantitee = datereader.GetInt32(5);
                    ListViewItem item = new ListViewItem(id.ToString());
                    item.SubItems.Add(libelle);
                    item.SubItems.Add(codePalette.ToString());
                    item.SubItems.Add(codePaletteStockage.ToString());
                    item.SubItems.Add(libelle_produit);
                    item.SubItems.Add(quantitee.ToString());
                    List_Logs.Items.Add(item);
                }
                link.Close();

            }
        }

        private void List_Logs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
