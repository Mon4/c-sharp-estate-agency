using System;

namespace estates
{
    [Serializable]
    public class Meeting:IComparable<Meeting>
    {
        Client _client;
        Employee _employee;
        Estate _estate;
        DateTime _date;
        KindOfMeeting _kindOfMeeting;

        public Meeting() { }
        public Meeting(Client client, Employee employee, Estate estate, string date1, KindOfMeeting kindOfMeeting)
        {
            _client = client;
            _employee = employee;
            _estate = estate;
            DateTime.TryParseExact(date1, new[]{"dd/MM/yyyy HH:mm", "dd.MM.yyyy HH:mm" }, null, System.Globalization.DateTimeStyles.None, out _date);
            _kindOfMeeting = kindOfMeeting;
        }

        public Employee Employee { get => _employee; set => _employee = value; }
        public Estate Estate { get => _estate; set => _estate = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Client Client { get => _client; set => _client = value; }
        public KindOfMeeting KindOfMeeting { get => _kindOfMeeting; set => _kindOfMeeting = value; }

        public override string ToString()
        {
            return $"Time: {_date:dd-MM-yyyy HH:mm}, Adress: {_estate.Adress} {_estate.City}, Employee: {Employee.Name} " +
                $"{Employee.Surname}, Client: {_client} [{_kindOfMeeting}]";
        }

        public int CompareTo(Meeting other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
}
