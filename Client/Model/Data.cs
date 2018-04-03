using System;

namespace Client.Model
{
    public class Data
    { 
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? EndTime { get; set; }
        public string EventTitle { get; set; }
        public string AllDayEvent { get; set; }
        public string NoEndTime { get; set; }
        public string EventDescription { get; set; }
        public string Contact { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Location { get; set; }
        public int Category { get; set; }
        public string Mandatory { get; set; }
        public string Registration { get; set; }
        public int Maximum { get; set; }
        public DateTime LastDateToRegister { get; set; }
    }
}
