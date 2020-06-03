using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MUser
    {
        public int User_ID { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public string Name { get; set; }
        
        public int Role_FK { get; set; }
        public virtual MRole Role { get; set; }
    }
}
