using System.Collections.Generic;

namespace FluentHealth.Data.Models
{
    public class Diagnosis
    {
        public short DiagnosisId { get; set; }
        public string Name { get; set; }

        public IEnumerable<DiseaseDiagnosis> Diseases { get; set; }
    }
}
