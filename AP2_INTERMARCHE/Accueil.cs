using Microsoft.Data.SqlClient;
using System.Data;

namespace AP2_INTERMARCHE
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string id = txt_login.Text.Trim();
            string mdp = txt_mdp.Text;

            if (ValidationIdentitee(id, mdp))
            {
                MessageBox.Show("Connexion Réussie !", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                home_C connecte = new home_C();
                connecte.Show();
            }
            else
            {
                MessageBox.Show("Identifiants incorrects", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidationIdentitee(string identifiant, string mot_de_passe)
        {
            bool validation = false;
            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand commande = new SqlCommand("VerifieIdentification", connexion))
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@identifiant_user", SqlDbType.VarChar, 100).Value = identifiant;
                commande.Parameters.Add("@mot_de_passe", SqlDbType.VarChar, 200).Value = mot_de_passe;

                connexion.Open();

                object result = commande.ExecuteScalar();
                return result != null && Convert.ToInt32(result) == 1;
            };
        }
        private void VerifieRempli()
        {
            if (!string.IsNullOrEmpty(txt_login.Text) && !string.IsNullOrEmpty(txt_mdp.Text))
            {
                btn_login.Enabled = true;
            }
            else
            {
                btn_login.Enabled = false;
            }
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            VerifieRempli();
        }

        private void txt_login_TextChanged(object sender, EventArgs e)
        {
            VerifieRempli();
        }

        private void txt_mdp_TextChanged(object sender, EventArgs e)
        {
            VerifieRempli();
        }
    }
}
