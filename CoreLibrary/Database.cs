using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Collections;
using CoreLibrary;

namespace NoteSchool
{
    public static class Database
    {
        private static String _root = @".\saves\"; //base location
        private static String _rootNotes = @"notes\"; //location of notes
        private static String _groupListPath = @"groupList.xml"; //group list filename

        private static XElement _groupListElements; //contain xml nodes

        static Database()
        {
            //chemin du dossier des notes
            _rootNotes = Path.Combine(_root, _rootNotes);

            //creer le dossier de sauvegarde
            Directory.CreateDirectory(_root);

            //créer le dossier des notes
            Directory.CreateDirectory(_rootNotes);

            #region Group Initialization

            //le fichier qui contient les groupes
            _groupListPath = Path.Combine(_root, _groupListPath);


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
            #endregion Group Initialization
        }

        #region Group Functions
        /// <summary>
        /// Create a new group
        /// </summary>
        /// <param name="Group"></param>
        public static void AddGroup(Group Group)
        {
            //check group data integrity
            if (string.IsNullOrEmpty(Group.Title) || Group.Hash ==  null)
            {
                throw new InvalidOperationException("You must set the group fields before call it");
            }

            //create the group directory to store note
            String groupNoteDirectory = Path.Combine(_rootNotes, Group.Hash);

            //on créé le dossier du groupe dans le dossier notes
            //si il n'existe pas
            Directory.CreateDirectory(groupNoteDirectory);

            //init groupListDoc if not yet
            InitGroupListElements();

            //add the new group in the list
            _groupListElements.Add(new XElement("group",
                new XElement("Title", Group.Title),
                new XElement("Date", Group.Date.ToString())
            , new XAttribute("hash", Group.Hash)));

            //save modification
            _groupListElements.Save(_groupListPath);
        }

        public static bool isGroupExists(string title)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in _groupListElements.Elements("group")
                                             where (string)el.Element("Title").Value == title
                                             select el;

            return searched.Count() > 0;
        }

        public static bool SetGroupField(String hash, String field, String value)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in _groupListElements.Elements("group")
                                             where (string)el.Attribute("hash") == hash
                                             select el;

            if (searched.Count() == 0)
            {
                return false;
            }

            XElement elem = searched.First();
            elem.SetElementValue(field, value);

            //save modification
            _groupListElements.Save(_groupListPath);

            return true;
        }

        public static bool GetGroupByHash(String hash, Group Group)
        {
            //load groups list file
            InitGroupListElements();

            //look for a group by his hash
            IEnumerable<XElement> searched = from el in _groupListElements.Elements("group")
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
           // Group.Date = (DateTime) elem.Element("Date");

            return true;
        }

        private static void InitGroupListElements()
        {
            //init groupListDoc if not yet
            if (_groupListElements == null)
            {
                _groupListElements = XElement.Load(_groupListPath);
            }
        }
    }

        #endregion Group Functions
}
