using System;

namespace estates
{
    class Meeting:IComparable<Meeting>
    {
        Client _client;
        Employee _employee;
        Estate _estate;
        DateTime _date;
        KindOfMeeting _kind;

        public Meeting(Client client, Employee employee, Estate estate, string date1, KindOfMeeting kind)
        {
            _client = client;
            _employee = employee;
            _estate = estate;
            DateTime.TryParseExact(date1, new[]{"dd/MM/yyyy HH:mm", "dd.MM.yyyy HH:mm" }, null, System.Globalization.DateTimeStyles.None, out _date);
            _kind = kind;
            
        }

        public Employee Employee { get => _employee; set => _employee = value; }
        public Estate Estate { get => _estate; set => _estate = value; }
        public DateTime Date { get => _date; set => _date = value; }
        internal Client Client { get => _client; set => _client = value; }
        internal KindOfMeeting Kind { get => _kind; set => _kind = value; }

        public override string ToString()
        {
            return $"Time: {_date:dd-MM-yyyy HH:mm}, Adress: {_estate.Adress} {_estate.City}, Employee: {_employee}, Client: {_client} [{_kind}]";
        }

        public int CompareTo(Meeting other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
}
