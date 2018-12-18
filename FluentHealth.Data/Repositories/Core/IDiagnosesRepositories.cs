using FluentHealth.Data.Models;
using System.Collections.Generic;

namespace FluentHealth.Data.Repositories.Core
{
    public interface IDiagnosesRepositories
    {
        IEnumerable<Diagnosis> GetDiagnoses();
    }
}
