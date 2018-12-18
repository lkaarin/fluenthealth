using FluentHealth.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FluentHealth.Data.Repositories.Core
{
    public interface IDiseasesRepository
    {
        Disease GetDisease(short id);

        IEnumerable<Disease> GetDiseases(Expression<Func<Disease, bool>> predicate = null);

        void SaveDisease(Disease disease);

        void DeleteDisease(short id);
    }
}
