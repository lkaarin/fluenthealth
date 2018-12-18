using FluentHealth.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentHealth.Data.Repositories.Core
{
    public interface IPersonsRepository
    {
        IEnumerable<Person> GetPersons();
    }
}
