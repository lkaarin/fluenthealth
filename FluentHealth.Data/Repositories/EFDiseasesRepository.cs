using FluentHealth.Data.Models;
using FluentHealth.Data.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FluentHealth.Data.Repositories
{
    public class EFDiseasesRepository : IDiseasesRepository
    {
        private readonly EFDBContext _dbContext;
        public EFDiseasesRepository(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Disease GetDisease(short id)
        {
            return GetDiseases(x => x.DiseaseId == id).SingleOrDefault();
        }

        public IEnumerable<Disease> GetDiseases(Expression<Func<Disease, bool>> predicate = null)
        {
            var query = _dbContext.Diseases
                .Include(x => x.Attachments)
                .Include(x => x.Diagnoses)
                    .ThenInclude(x => x.Diagnosis)
                .Include(x => x.Drugs)
                    .ThenInclude(x => x.Drug)
                .Include(x => x.Person)
                .Include(x => x.Symptoms)
                    .ThenInclude(x=>x.Symptom)
                .AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }
    }
}
