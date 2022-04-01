using RESTful_With_Azure_and_REACTJS.Model;

namespace RESTful_With_Azure_and_REACTJS.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();//Retorna uma listagem com todas as pessoas
        Person Update(Person person);
        void Delete(long id);

    }
}
