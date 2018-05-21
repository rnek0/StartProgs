using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OuvreurDeDossiers
{
    public partial class Form1 : Form
    {
        List<string> mesDossiersImportants;
        Point positionInitiale = new Point(10, 10);
        string ancienneValeur = "";

        public Form1()
        {
            InitializeComponent();
            TipAleatoire();
            mesDossiersImportants = MesDossiers.Instance.Dossiers;
            InitializeCombo(comboChoixDossier, mesDossiersImportants);

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
        }

        private void InitializeCombo(ComboBox cbx, List<string> listeDesDossiers)
        {
            cbx.DataSource = null;
            cbx.DataSource = listeDesDossiers;
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

        #region - NAVIGATION ENTRE GROUPBOXES -
        private void ButtonEditerDossiers_Click(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null) {
                ancienneValeur = comboChoixDossier.SelectedItem.ToString();
                AfficheLeGroupe(affichage, groupModifier.Name);
            }
        }

        private void buttonAjouterDossier_Click(object sender, EventArgs e)
        {
            textBoxAjouter.Text = "";
            AfficheLeGroupe(affichage, groupAjout.Name);
        }

        private void buttonEffaceDossier_Click(object sender, EventArgs e)
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

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            // Ajouter le dossier dans la liste
            var entree = textBoxAjouter.Text;
            bool sortie = false;
            if (entree == "")
            {
                sortie = true;
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
            if (!sortie)
            {
                MesDossiersServices.AjouteDossier(textBoxAjouter.Text, mesDossiersImportants);
                AfficheLeGroupe(affichage, groupExecution.Name);
                InitializeCombo(comboChoixDossier, mesDossiersImportants);
            }
        }

        private void comboChoixDossier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboChoixDossier.SelectedItem != null)
            {
                textBoxModifier.Text = comboChoixDossier.SelectedItem.ToString();
                textBoxSupprimer.Text = comboChoixDossier.SelectedItem.ToString();
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            // Enlever le dossier de la liste !!!
            MesDossiersServices.SupprimeDossier(textBoxSupprimer.Text ,mesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, mesDossiersImportants);
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            // Modifier le dossier dans la liste !!!
            MesDossiersServices.ModifieDossier(ancienneValeur, textBoxModifier.Text, mesDossiersImportants);
            AfficheLeGroupe(affichage, groupExecution.Name);
            InitializeCombo(comboChoixDossier, mesDossiersImportants);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape )
            {
                AfficheLeGroupe(affichage, groupExecution.Name);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MesDossiersPersistance.SauvegardeDansFichier(mesDossiersImportants);
            //
            DialogResult dialogResult = MessageBox.Show("Vraiement quitter ?",
                      "CONFIRMER LA FERMETURE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign,true);

            if (dialogResult == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}