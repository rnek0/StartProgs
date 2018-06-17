using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StartProgs.MongoDBSerializer;

namespace UnitTestStartProgs
{
    /// <summary>
    /// Description résumée pour UnitTestMongoDB
    /// </summary>
    [TestClass]
    public class UnitTestMongoDB
    {
        MongoSerialize serializer = null;
        string Dossier_id = "";

        public UnitTestMongoDB()
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
            serializer = new MongoSerialize();
            Dossier_id = Guid.NewGuid().ToString();
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethodCreate()
        {
            //var Dossier_id = Guid.NewGuid().ToString();

            StartProgs.Entities.Dossier d = new StartProgs.Entities.Dossier {
                DossierID = Dossier_id,
                DossierName = $"Test avec MongoDB, avec le guid {Dossier_id}"
            };

            Assert.AreSame(serializer.Create(d), d,"Les deux objets sont pas les mêmes, la creation d'objet avec MongoDB est defectueuse !");

        }

        [TestMethod]
        public void TestMethodUpdate()
        {
            // Lister et recuperer le premier id
            //var l =  serializer.LectureDansFichier();
            StartProgs.Entities.Dossier dUpDate = new StartProgs.Entities.Dossier
            {
                DossierID = Dossier_id,
                DossierName = $"Test avec MongoDB, avec le guid {Guid.NewGuid().ToString()}"
            };

            Assert.IsTrue(serializer.Update(dUpDate),"Pas de update :(");
        }


        [TestMethod]
        public void TestMethodDelete()
        {
            StartProgs.Entities.Dossier dDelete = new StartProgs.Entities.Dossier
            {
                DossierID = Dossier_id,
                DossierName = $"Test avec MongoDB, avec le guid {Guid.NewGuid().ToString()}"
            };

            Assert.IsTrue(serializer.Delete(dDelete), "Pas de delete :(");

        }

    }
}
