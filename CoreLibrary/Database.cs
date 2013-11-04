using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Security.Cryptography;
using System.Collections;

namespace NoteSchool
{
    public class Database
    {
        private String _root = @".\saves\";
        private String _rootNotes = @"notes\";
        private String _groupListPath = @"groupList.xml";

        private XElement groupListElements;

        public Database()
        {

            //chemin du dossier de sauvegarde
            //_root = Path.Combine(_root, "saves");

            //chemin du dossier des groupes
            _rootNotes = Path.Combine(_root, _rootNotes);

            //le fichier qui contient les groupes
            _groupListPath = Path.Combine(_root, _groupListPath);

            //creer le dossier de sauvegarde
            //si il n'existe pas  
            Directory.CreateDirectory(_root);

            //créer le dossier des notes
            Directory.CreateDirectory(_rootNotes);

            //create groupList file is does not exist
            if (!File.Exists(_groupListPath))
            {
                XDocument groupListDoc = new XDocument(
                    new XDeclaration("1.0", "UTF-8", "yes"),
                    new XProcessingInstruction("NoteSchool", "Tous les groupes connues de l'application"),
                    new XElement("groups")
                );

                //Save the xml file
                groupListDoc.Save(_groupListPath);
            }
        }

        public void AddGroup(Group Data)
        {
            //check data integrity
            if (Data == null || Data.Title == null)
            {
                throw new ArgumentException("Invalid argument Data or Title is null");
            }

            //Create md5 hash
            MD5 md5hash = MD5.Create();
            String hash = GetMd5Hash(md5hash, Data.Title + Data.Date.ToString());

            //create the group directory to store note
            String groupNoteDirectory = Path.Combine(_rootNotes, hash);
            //on créé le dossier du groupe dans le dossier notes
            //si il n'existe pas
            Directory.CreateDirectory(groupNoteDirectory);

            //init groupListDoc if not yet
            InitGroupListElements();

            //add the new group in the list
            groupListElements.Add(new XElement("group",
                new XElement("Title", Data.Title),
                new XElement("Date", Data.Date.ToString())
            , new XAttribute("hash", hash)));

            //save modification
            groupListElements.Save(_groupListPath);
        }

        public bool isGroupExists(string title)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in groupListElements.Elements("group")
                                             where (string)el.Element("Title").Value == title
                                             select el;

            return searched.Count() > 0;

        }

        public bool SetGroupField(String hash, String field, String value)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in groupListElements.Elements("group")
                                             where (string)el.Attribute("hash") == hash
                                             select el;

            if (searched.Count() == 0)
            {
                return false;
            }

            XElement elem = searched.First();
            elem.SetElementValue(field, value);

            //save modification
            groupListElements.Save(_groupListPath);

            return true;
        }

        public bool GetGroupByHash(String hash, Group Group)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in groupListElements.Elements("group")
                                             where (string)el.Attribute("hash") == hash
                                             select el;

            if (searched.Count() == 0)
            {
                return false;
            }

            /* foreach( XElement e in searched.First().Elements() )
             {
                 //edit Group object dynamicly
                 //typeof(Group).GetProperty(e.Name.ToString()).SetValue(Group, e.Value, null);
                 Group.GetType().GetProperty(e.Name.ToString()).SetValue(Group, e.Value, null);
             }*/

            XElement elem = searched.First();
            Group.Title = elem.Element("Title").Value;

            return true;
        }

        private void InitGroupListElements()
        {
            //init groupListDoc if not yet
            if (groupListElements == null)
            {
                groupListElements = XElement.Load(_groupListPath);
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        internal Group Null { get; set; }
    }
}
