using csharp_simple_webapi.Main.Model;

namespace csharp_simple_webapi.Main.Data
{
    public class StaffRepository : IUserRepository
    {
        private List<Person> _staff = new List<Person>();
        public StaffRepository()
        {
            if (_staff.Count == 0)
            {
                Person person1 = new Person();
                person1.Id = 1;
                person1.Name = "Nigel";
                person1.Age = 21;

                Person person2 = new Person();
                person2.Id = 2;
                person2.Name = "Dave";
                person1.Age = 22;

                _staff.Add(person1);
                _staff.Add(person2);
            }
        }
        public bool Add(Person person)
        {

            _staff.Add(person);
            return true;

        }

        public IEnumerable<Person> GetAll()
        {
            return _staff;
        }
    }
}
