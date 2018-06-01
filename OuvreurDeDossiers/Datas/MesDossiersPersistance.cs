using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OuvreurDeDossiers
{
    /// <summary>
    /// Actions sur IO (ECRITURE DANS FICHIER .DAT).
    /// </summary>
    public class MesDossiersPersistance: DatasIO
    {
        private string MonFichier = "";

        public MesDossiersPersistance()
        {
            MonFichier = Environment.CurrentDirectory + "\\" + "MesDossiers.dat";
        }

        #region SAUVEGARDE
        /// <summary>
        /// Sauvegarde les données dans le fichier .dat.
        /// </summary>
        /// <param name="lesDossiers"></param>
        /// <returns>bool</returns>
        public override bool SauvegardeDansFichier(List<string> lesDossiers) {
            bool sauvegarde = false;
            if (FichierExiste(MonFichier) == true)
            {
                try
                {
                    StringBuilder contenu = new StringBuilder();
                            
                    foreach (string item in lesDossiers)
                    {
                        contenu.Append(item);
                        contenu.Append(Environment.NewLine);
                    }
                    var text = contenu.ToString();

                    File.WriteAllText(MonFichier, text);
                    sauvegarde = true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ooups ! Problème d'enregistement des datas.", ex);                    
                }
            }
            return sauvegarde;
        }

        #endregion

        #region LECTURE
        /// <summary>
        /// Liste les données dans le fichier.
        /// </summary>
        /// <returns>Liste de chemins a ouvrir.</returns>
        public override List<string> LectureDansFichier() 
        {
            List<string> listeLue = new List<string>();

            if (FichierExiste(MonFichier) == true)
            {
                try
                {
                    using (FileStream monStream = File.OpenRead(MonFichier))
                    {
                        using (StreamReader lecteur = new StreamReader(monStream) )
                        {
                            var line = lecteur.ReadLine();
                            listeLue.Add(line);
                            while (!lecteur.EndOfStream)
                            {
                                listeLue.Add(lecteur.ReadLine());
                            }
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    System.Windows.Forms.MessageBox.Show("Pas de données disponibles, voulez vous restaurer la liste par defaut ?", "Attention",System.Windows.Forms.MessageBoxButtons.YesNo);
                    MonFichier = Environment.CurrentDirectory + "\\" + "MesDossiers.dat";
                    File.Create(MonFichier);

                    // wait ! io is not mine...
                    System.Threading.Thread.Sleep(1000);

                    // next try
                    LectureDansFichier();
                }
                catch (Exception e)
                {
                    throw new Exception("Ooups ! Problème de lecture des datas.", e);
                }
            }
            return listeLue;
        }
        #endregion

        ///// <summary>
        ///// Verifie l'existance du fichier texte.
        ///// </summary>
        ///// <returns>bool</returns>
        //private bool FichierExiste()
        //{
        //    return (File.Exists(MonFichier)) ? true : false;
        //}

    }
}