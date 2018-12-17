﻿namespace FluentHealth.Data.Models
{
    public class DiseaseSymptom
    {
        public short DiseaseId { get; set; }
        public short SymptomId { get; set; }
        public Disease Disease { get; set; }
        public Symptom Symptom { get; set; }
    }
}
