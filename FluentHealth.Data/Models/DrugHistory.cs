namespace FluentHealth.Data.Models
{
    public class DrugHistory
    {
        public int DrugHistoryId { get; set; }
        public Drug Drug { get; set; }
        public float? Price { get; set; }
        public bool Used { get; set; } 
    }
}
