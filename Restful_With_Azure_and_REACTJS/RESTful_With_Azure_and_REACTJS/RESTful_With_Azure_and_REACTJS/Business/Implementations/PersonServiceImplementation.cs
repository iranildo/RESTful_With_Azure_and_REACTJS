using RESTful_With_Azure_and_REACTJS.Model;
using RESTful_With_Azure_and_REACTJS.Model.Context;
using RESTful_With_Azure_and_REACTJS.Repository;

namespace RESTful_With_Azure_and_REACTJS.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness // A Classe implenta a interface Person
    {
        private readonly IPersonRepository _repository;


        public PersonBusinessImplementation(IPersonRepository repository )
        {
  
            _repository = repository;
        
        }

        public Person Create(Person person)
        {
            
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
          _repository.Delete(id);

            
        }

        public List<Person> FindAll()
        {

            
            return _repository.FindAll();
        }

        

        public Person FindById(long id)
        {
            return _repository.FindById(id);


        }

        public Person Update(Person person)
        {
            
            return _repository.Update(person);
        }

    }
}
