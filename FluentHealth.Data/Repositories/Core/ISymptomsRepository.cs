using FluentHealth.Data.Models;
using System.Collections.Generic;

namespace FluentHealth.Data.Repositories.Core
{
    public interface ISymptomsRepository
    {
        IEnumerable<Symptom> GetSymptoms();
    }
}

