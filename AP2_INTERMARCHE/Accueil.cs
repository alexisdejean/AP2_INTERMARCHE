using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;

namespace AP2_INTERMARCHE
{
    public partial class Accueil : Form
    {
        public Accueil()
        {
            InitializeComponent();
            ConfigurerInterface();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string id = txt_login.Text.Trim();
            string mdp = txt_mdp.Text;

            try
            {
                InitialiserComptesParDefaut();

                if (ValidationIdentitee(id, mdp))
                {
                    if (ValidationRole(id))
                    {
                        MessageBox.Show("Connexion réussie.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (global.role == 1)
                        {
                            home_R connecte = new home_R();
                            connecte.Owner = this;
                            Hide();
                            connecte.Show();
                        }
                        else if (global.role == 2)
                        {
                            home_P connecte = new home_P();
                            connecte.Owner = this;
                            Hide();
                            connecte.Show();
                        }
                        else
                        {
                            home_C connecte = new home_C();
                            connecte.Owner = this;
                            Hide();
                            connecte.Show();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rôle inconnu.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Identifiants incorrects.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connexion à la base impossible : {ex.Message}", "Erreur SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidationIdentitee(string identifiant, string mot_de_passe)
        {
            string connectionString = global.connection;
            using SqlConnection connexion = new SqlConnection(connectionString);
            using SqlCommand commande = new SqlCommand("VerifieIdentification", connexion);

            commande.CommandType = CommandType.StoredProcedure;
            commande.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;
            commande.Parameters.Add("@mot_de_passe", SqlDbType.VarChar, 255).Value = global.HashPassword(mot_de_passe);

            connexion.Open();
            object? result = commande.ExecuteScalar();
            return result != null && Convert.ToInt32(result) == 1;
        }

        private bool ValidationRole(string identifiant)
        {
            string connectionString = global.connection;
            using SqlConnection connexion = new SqlConnection(connectionString);
            using SqlCommand command = new SqlCommand("VerifierRole", connexion);

            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@identifiant", SqlDbType.VarChar, 100).Value = identifiant;

            connexion.Open();
            object? result = command.ExecuteScalar();
            int role = result == null ? 0 : Convert.ToInt32(result);

            if (role is >= 1 and <= 3)
            {
                global.role = role;
                return true;
            }

            return false;
        }

        private void VerifieRempli()
        {
            btn_login.Enabled = !string.IsNullOrEmpty(txt_login.Text) && !string.IsNullOrEmpty(txt_mdp.Text);
        }

        private void Accueil_Load(object sender, EventArgs e)
        {
            global.ApplyTheme(this);
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

        private void ConfigurerInterface()
        {
            Text = "Prep'Order | Connexion";
            MinimumSize = new Size(1100, 650);

            Panel heroPanel = global.CreateHeroPanel(
                "Prep'Order",
                "Piloter la préparation, l'attribution et le réapprovisionnement des commandes logistiques.",
                "Raison d'être : fluidifier les expéditions Intermarché, réduire les blocages terrain et fiabiliser les stocks en temps réel.");
            heroPanel.Location = new Point(70, 55);
            heroPanel.Size = new Size(980, 136);
            Controls.Add(heroPanel);

            Panel loginCard = new Panel
            {
                BackColor = global.SurfaceColor,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(390, 235),
                Size = new Size(470, 275)
            };

            label1.Text = "Connexion à la plateforme";
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(38, 24);
            label1.Size = new Size(390, 38);

            label2.Text = "Identifiant";
            label2.Location = new Point(42, 95);
            label2.Size = new Size(120, 24);

            txt_login.Location = new Point(42, 122);
            txt_login.Size = new Size(380, 30);

            label3.Text = "Mot de passe";
            label3.Location = new Point(42, 168);
            label3.Size = new Size(140, 24);

            txt_mdp.Location = new Point(42, 195);
            txt_mdp.Size = new Size(380, 30);

            btn_login.Text = "Entrer dans Prep'Order";
            btn_login.Location = new Point(42, 231);
            btn_login.Size = new Size(380, 36);

            loginCard.Controls.Add(label1);
            loginCard.Controls.Add(label2);
            loginCard.Controls.Add(txt_login);
            loginCard.Controls.Add(label3);
            loginCard.Controls.Add(txt_mdp);
            loginCard.Controls.Add(btn_login);
            Controls.Add(loginCard);

            Label helperLabel = new Label
            {
                AutoSize = false,
                Location = new Point(390, 520),
                Size = new Size(470, 42),
                Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point),
                ForeColor = global.TextSecondaryColor,
                Text = "L'application relie les responsables, préparateurs et caristes autour d'une même donnée de commande."
            };
            Controls.Add(helperLabel);

            heroPanel.BringToFront();
            loginCard.BringToFront();
        }

        private void InitialiserComptesParDefaut()
        {
            string connectionString = global.connection;
            using SqlConnection connexion = new SqlConnection(connectionString);
            connexion.Open();

            using SqlCommand commande = connexion.CreateCommand();
            commande.CommandText = @"
IF NOT EXISTS (SELECT 1 FROM Role)
BEGIN
    INSERT INTO Role (libelleRole) VALUES ('Responsable');
    INSERT INTO Role (libelleRole) VALUES ('Preparateur');
    INSERT INTO Role (libelleRole) VALUES ('Cariste');
END;

DECLARE @zonePreparateur INT = (SELECT TOP 1 codeZone FROM Zone ORDER BY codeZone);

UPDATE Utilisateur
SET MotDePasse = @hashAdminDemo
WHERE Identifiant = 'Admin.MD' AND MotDePasse <> @hashAdminDemo;

UPDATE Utilisateur
SET MotDePasse = @hashAdmini
WHERE Identifiant = 'admini' AND MotDePasse <> @hashAdmini;

UPDATE Utilisateur
SET MotDePasse = @hashPreparateurDemo
WHERE Identifiant = 'Preparateur.PL' AND MotDePasse <> @hashPreparateurDemo;

UPDATE Utilisateur
SET MotDePasse = @hashCaristeDemo
WHERE Identifiant = 'Cariste.SB' AND MotDePasse <> @hashCaristeDemo;

IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Identifiant = 'Admin.MD')
BEGIN
    EXEC AjouterUtilisateur
        @nom = 'Admin',
        @prenom = 'Demo',
        @identifiant = 'Admin.MD',
        @password = @hashAdminDemo,
        @id_role = 1,
        @code_zone = NULL;
END;

IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Identifiant = 'admini')
BEGIN
    EXEC AjouterUtilisateur
        @nom = 'Admin',
        @prenom = 'Test',
        @identifiant = 'admini',
        @password = @hashAdmini,
        @id_role = 1,
        @code_zone = NULL;
END;

IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Identifiant = 'Preparateur.PL')
BEGIN
    EXEC AjouterUtilisateur
        @nom = 'Preparateur',
        @prenom = 'Demo',
        @identifiant = 'Preparateur.PL',
        @password = @hashPreparateurDemo,
        @id_role = 2,
        @code_zone = @zonePreparateur;
END;

IF NOT EXISTS (SELECT 1 FROM Utilisateur WHERE Identifiant = 'Cariste.SB')
BEGIN
    EXEC AjouterUtilisateur
        @nom = 'Cariste',
        @prenom = 'Demo',
        @identifiant = 'Cariste.SB',
        @password = @hashCaristeDemo,
        @id_role = 3,
        @code_zone = NULL;
END;";
            commande.Parameters.Add("@hashAdminDemo", SqlDbType.VarChar, 255).Value = global.HashPassword("Admin123");
            commande.Parameters.Add("@hashAdmini", SqlDbType.VarChar, 255).Value = global.HashPassword("pass");
            commande.Parameters.Add("@hashPreparateurDemo", SqlDbType.VarChar, 255).Value = global.HashPassword("UserP123");
            commande.Parameters.Add("@hashCaristeDemo", SqlDbType.VarChar, 255).Value = global.HashPassword("UserC123");
            commande.ExecuteNonQuery();
        }
    }
}
