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

        [HttpPost]
        [Route("")]
        public async Task<IResult> InsertPerson(Person person)
        {
            try
            {
                if (person == null) return Results.Problem();

                _list.Add(person);
                return Results.Ok(person);

            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }



        [HttpDelete]
        [Route("")]
        public async Task<IResult> DeletePerson(int id)
        {
            try
            {
                if(_list.Any(x => x.Id==id))
                {
                    //var p = _list.SingleOrDefault(x => x.Id == id);
                    //_list.Remove(p);
                    //
                    _list.RemoveAll(x => x.Id == id);
                    return Results.Ok();
                }
                else
                {
                    return Results.NotFound();
                }
            }
            catch(Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }




    }
}


/*

REST API

HTTPS

Clients and Servers

Http Cycle?



 */ 



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