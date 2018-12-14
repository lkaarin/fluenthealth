using System.Collections.Generic;

namespace FluentHealth.Data.Models
{
    public class Symptom
    {
        public short SymptomId { get; set; }
        public string Name { get; set; }
        public IEnumerable<DiseaseSymptom> Diseases { get; set; }
    }
}
