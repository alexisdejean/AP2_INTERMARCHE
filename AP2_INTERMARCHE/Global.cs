
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace AP2_INTERMARCHE
{
    internal class global
    {
        public static string connection = @"Server=MSI;Database=bdd_intermarche;Trusted_Connection=True;TrustServerCertificate=True;";
        public static int role = 0;
        public static int user = 0;

        public static Color BackgroundColor => Color.FromArgb(243, 246, 241);
        public static Color SurfaceColor => Color.White;
        public static Color PrimaryColor => Color.FromArgb(29, 94, 52);
        public static Color PrimaryAccentColor => Color.FromArgb(55, 136, 73);
        public static Color TextPrimaryColor => Color.FromArgb(32, 37, 41);
        public static Color TextSecondaryColor => Color.FromArgb(90, 101, 110);
        public static Color BorderColor => Color.FromArgb(211, 218, 223);

        public static void ApplyTheme(Form form)
        {
            form.BackColor = BackgroundColor;
            form.ForeColor = TextPrimaryColor;
            ApplyThemeToChildren(form.Controls);
        }

        public static Panel CreateHeroPanel(string title, string subtitle, string detail)
        {
            Panel heroPanel = new Panel
            {
                BackColor = PrimaryColor,
                BorderStyle = BorderStyle.None,
                Size = new Size(980, 136)
            };

            Label titleLabel = new Label
            {
                AutoSize = false,
                Text = title,
                ForeColor = Color.White,
                Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold, GraphicsUnit.Point),
                Location = new Point(28, 20),
                Size = new Size(420, 40)
            };

            Label subtitleLabel = new Label
            {
                AutoSize = false,
                Text = subtitle,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(30, 62),
                Size = new Size(530, 46)
            };

            Label detailLabel = new Label
            {
                AutoSize = false,
                Text = detail,
                ForeColor = Color.FromArgb(228, 239, 231),
                Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point),
                Location = new Point(585, 24),
                Size = new Size(365, 84)
            };

            heroPanel.Controls.Add(titleLabel);
            heroPanel.Controls.Add(subtitleLabel);
            heroPanel.Controls.Add(detailLabel);

            return heroPanel;
        }

        public static string HashPassword(string password)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            StringBuilder resultat = new StringBuilder(hash.Length * 2);
            foreach (byte octet in hash)
            {
                resultat.Append(octet.ToString("x2"));
            }

            return resultat.ToString();
        }

        private static void ApplyThemeToChildren(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Panel panel:
                        if (panel.BackColor == default || panel.BackColor == SystemColors.Control)
                        {
                            panel.BackColor = SurfaceColor;
                        }
                        break;
                    case Button button:
                        button.BackColor = PrimaryAccentColor;
                        button.ForeColor = Color.White;
                        button.FlatStyle = FlatStyle.Flat;
                        button.FlatAppearance.BorderColor = PrimaryColor;
                        button.FlatAppearance.BorderSize = 0;
                        break;
                    case TextBox textBox:
                        textBox.BackColor = Color.White;
                        textBox.ForeColor = TextPrimaryColor;
                        textBox.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case ListView listView:
                        listView.BackColor = Color.White;
                        listView.ForeColor = TextPrimaryColor;
                        break;
                    case DataGridView dataGridView:
                        dataGridView.BackgroundColor = Color.White;
                        dataGridView.BorderStyle = BorderStyle.FixedSingle;
                        break;
                    case Label label:
                        if (label.ForeColor == default || label.ForeColor == SystemColors.ControlText)
                        {
                            label.ForeColor = TextPrimaryColor;
                        }
                        break;
                }

                if (control is GroupBox groupBox)
                {
                    groupBox.ForeColor = TextPrimaryColor;
                }

                if (control.Controls.Count > 0)
                {
                    ApplyThemeToChildren(control.Controls);
                }
            }
        }
    }
}
