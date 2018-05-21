using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OuvreurDeDossiers
{
    public partial class Form1 : Form
    {
        List<string> MesDossiersImportants { get; set; }

        Point positionInitiale = new Point(10, 10);
        string ancienneValeur = "";
        MesDossiersServices datas;

        public Form1()
        {
            InitializeComponent();

            datas = new MesDossiersServices();

            TipAleatoire();

            // DEBUT.
            MesDossiers d = MesDossiers.Instance;
            MesDossiersImportants = d.Dossiers;

            InitializeCombo(comboChoixDossier, MesDossiersImportants);

            // Ouverture du dossier séléctionné.
            buttonOuvrir.Click += (s,e) => {
                if (comboChoixDossier.SelectedItem != null)
                {
                    StartProgs.AppOpener Ouvreur = StartProgs.AppOpener.Instance;
                    Ouvreur.Chemin = comboChoixDossier.SelectedItem.ToString();
                    try
                    {
                        Ouvreur.OuvreLeDossier();
                    }
                    catch (Exception remontee)
                    {
                        MessageBox.Show(remontee.Message);
                        throw;
                    }
                }
            };

            /// <summary>
            /// Drag window.
            /// </summary>
            /// <param name="sender">Form</param>
            /// <param name="e">Mouse event</param>
            this.MouseDown += (se, ev) => {
                if (ev.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                }
            };

        }


        #region - NAVIGATION ENTRE GROUPBOXES -
        private void ButtonEditerDossiers_Click(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null) {
                ancienneValeur = comboChoixDossier.SelectedItem.ToString();
                AfficheLeGroupe(affichage, groupModifier.Name);
            }
        }

        private void ButtonAjouterDossier_Click(object sender, EventArgs e)
        {
            textBoxAjouter.Text = "";
            AfficheLeGroupe(affichage, groupAjout.Name);
        }

        private void ButtonEffaceDossier_Click(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null)
            {
                AfficheLeGroupe(affichage, groupSupprimer.Name);
            }
        }

        List<GroupBox> affichage;
        private void Form1_Load(object sender, EventArgs e)
        {
            affichage = new List<GroupBox>() { groupExecution, groupAjout, groupModifier, groupSupprimer };
            PositionneAffichage(affichage);
            AfficheLeGroupe(affichage, groupExecution.Name);
        }

        private void PositionneAffichage(List<GroupBox> elements)
        {
            foreach (var item in elements)
            {
                item.Location = positionInitiale;
            }
        }

        private void AfficheLeGroupe(List<GroupBox> groupes, string nomDuGroupe)
        {
            TipAleatoire();
            foreach (var item in groupes)
            {
                item.Visible = false; // tous invisibles
                bool ok = (item.Name.Equals(nomDuGroupe))? item.Visible = true : item.Visible = false;
            }
        }

        // APPUI TOUCHE ESC.
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
        }

        #endregion

        // AJOUT ok
        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            // Ajouter le dossier dans la liste
            var entree = textBoxAjouter.Text;
            bool sortie = false;

            // TODO: refactoriser ici
            if (entree == "")
            {
                sortie = true;
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
            if (!sortie)
            {
                datas.AjouteDossier(entree, MesDossiersImportants);
                MesDossiersImportants.Add(entree);
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        private void ComboChoixDossier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null)
            {
                textBoxModifier.Text = comboChoixDossier.SelectedItem.ToString();
                textBoxSupprimer.Text = comboChoixDossier.SelectedItem.ToString();
            }
        }

        // SUPPRESSION
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            // Enlever le dossier de la liste !!!
            datas.SupprimeDossier(textBoxSupprimer.Text ,MesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        // MODIFICATION
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            // Modifier le dossier dans la liste !!!
            datas.ModifieDossier(ancienneValeur, textBoxModifier.Text, MesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        // FERMETURE APPLICATION
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            datas.SauvegardeDossiers(MesDossiersImportants);
            
            DialogResult dialogResult = MessageBox.Show("Vraiement quitter ?",
                      "CONFIRMER LA FERMETURE", 
                      MessageBoxButtons.YesNo, 
                      MessageBoxIcon.Warning, 
                      MessageBoxDefaultButton.Button1);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }

        }

        /// <summary>
        /// Initialization du combo avec les données de la liste.
        /// </summary>
        /// <param name="cbx"></param>
        /// <param name="listeDesDossiers"></param>
        private void InitializeCombo(ComboBox cbx, List<string> listeDesDossiers)
        {
            cbx.DataSource = null;
            cbx.DataSource = listeDesDossiers;
            cbx.SelectedIndex = (listeDesDossiers.Count > 1) ? cbx.SelectedIndex = 0 : cbx.SelectedIndex = -1;
            
        }

        /// <summary>
        /// Tip aleatoire.
        /// </summary>
        void TipAleatoire()
        {
            string[] tips = new string[]{
                "ALT + F4 > quitter",
                "ESC > annuler",
                "Bouton C > ajouter",
                "Bouton U > modifier",
                "Bouton D > éffacer"
            };
            int nbTips = tips.Length;
            Random rd = new Random();
            labelTips.Text = tips[rd.Next(nbTips)].ToString();
        }

        #region [Drag Form]
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        

        #endregion
    }
}