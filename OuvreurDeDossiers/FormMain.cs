using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OuvreurDeDossiers
{
    public partial class FormMain : Form
    {
        List<string> MesDossiersImportants { get; set; }

        Point positionInitiale = new Point(10, 10);
        string ancienneValeur = "";
        IDatasOperations datas;

        /// <summary>
        /// Form App.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            // var choixSerialization = "file"; 
            var choixSerialization = "sqlite";
            // var choixSerialization = "xml";

            datas = new MesDossiersFichier(choixSerialization);

            MesDossiersImportants = datas.LireDossiers();

            TipAleatoire();

            InitializeCombo(comboChoixDossier, MesDossiersImportants);

            // Ouverture du dossier séléctionné.
            buttonOuvrir.Click += (s,e) =>
            {
                Ouvre();
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

            // Shortcuts.
            this.KeyDown += (se,ev) => {

                if (ev.KeyCode.Equals(Keys.Enter) && comboChoixDossier.Focus())
                {
                    Ouvre();
                }

                if (ev.KeyCode.Equals(Keys.F1))
                {
                    FormHelp formHelp = new FormHelp();
                    formHelp.ShowDialog();
                }

                if (ev.KeyCode.Equals(Keys.F5))
                {
                    buttonAjouterDossier.PerformClick();
                    textBoxAjouter.Focus();
                }

                if (ev.KeyCode.Equals(Keys.F6))
                {
                    buttonEditerDossiers.PerformClick();
                    textBoxModifier.Focus();
                }

                if (ev.KeyCode.Equals(Keys.F7))
                {
                    buttonEffaceDossier.PerformClick();
                }

                if (ev.KeyCode.Equals(Keys.F8))
                {
                    About about = new About();
                    about.ShowDialog();
                }

                // ESC(retour a l'écran principal).
                if (ev.KeyCode == Keys.Escape)
                {
                    AfficheLeGroupe(affichage, groupExecution.Name);
                }
            };
        }

        /// <summary>
        /// Opens folder.
        /// </summary>
        private void Ouvre()
        {
            if (comboChoixDossier.SelectedItem != null || comboChoixDossier.Focus())
            {
                StartProgs.AppOpener Ouvreur = StartProgs.AppOpener.Instance;

                if (comboChoixDossier.SelectedItem != null)
                {
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
            }
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
            textBoxAjouter.Focus();
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

        #endregion

        // Ajout.
        private void ButtonAjouter_Click(object sender, EventArgs e)
        {
            // TODO: enleve l'appel superflu !
            Ajoute();
        }

        /// <summary>
        /// Ajouter le dossier dans la liste.
        /// </summary>
        private void Ajoute()
        {
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
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        // Met a jour les champs pour modif ou suppression.
        private void ComboChoixDossier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null)
            {
                textBoxModifier.Text = comboChoixDossier.SelectedItem.ToString();
                textBoxSupprimer.Text = comboChoixDossier.SelectedItem.ToString();
            }
        }

        // Suppression.
        private void ButtonSupprimer_Click(object sender, EventArgs e)
        {
            datas.SupprimeDossier(textBoxSupprimer.Text ,MesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        // Modification.
        private void ButtonModifier_Click(object sender, EventArgs e)
        {
            datas.ModifieDossier(ancienneValeur, textBoxModifier.Text, MesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, MesDossiersImportants);
        }

        /// <summary>
        /// Fermeture de l'application.
        /// </summary>      
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            if (listeDesDossiers.Count > 0)
            {
                cbx.SelectedIndex = (listeDesDossiers.Count >= 0) ? cbx.SelectedIndex = 0 : cbx.SelectedIndex = -1;
            }
        }

        /// <summary>
        /// Tip aleatoire.
        /// </summary>
        void TipAleatoire()
        {
            string[] tips = new string[]{
                "ALT + F4 > Quitter",
                "ESC > Annuler",
                "Bouton C > Ajouter",
                "Bouton U > Modifier",
                "Bouton D > Effacer",
                "F5 > Ajouter",
                "F6 > Modifier",
                "F7 > Effacer",
                "F1 > Aide",
                "F8 > A propos"
            };
            int nbTips = tips.Length;
            Random rd = new Random();
            labelTips.Text = $"Tip: {tips[rd.Next(nbTips)]}";
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