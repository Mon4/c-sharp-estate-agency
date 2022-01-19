using System;

namespace estates
{
    /// <summary>
    /// Meeting in estate agency, containing informations about client employeee
    /// estate, the date of meeting and kind of meeting.
    /// </summary>
    [Serializable]
    public class Meeting:IComparable<Meeting>
    {
        Client _client;
        Employee _employee;
        Estate _estate;
        DateTime _date;
        KindOfMeeting _kindOfMeeting;
        /// <summary>
        /// Default contructor.
        /// </summary>
        public Meeting() { }
        /// <summary>
        /// Parametric constructor, creates meeting with given informations.
        /// </summary>
        /// <param name="client">Client</param>
        /// <param name="employee">Employee</param>
        /// <param name="estate">Estate</param>
        /// <param name="date">Date of meeting</param>
        /// <param name="kindOfMeeting">Kind of meeting</param>
        public Meeting(Client client, Employee employee, Estate estate, string date, KindOfMeeting kindOfMeeting)
        {
            _client = client;
            _employee = employee;
            _estate = estate;
            DateTime.TryParseExact(date, new[]{"dd/MM/yyyy HH:mm", "dd.MM.yyyy HH:mm" , "dd-MM-yyyy HH:mm"}, null, System.Globalization.DateTimeStyles.None, out DateTime _date);
            _kindOfMeeting = kindOfMeeting;
        }
        /// <summary>
        /// Meeting's eployee property
        /// </summary>
        public Employee Employee { get => _employee; set => _employee = value; }
        /// <summary>
        /// Meeting's estate property
        /// </summary>
        public Estate Estate { get => _estate; set => _estate = value; }
        /// <summary>
        /// Meeting's date property
        /// </summary>
        public DateTime Date { get => _date; set => _date = value; }
        /// <summary>
        /// Meeting's client property
        /// </summary>
        public Client Client { get => _client; set => _client = value; }
        /// <summary>
        /// Meeting's kindofMeeting property
        /// </summary>
        public KindOfMeeting KindOfMeeting { get => _kindOfMeeting; set => _kindOfMeeting = value; }
        /// <summary>
        /// Return information about meeting to text.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Time: {_date:dd-MM-yyyy HH:mm}, Adress: {_estate.Adress} {_estate.City}, Employee: {Employee.Name} " +
                $"{Employee.Surname}, Client: {_client} [{_kindOfMeeting}]";
        }
        /// <summary>
        /// Compares meetings with their date.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>

        public int CompareTo(Meeting other)
        {
            return this.Date.CompareTo(other.Date);
        }
    }
}
