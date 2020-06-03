using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public partial class User
    {
        [Key]
        public int User_ID { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }

        [ForeignKey("Role")]
        public int Role_FK { get; set; }
        public virtual Role Role { get; set; }
    }
}
