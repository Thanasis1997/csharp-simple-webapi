using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace csharp_simple_webapi.Main.Model
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is a required field", AllowEmptyStrings = false)]
        [Description("This is the name of the person")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Age is a required field!")]
        public int? Age { get; set; }
    }
}
