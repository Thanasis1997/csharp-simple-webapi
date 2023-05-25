using csharp_simple_webapi.Main.Model;

namespace csharp_simple_webapi.Main.Data
{
    public class UserRepository : IUserRepository
    {
        private List<Person> _list = new List<Person>();

        public UserRepository()
        {
            if (_list.Count == 0)
            {
                Person person1 = new Person();
                person1.Id = 1;
                person1.Name = "Nigel";
                person1.Age = 21;

                Person person2 = new Person();
                person2.Id = 2;
                person2.Name = "Dave";
                person1.Age = 22;

                _list.Add(person1);
                _list.Add(person2);
            }

        }
        
        public bool Add(Person person)
        {

           _list.Add(person);
            return true;    

        }

        public IEnumerable<Person> GetAll()
        {
            return _list;
        }
    }
}
