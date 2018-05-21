using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OuvreurDeDossiers
{
    /// <summary>
    /// Actions sur IO.
    /// </summary>
    public class MesDossiersPersistance
    {
        private string MonFichier = "";
        //List<string> Dossiers { get; set; }

        /// <summary>
        /// Ctor.
        /// </summary>
        public MesDossiersPersistance()
        {
            MonFichier = Environment.CurrentDirectory + "\\" + "MesDossiers.dat";
            //Dossiers = new List<string>();
        }

        #region SAUVEGARDE
        /// <summary>
        /// Sauvegarde les données dans le fichier.
        /// </summary>
        /// <param name="lesDossiers"></param>
        public void SauvegardeDansFichier(List<string> lesDossiers) {
            if (FichierExiste() == true)
            {
                try
                {
                    using (FileStream monStream = File.OpenWrite(MonFichier))
                    {
                        using (StreamWriter ecrivain = new StreamWriter(monStream) )
                        {
                            StringBuilder contenu = new StringBuilder();
                            //Dossiers.Clear();
                            foreach (string item in lesDossiers)
                            {
                                //Dossiers.Add(item);
                                contenu.Append(item);
                                contenu.Append(Environment.NewLine);
                            }
                            var text = contenu.ToString();
                            ecrivain.Write(text);
                        }
                    }
                }
                catch (System.IO.FileNotFoundException)
                {
                    // on crée et on re-essaie.
                    File.Create(MonFichier);
                    System.Threading.Thread.Sleep(100);                    
                    SauvegardeDansFichier(lesDossiers);
                    return;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ooups ! Problème d'enregistement des datas.", ex);                    
                }
            }
        }

        #endregion

        #region LECTURE
        /// <summary>
        /// Liste les données dans le fichier.
        /// </summary>
        /// <returns>Liste de chemins a ouvrir.</returns>
        public List<string> LectureDansFichier() 
        {
            List<string> listeLue = new List<string>();

            if (FichierExiste() == true)
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
                    //Dossiers = listeLue;
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

        /// <summary>
        /// Verifie l'existance du dossier.
        /// </summary>
        /// <returns>bool</returns>
        private bool FichierExiste()
        {
            return (File.Exists(MonFichier)) ? true : false;
        }

    }
}