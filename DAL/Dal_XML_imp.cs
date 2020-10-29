using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BE;
using DS;
using System.Xml;


namespace DAL
{
    public class Dal_XML_imp
    {
        //Path du fichier de sauvegarde des serveurs
        private String pathXmlFile = System.AppDomain.CurrentDomain.BaseDirectory + Properties.Settings.Default.XmlSaveFileName;

        #region Constructors

        public Dal_XML_imp() { }

        #endregion

        #region Methods

        public SavedLists LoadFileXml()
        {
            if (File.Exists(pathXmlFile))
            {
                return ReadXmlFile();
            }

            return null;

        }

        public void WriteFileXml()
        {
            if (File.Exists(pathXmlFile))
            {
                File.Delete(pathXmlFile);
            }
            //WriteXmlFile3(DataSource.list_test, DataSource.list_tester, DataSource.list_trainee);
            //WriteXmlFile2(DataSource.list_tester);
            //WriteXmlFile2(DataSource.list_trainee);

        }

        public SavedLists ReadXmlFile()
        {
            SavedLists dsResult = null;

            try
            {
                var doc = new XmlDocument();

                doc.Load(pathXmlFile);

                var serializer = new XmlSerializer(typeof(SavedLists));

                using (TextReader reader = new StringReader(doc.InnerXml))
                {
                    dsResult = (SavedLists)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Erreur Read XmlFile : " + ex.Message); }

            return dsResult;

        }

        public void WriteXmlFiles()
        {

            if (File.Exists(pathXmlFile))
            {
                File.Delete(pathXmlFile);
            }

            XmlWriter writer = null;
            XmlSerializer serializer = null;
            Type[] ExtraTypes = new Type[] { typeof(List<Tester>), typeof(List<Trainee>) };

            try
            {
                String s = pathXmlFile;

                XmlWriterSettings settings = new XmlWriterSettings();

                settings.Indent = true;

                settings.NewLineOnAttributes = true;

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(List<Test>), ExtraTypes);

                if (DataSource.list_test.Count > 0)
                {
                    serializer.Serialize(writer, DataSource.list_test);
                }
                if (DataSource.list_tester.Count > 0)
                {
                    serializer.Serialize(writer, DataSource.list_tester);
                }
                if (DataSource.list_trainee.Count > 0)
                {
                    serializer.Serialize(writer, DataSource.list_trainee);
                }

                writer.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
            }

        }

        private void WriteXmlFile3(List<Test> list_test, List<Tester> list_tester, List<Trainee> list_trainee)
        {
            XmlWriter writer = null;
            XmlSerializer serializer = null;


            try
            {
                String s = pathXmlFile;

                XmlWriterSettings settings = new XmlWriterSettings();

                settings.Indent = true;

                settings.NewLineOnAttributes = true;

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(List<Test>));

                serializer.Serialize(writer, list_test);

                writer.Close();

                settings.OmitXmlDeclaration = true;

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(List<Tester>));

                serializer.Serialize(writer, list_tester);

                writer.Close();

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(List<Trainee>));

                serializer.Serialize(writer, list_trainee);

                writer.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
            }
        }

        public void WriteXmlFile2<T>(List<T> lst)
        {
            XmlWriter writer = null;
            XmlSerializer serializer = null;


            try
            {
                String s = pathXmlFile;

                XmlWriterSettings settings = new XmlWriterSettings();

                settings.Indent = true;

                settings.NewLineOnAttributes = true;

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(List<T>));

                serializer.Serialize(writer, lst);

                serializer.Serialize(writer, DataSource.list_tester);

                writer.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
            }

        }

        public void WriteXmlFiles2()
        {
            FileStream fs = null;

            Type[] ExtraTypes = new Type[] { typeof(List<Tester>), typeof(List<Trainee>) };

            try
            {
                // Creation of a file if it not exists
                fs = new FileStream(pathXmlFile, FileMode.Append, FileAccess.Write, FileShare.Write);

                XmlSerializer sr = new XmlSerializer(typeof(List<Test>), ExtraTypes);

                if (DataSource.list_test.Count > 0)
                {
                    sr.Serialize(fs, DataSource.list_test);
                }
                if (DataSource.list_tester.Count > 0)
                {
                    sr.Serialize(fs, DataSource.list_tester);
                }
                if (DataSource.list_trainee.Count > 0)
                {
                    sr.Serialize(fs, DataSource.list_trainee);
                }

                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
                fs.Close();
            }

        }

        public void WriteXmlFileSL(SavedLists sl)
        {
            if (File.Exists(pathXmlFile))
            {
                File.Delete(pathXmlFile);
            }

            FileStream fs = null;


            try
            {
                // Creation of a file if it not exists
                fs = new FileStream(pathXmlFile, FileMode.Append, FileAccess.Write, FileShare.Write);

                XmlSerializer sr = new XmlSerializer(typeof(SavedLists));

                sr.Serialize(fs, sl);

                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
                fs.Close();
            }

        }

        public void WriteXmlFileSL2(SavedLists sl)
        {
            if (File.Exists(pathXmlFile))
            {
                File.Delete(pathXmlFile);
            }

            XmlWriter writer = null;
            XmlSerializer serializer = null;

            try
            {
                String s = pathXmlFile;

                XmlWriterSettings settings = new XmlWriterSettings();

                settings.Indent = true;

                settings.NewLineOnAttributes = true;

                writer = XmlWriter.Create(pathXmlFile, settings);

                serializer = new XmlSerializer(typeof(SavedLists));

                serializer.Serialize(writer, sl);

                writer.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
            }

        }

        public void WriteXmlFileDS(DataSource ds)
        {
            if (File.Exists(pathXmlFile))
            {
                File.Delete(pathXmlFile);
            }

            FileStream fs = null;


            try
            {
                // Creation of a file if it not exists
                fs = new FileStream(pathXmlFile, FileMode.Append, FileAccess.Write, FileShare.Write);

                XmlSerializer sr = new XmlSerializer(typeof(DataSource));

                sr.Serialize(fs, ds);

                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur write Xml File: " + ex.Message);
                fs.Close();
            }

        }

        public void WriteXmlFile<T>(List<T> lst)
        {
            FileStream fs = null;

            if (lst.Count > 0)
            {
                try
                {
                    // Creation of a file if it not exists
                    fs = new FileStream(pathXmlFile, FileMode.Append, FileAccess.Write, FileShare.Write);

                    XmlSerializer sr = new XmlSerializer(typeof(List<T>));

                    sr.Serialize(fs, lst);

                    fs.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur write Xml File: " + ex.Message);
                    fs.Close();
                }
            }
        }

        #endregion
    }


}

///////////////////////////////////////////////////////////////
//FileStream fs = File.Open(pathXmlFile, FileMode.Open);

//XmlSerializer sr = new XmlSerializer(typeof(DataSource));

//testList = (List<SaveLists>)sr.Deserialize(fs);

//fs.Close();
///////////////////////////////////////////////////////////////////
// Creation of a file if it not exists
//FileStream fs = new FileStream(pathXmlFile, FileMode.OpenOrCreate);

//XmlSerializer sr = new XmlSerializer(typeof(List<Test>));

//sr.Serialize(fs, testList);

//fs.Close();
///////////////////////////////////////////////////////////////