using System;

namespace FluentHealth.Data.Models
{
    public class DoctorVisit
    {
        public short DoctorVisitId { get; set; }
        public string DoctorName { get; set; }
        public DateTime VisitDate { get; set; }
        public Disease Disease { get; set; }
    }
}
