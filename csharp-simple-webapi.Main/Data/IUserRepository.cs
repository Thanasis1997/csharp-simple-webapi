using csharp_simple_webapi.Main.Model;

namespace csharp_simple_webapi.Main.Data
{
    public interface IUserRepository
    {
        bool Add(Person person);
        IEnumerable<Person> GetAll();
    }
}
