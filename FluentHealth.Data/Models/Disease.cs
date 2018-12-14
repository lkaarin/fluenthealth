using System;
using System.Collections.Generic;

namespace FluentHealth.Data.Models
{
    public class Disease
    {
        public short DiseaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public Person Person { get; set; }
        public IEnumerable<DiseaseSymptom> Symptoms { get; set; }
        public IEnumerable<Diagnosis> Diagnoses { get; set; }
        public IEnumerable<DoctorVisit> Visits { get; set; }
        public IEnumerable<Attachment> Attachments { get; set; }
        public IEnumerable<DrugHistory> Drugs { get; set; }
    }
}
