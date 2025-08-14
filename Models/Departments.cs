using System.ComponentModel.DataAnnotations;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class Departments
    {
        [Key]
        public int ID { get; set; }

        
        public int Department { get; set; }
    }
}
