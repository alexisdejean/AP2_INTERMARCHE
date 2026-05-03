using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    public partial class ModifierUsers : Form
    {
        public ModifierUsers()
        {
            InitializeComponent();
            btn_ajouter.Click += btn_ajouter_Click;
            cb_role_add.SelectedIndexChanged += cb_role_add_SelectedIndexChanged;
        }

        private void ModifierUsers_Load(object sender, EventArgs e)
        {
            cb_user_list.Items.Clear();
            cb_role_add.Items.Clear();
            cb_zone_add.Items.Clear();

            string connexion = global.connection;

            using (SqlConnection link = new SqlConnection(connexion))
            using (SqlCommand commande = new SqlCommand("UtilisateurAffichage", link))
            {
                try
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    link.Open();
                    SqlDataReader dr = commande.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string nom = dr.GetString(1);
                        string prenom = dr.GetString(2);
                        cb_user_list.Items.Add(id.ToString() + " " + prenom + " " + nom);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur chargement utilisateurs : " + ex.Message);
                }
            }

            using (SqlConnection link = new SqlConnection(connexion))
            using (SqlCommand commande = new SqlCommand("afficherlesroles", link))
            {
                try
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    link.Open();
                    SqlDataReader dr = commande.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string libelle = dr.GetString(1);
                        cb_role_add.Items.Add(id.ToString() + " " + libelle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur chargement rôles : " + ex.Message);
                }
            }

            using (SqlConnection link = new SqlConnection(connexion))
            using (SqlCommand commande = new SqlCommand("afficherleszones", link))
            {
                try
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    link.Open();
                    SqlDataReader dr = commande.ExecuteReader();
                    while (dr.Read())
                    {
                        int id = dr.GetInt32(0);
                        string libelle = dr.GetString(1);
                        cb_zone_add.Items.Add(id.ToString() + " " + libelle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur chargement zones : " + ex.Message);
                }
            }

            label6.Visible = false;
            cb_zone_add.Visible = false;
        }

        private void cb_user_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_nom.Text = string.Empty;
            txt_identifiant.Text = string.Empty;
            txt_prenom.Text = string.Empty;
            txt_password.Text = string.Empty;
            cb_zone_add.SelectedIndex = -1;
            cb_role_add.SelectedIndex = -1;
            label6.Visible = false;
            cb_zone_add.Visible = false;

            if (cb_user_list.SelectedItem == null)
            {
                return;
            }

            string texte = cb_user_list.SelectedItem.ToString()!;
            int id = int.Parse(texte.Split(' ')[0]);

            string connexion = global.connection;
            using (SqlConnection link = new SqlConnection(connexion))
            using (SqlCommand commande = new SqlCommand("InformationsUtilisateurById", link))
            {
                try
                {
                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    link.Open();
                    SqlDataReader dr = commande.ExecuteReader();

                    if (dr.Read())
                    {
                        txt_nom.Text = dr.GetString(0);
                        txt_prenom.Text = dr.GetString(1);
                        txt_identifiant.Text = dr.GetString(2);
                        txt_password.Text = string.Empty;

                        int idRole = dr.GetInt32(4);
                        foreach (string item in cb_role_add.Items)
                        {
                            if (int.Parse(item.Split(' ')[0]) == idRole)
                            {
                                cb_role_add.SelectedItem = item;
                                break;
                            }
                        }

                        if (!dr.IsDBNull(5))
                        {
                            int idZone = dr.GetInt32(5);
                            label6.Visible = true;
                            cb_zone_add.Visible = true;
                            foreach (string item in cb_zone_add.Items)
                            {
                                if (int.Parse(item.Split(' ')[0]) == idZone)
                                {
                                    cb_zone_add.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la recherche utilisateur : " + ex.Message);
                }
            }
        }

        private void cb_role_add_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_role_add.SelectedItem == null)
            {
                return;
            }

            string texte = cb_role_add.SelectedItem.ToString()!;
            int idRole = int.Parse(texte.Split(' ')[0]);

            if (idRole == 2)
            {
                label6.Visible = true;
                cb_zone_add.Visible = true;
            }
            else
            {
                label6.Visible = false;
                cb_zone_add.Visible = false;
                cb_zone_add.SelectedIndex = -1;
            }
        }

        private void btn_ajouter_Click(object sender, EventArgs e)
        {
            if (cb_user_list.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un utilisateur.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_nom.Text) || string.IsNullOrWhiteSpace(txt_prenom.Text) ||
                string.IsNullOrWhiteSpace(txt_identifiant.Text) || cb_role_add.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir le nom, prénom, identifiant et sélectionner un rôle.");
                return;
            }

            string roleTexte = cb_role_add.SelectedItem.ToString()!;
            int idRole = int.Parse(roleTexte.Split(' ')[0]);

            if (idRole == 2 && cb_zone_add.SelectedItem == null)
            {
                MessageBox.Show("Ce rôle nécessite une zone. Veuillez en sélectionner une.");
                return;
            }

            string texteUser = cb_user_list.SelectedItem.ToString()!;
            int idUser = int.Parse(texteUser.Split(' ')[0]);
            string identifiant = txt_identifiant.Text.Trim();

            string? mdpFinal = null;
            if (!string.IsNullOrWhiteSpace(txt_password.Text))
            {
                mdpFinal = global.HashPassword(txt_password.Text);
            }

            int? codeZone = null;
            if (cb_zone_add.Visible && cb_zone_add.SelectedItem != null)
            {
                codeZone = int.Parse(cb_zone_add.SelectedItem.ToString()!.Split(' ')[0]);
            }

            string connexion = global.connection;
            using (SqlConnection link = new SqlConnection(connexion))
            using (SqlCommand commande = new SqlCommand("ModifierUtilisateur", link))
            {
                try
                {
                    link.Open();

                    if (IdentifiantExiste(link, identifiant, idUser))
                    {
                        MessageBox.Show("Cet identifiant existe déjà. Veuillez en choisir un autre.", "Identifiant déjà utilisé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    commande.CommandType = CommandType.StoredProcedure;
                    commande.Parameters.Add("@id", SqlDbType.Int).Value = idUser;
                    commande.Parameters.Add("@nom", SqlDbType.VarChar).Value = txt_nom.Text.Trim();
                    commande.Parameters.Add("@prenom", SqlDbType.VarChar).Value = txt_prenom.Text.Trim();
                    commande.Parameters.Add("@identifiant", SqlDbType.VarChar).Value = identifiant;
                    commande.Parameters.Add("@motdepasse", SqlDbType.VarChar).Value = (object?)mdpFinal ?? DBNull.Value;
                    commande.Parameters.Add("@id_role", SqlDbType.Int).Value = idRole;
                    commande.Parameters.Add("@code_zone", SqlDbType.Int).Value = (object?)codeZone ?? DBNull.Value;

                    commande.ExecuteNonQuery();
                    MessageBox.Show("Utilisateur modifié avec succès !");

                    cb_user_list.SelectedIndex = -1;
                    txt_nom.Clear();
                    txt_prenom.Clear();
                    txt_identifiant.Clear();
                    txt_password.Clear();
                    cb_role_add.SelectedIndex = -1;
                    cb_zone_add.SelectedIndex = -1;
                    cb_zone_add.Visible = false;
                    label6.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la modification : " + ex.Message);
                }
            }
        }

        private static bool IdentifiantExiste(SqlConnection link, string identifiant, int idUser)
        {
            using SqlCommand verification = new SqlCommand(
                "SELECT COUNT(1) FROM Utilisateur WHERE Identifiant = @identifiant AND idUtilisateur <> @id", link);
            verification.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;
            verification.Parameters.Add("@id", SqlDbType.Int).Value = idUser;

            return Convert.ToInt32(verification.ExecuteScalar()) > 0;
        }
    }
}
