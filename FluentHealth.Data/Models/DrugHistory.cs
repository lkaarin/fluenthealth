using System;

namespace FluentHealth.Data.Models
{
    public class DrugHistory
    {
        public int DrugHistoryId { get; set; }
        public Drug Drug { get; set; }
        public int PrescribedDays { get; set; }
        public float? Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
