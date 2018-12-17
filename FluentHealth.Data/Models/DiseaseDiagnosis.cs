namespace FluentHealth.Data.Models
{
    public class DiseaseDiagnosis
    {
        public short DiseaseId { get; set; }
        public short DiagnosisId { get; set; }
        public Disease Disease { get; set; }
        public Diagnosis Diagnosis { get; set; }
    }
}
