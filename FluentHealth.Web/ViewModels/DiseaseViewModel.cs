using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentHealth.Web.ViewModels
{
    public class DiseaseViewModel
    {
        public short DiseaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public BaseItemViewModel<short> Person { get; set; }
        public IEnumerable<BaseItemViewModel<short>> Symptoms { get; set; }
        public IEnumerable<BaseItemViewModel<short>> Diagnoses { get; set; }
        public IEnumerable<BaseItemViewModel<short>> Attachments { get; set; }
        public IEnumerable<BaseItemViewModel<int>> Drugs { get; set; }
    }

    public class EditDiseaseViewModel: DiseaseViewModel
    {
        public IEnumerable<BaseItemViewModel<short>> AvailablePersons { get; set; }
        public IEnumerable<BaseItemViewModel<short>> AvailableSymptoms { get; set; }
        public IEnumerable<BaseItemViewModel<short>> AvailableDiagnoses { get; set; }
        public IEnumerable<BaseItemViewModel<short>> AvailableDrugs { get; set; }
    }
}
