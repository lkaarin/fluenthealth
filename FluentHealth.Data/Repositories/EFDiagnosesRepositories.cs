using FluentHealth.Data.Models;
using System.Collections.Generic;

namespace FluentHealth.Data.Repositories.Core
{
    public class EFDiagnosesRepositories : IDiagnosesRepositories
    {
        private readonly EFDBContext _dbContext;
        public EFDiagnosesRepositories(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Diagnosis> GetDiagnoses() => _dbContext.Diagnoses;
    }
}
