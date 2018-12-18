using FluentHealth.Data.Models;
using FluentHealth.Data.Repositories.Core;
using System.Collections.Generic;

namespace FluentHealth.Data.Repositories
{
    public class EFSymptomsRepository: ISymptomsRepository
    {
        private readonly EFDBContext _dbContext;
        public EFSymptomsRepository(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Symptom> GetSymptoms() => _dbContext.Symptoms;
    }
}

