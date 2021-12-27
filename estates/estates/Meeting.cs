using System;

namespace estates
{
    class Meeting
    {
        Client _client;
        Employee _employee;
        Estate _estate;
        DateTime _date;
        Kind_of_meeting _kind;

        public Meeting(Client client, Employee employee, Estate estate, string date1, Kind_of_meeting kind)
        {
            _client = client;
            _employee = employee;
            _estate = estate;
            DateTime.TryParseExact(date1, new[]{"dd/MM/yyyy", "dd.mm.yyyy" }, null, System.Globalization.DateTimeStyles.None, out DateTime _date);
            _kind = kind;
        }
    }
}
