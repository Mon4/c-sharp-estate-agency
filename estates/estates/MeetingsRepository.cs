using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    /// <summary>
    /// Repository containing all meetings, has its name and list of meetings.
    /// </summary>
    [Serializable]
    public class MeetingsRepository
    {
        string _name;
        List<Meeting> _meetingslist;

        public string Name { get => _name; set => _name = value; }
        public List<Meeting> Meetingslist { get => _meetingslist; set => _meetingslist = value; }

        /// <summary>
        /// Default contructor, initializes Meetingslist
        /// </summary>
        public MeetingsRepository()
        {
            Meetingslist = new List<Meeting>();
        }
        /// <summary>
        /// Parametric constructor, creates new repository with given name, refers to default constructor
        /// </summary>
        /// <param name="n"></param>
        public MeetingsRepository(string n):this()
        {
            Name = n;
        }
        /// <summary>
        /// Adds given meeting to MeetingsList
        /// </summary>
        /// <param name="m">meeting</param>
        public void AddMeeting(Meeting m)
        {
            Meetingslist.Add(m);
        }
        /// <summary>
        /// Removes given meeting from MeetingsList if the list contains this meeting, if not throws new exception
        /// </summary>
        /// <param name="m">meeting</param>
        public void RemoveMeeting(Meeting m)
        {
            try
            {
                if (Meetingslist.Contains(m))
                {
                    Meetingslist.Remove(m);
                }
                else
                {
                    throw new NoItemFoundException("Meeting not found");
                }
            }
            catch(NoItemFoundException nife)
            {
                Console.WriteLine(nife.Message);
            }
        }
        /// <summary>
        /// Finds meeting by date and writes it down.
        /// </summary>
        /// <param name="date"></param>
        public void FindMeetingbyDate(string date)
        {
            
            DateTime.TryParseExact(date, new[] { "dd/MM/yyyy", "dd.mm.yyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime pomdate);
            foreach(Meeting m in Meetingslist)
            {
                if(m.Date==pomdate)
                {
                    Console.WriteLine(m);
                }
            }
        }
        /// <summary>
        /// Sorts Meetingslist
        /// </summary>
        public void SortMeetingsbyDate()
        {
            Meetingslist.Sort();
        }
        /// <summary>
        /// Returns informations about Meetings in text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + Name);
            foreach (Meeting m in Meetingslist)
            {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString();
        }
        /// <summary>
        /// Saves MeetingsRepository to xml file
        /// </summary>
        public void SaveToXML()
        {
            var xs = new XmlSerializer(typeof(MeetingsRepository));
            var fs = new FileStream("../../../meetings.xml", FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        /// <summary>
        /// Reads xml file and return new repository.
        /// </summary>
        /// <returns></returns>
        public static MeetingsRepository ReadXML()
        {
            MeetingsRepository meet_rep;
            var xs = new XmlSerializer(typeof(MeetingsRepository));
            var fs = new FileStream("../../../meetings.xml", FileMode.Open);
            meet_rep = (MeetingsRepository)xs.Deserialize(fs);
            fs.Close();
            return meet_rep;
        }
    }
}
