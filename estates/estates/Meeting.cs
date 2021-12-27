using System;

namespace estates
{
    class Meeting
    {
        Client client;
        Employee employee;
        Estate estate;
        DateTime date;
        Kind_of_meeting kind;

        public Meeting(Client client, Employee employee, Estate estate, string date1, Kind_of_meeting kind)
        {
            this.client = client;
            this.employee = employee;
            this.estate = estate;
            DateTime.TryParseExact(date1, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date);
            this.kind = kind;
        }
    }
}
