﻿using RESTful_With_Azure_and_REACTJS.Model;
using RESTful_With_Azure_and_REACTJS.Model.Context;

namespace RESTful_With_Azure_and_REACTJS.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness // A Classe implenta a interface Person
    {
        private MySQLContext _context;


        public PersonBusinessImplementation(MySQLContext context )
        {
  
            _context = context;
        
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            return person;
        }

        public void Delete(long id)
        {
           var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }
        }

        public List<Person> FindAll()
        {

            
            return _context.Persons.ToList();
        }

        

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));


        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }

            }

            return person;
        }

        private bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}