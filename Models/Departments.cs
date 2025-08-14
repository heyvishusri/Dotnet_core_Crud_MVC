using System.ComponentModel.DataAnnotations;

namespace WebAppDotNetCoreCrudNew.Models
{
    public class Departments
    {
        [Key]
        public int ID { get; set; }

        
        public string DeptName { get; set; }
    }
}
