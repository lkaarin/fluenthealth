using FluentHealth.Data.Models.Enums;
using System;

namespace FluentHealth.Data.Models
{
    public class Person
    {
        public short PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public PersonStyle PersonStyle { get;set;}
    }
}
