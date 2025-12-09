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
            global.connection = @"Server=MSI;Database=bdd_intermarche;Trusted_Connection=True;TrustServerCertificate=True;";
            if (ValidationIdentitee(id, mdp))
            {
                if(ValidationRole(id, mdp))
                {
                    MessageBox.Show("Connexion Réussie !", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (global.role == 1)
                    {
                        home_R connecte = new home_R();
                        connecte.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (global.role == 2)
                        {
                            home_P connectet = new home_P();
                            connectet.Show();
                            this.Hide();
                        }
                        else
                        {
                            home_C connectee = new home_C();
                            connectee.Show();
                            this.Hide();
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Rôle inconnu", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                    
            else
            {
                MessageBox.Show("Identifiants incorrects", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidationIdentitee(string identifiant, string mot_de_passe)
        {
            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand commande = new SqlCommand("VerifieIdentification", connexion))
            {
                commande.CommandType = CommandType.StoredProcedure;
                commande.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;
                commande.Parameters.Add("@mot_de_passe", SqlDbType.VarChar, 255).Value = mot_de_passe;

                connexion.Open();

                object result = commande.ExecuteScalar();
                return result != null && Convert.ToInt32(result) == 1;

                connexion.Close();
            }
        }
        private bool ValidationRole(string identifiant, string mot_de_passe)
        {
            string connectionString = global.connection;
            using (SqlConnection connexion = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("VerifierRole", connexion))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;

                connexion.Open();

                object result = command.ExecuteScalar();
                if (Convert.ToInt32(result) == 1)
                {
                    global.role = 1;
                    return true;
                }
                else
                {
                    if (Convert.ToInt32(result) == 2)
                    {
                        global.role = 2;
                        return true;
                    }
                    else
                    {
                        if (Convert.ToInt32(result) == 3)
                        {
                            global.role = 3;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                connexion.Close();
            }
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
