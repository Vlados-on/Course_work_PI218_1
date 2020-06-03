using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public partial class Role
    {
        [Key]
        public int Role_ID { get; set; }
        public string Role_name { get; set; }
    }
}
