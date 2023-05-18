using System.ComponentModel.DataAnnotations;
using webapi.Interfaces;

namespace webapi.Models
{
    public class Person : IPerson
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
