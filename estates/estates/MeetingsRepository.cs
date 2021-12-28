using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estates
{
    class MeetingsRepository
    {
        string _name;
        List<Meeting> _meetingslist;

        public MeetingsRepository()
        {
            _meetingslist = new List<Meeting>();
        }
        public MeetingsRepository(string n):this()
        {
            _name = n;
        }
        public void AddMeeting(Meeting m)
        {
            _meetingslist.Add(m);
        }
        public void RemoveMeeting(Meeting m)
        {
            if(_meetingslist.Contains(m))
            {
                _meetingslist.Remove(m);
            }
            else
            {
                throw new NoItemFoundException();
            }
        }
        public void FindMeetingbyDate(string date)
        {
            
            DateTime.TryParseExact(date, new[] { "dd/MM/yyyy", "dd.mm.yyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime pomdate);
            foreach(Meeting m in _meetingslist)
            {
                if(m.Date==pomdate)
                {
                    Console.WriteLine(m);
                }
            }
        }
        public void SortMeetingsbyDate()
        {
            _meetingslist.Sort();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Name: " + _name);
            foreach (Meeting m in _meetingslist)
            {
                sb.AppendLine(m.ToString());
            }
            return sb.ToString();
        }

    }
}
