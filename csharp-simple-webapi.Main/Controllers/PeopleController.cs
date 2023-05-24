using csharp_simple_webapi.Main.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace csharp_simple_webapi.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private static List<Person> _list = new List<Person>();

        public PeopleController()
        {
            if(_list.Count == 0)
            {
                Person person1 = new Person();
                person1.Id = 1;
                person1.Name = "Nigel";

                Person person2 = new Person();
                person2.Id = 2;
                person2.Name = "Dave";

                _list.Add(person1);
                _list.Add(person2);
            }
        }


        //[HttpGet]
        //public List<Person> Get()
        //{

        //    return _list;
        //}



        //[HttpGet]
        //[Route("{id}")]
        //public Person Get(int id)
        //{
        //    var person = _list.Where(x => x.Id == id).FirstOrDefault();
        //    return person;
        //}

        [HttpGet]
        public async Task<IResult> Get()
        {

            try
            {
                return Results.Ok(_list);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var person = _list.Where(x => x.Id == id).FirstOrDefault();
                return person != null ? Results.Ok(person) : Results.NotFound();

            
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
           
        }








    }
}
