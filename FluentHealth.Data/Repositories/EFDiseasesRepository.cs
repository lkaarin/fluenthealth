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
                    .ThenInclude(x => x.Symptom)
                .AsQueryable();

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public void SaveDisease(Disease disease)
        {
            if (disease.DiseaseId == 0)
            {
                _dbContext.Diseases.Add(disease);
            }
            else
            {
                var diseaseEntry = _dbContext.Diseases.SingleOrDefault(x => x.DiseaseId == disease.DiseaseId);

                if (diseaseEntry == null)
                {
                    throw new NullReferenceException($"Can't find disease with id {disease.DiseaseId}");
                }

                //_dbContext.Entry(disease).State = EntityState.Modified;

                diseaseEntry.StartDate = disease.StartDate;
                diseaseEntry.EndDate = disease.EndDate;
                diseaseEntry.Person = _dbContext.Persons.SingleOrDefault(x => x.PersonId == disease.Person.PersonId);
                diseaseEntry.Symptoms = disease.Symptoms;
            }

            _dbContext.SaveChanges();
        }

        public void DeleteDisease(short id)
        {
            _dbContext.Diseases.Remove(_dbContext.Diseases.SingleOrDefault(x => x.DiseaseId == id));

            _dbContext.SaveChanges();
        }
    }
}
