using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace rzeczuchyTasks.Model
{
    public class DataReaderWriter
    {
        private const string Filepath = "todos.xml";

        public DataReaderWriter()
        {
            CreatePlaceholderToDos();
        }

        public void SaveToDos(List<ToDo> toDos)
        {
            using (XmlWriter writer = XmlWriter.Create(Filepath))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("ToDoList");

                foreach (ToDo todo in toDos)
                {
                    SaveToDo(todo, writer);
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }

        public List<ToDo> LoadToDos()
        {
            var list = new List<ToDo>();

            using (XmlReader reader = XmlReader.Create(Filepath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        ToDo todo = LoadToDo(reader);

                        if (todo != null)
                        {
                            list.Add(todo);
                        }
                    }
                }
            }

            return list;
        }

        private ToDo LoadToDo(XmlReader reader)
        {
            string label = reader["Label"];
            if (int.TryParse(reader["Id"], out int id) && label != null && bool.TryParse(reader["Done"], out bool done))
            {
                return new ToDo(id, label, done);
            }
            return null;
        }

        private void SaveToDo(ToDo todo, XmlWriter writer)
        {
            if (todo != null && todo.Label != null)
            {
                writer.WriteStartElement("ToDo");
                writer.WriteAttributeString ("Id", todo.Id.ToString());
                writer.WriteAttributeString("Label", todo.Label);
                writer.WriteAttributeString("Done", todo.IsChecked.ToString());
                writer.WriteEndElement();
            }
        }

        private void CreatePlaceholderToDos()
        {
            if (!File.Exists(Filepath))
            {
                var placeholders = new List<ToDo>();
                placeholders.Add(new ToDo(NewToDoId(placeholders), "This is an unchecked todo", false));
                placeholders.Add(new ToDo(NewToDoId(placeholders), "This is a checked todo", true));
                SaveToDos(placeholders);
            }
        }

        public static int NewToDoId(List<ToDo> list)
        {
            if (list.Any())
            {
                return list.Max(i => i.Id) + 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
