using FluentHealth.Data.Models;
using FluentHealth.Data.Repositories.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentHealth.Data.Repositories
{
    public class EFPersonsRepository: IPersonsRepository
    {
        private readonly EFDBContext _dbContext;
        public EFPersonsRepository(EFDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Person> GetPersons()
        {
            return _dbContext.Persons;
        }
    }
}
