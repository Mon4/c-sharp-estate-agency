using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace estates
{
    [Serializable]
    public class MeetingsRepository
    {
        string _name;
        List<Meeting> _meetingslist;

        public string Name { get => _name; set => _name = value; }
        public List<Meeting> Meetingslist { get => _meetingslist; set => _meetingslist = value; }

        public MeetingsRepository()
        {
            Meetingslist = new List<Meeting>();
        }
        public MeetingsRepository(string n):this()
        {
            Name = n;
        }
        public void AddMeeting(Meeting m)
        {
            Meetingslist.Add(m);
        }
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
        public void SortMeetingsbyDate()
        {
            Meetingslist.Sort();
        }
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
        public void SaveToXML(string path)
        {
            var xs = new XmlSerializer(typeof(MeetingsRepository));
            var fs = new FileStream(path, FileMode.Create);
            xs.Serialize(fs, this);
            fs.Close();
        }
        public static MeetingsRepository ReadXML(string path)
        {
            MeetingsRepository meet_rep;
            var xs = new XmlSerializer(typeof(MeetingsRepository));
            var fs = new FileStream(path, FileMode.Open);
            meet_rep = (MeetingsRepository)xs.Deserialize(fs);
            fs.Close();
            return meet_rep;
        }
    }
}
