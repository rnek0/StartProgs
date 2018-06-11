using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using StartProgs.Entities;

namespace OuvreurDeDossiers
{
    /// <summary>
    /// Serializeur XML de la liste des dossiers.
    /// </summary>
    public class XmlSerialize : DatasIO
    {
        readonly string FichierXml = "";

        public XmlSerialize()
        {
            FichierXml = $@"{Environment.CurrentDirectory}\{DbConfig.DbName}.xml";
        }

        #region SAUVEGARDE

        public override bool SauvegardeDansFichier(List<string> lesDossiers, string dossier = "")
        {
            return SerializeListe(lesDossiers);
        }

        /// <summary>
        /// Serialize la liste des dossiers.
        /// </summary>
        public bool SerializeListe(List<string> liste)
        {
            bool result = false;
            FileStream fichier = new FileStream(FichierXml, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                serializer.Serialize(fichier, liste);
                result = true;
            }
            catch (IOException ex)
            {
                MessageBox.Show(" -> IOException parce que " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                MessageBox.Show("J'ai un soucis pour serializer les dossiers parce que " + ex.Message);
                throw;
            }
            finally
            {
                fichier.Close();
            }
            return result;
        }
        #endregion

        #region LECTURE

        public override List<string> LectureDansFichier()
        {
            return DeSerializeListe();
        }

        /// <summary>
        /// Deserialize la liste des dossiers.
        /// </summary>
        /// <returns>ListeDeTaches</returns>
        public List<string> DeSerializeListe()
        {
            List<string> lesDossiers = new List<string>();

            if (string.IsNullOrEmpty( FichierXml ) || (FichierExiste(FichierXml) == false))
            {
                return lesDossiers;
            }

            FileStream fichier = new FileStream(FichierXml, FileMode.Open);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
                lesDossiers = (List<string>)serializer.Deserialize(fichier);
            }
            catch (Exception ex)
            {
                MessageBox.Show(" -> Pas de deserialization des dossiers parce que " + ex.Message);
            }
            finally
            {
                fichier.Close();
            }
            return lesDossiers;
        }
        #endregion

    }
}