using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class MLot
    {
        public int Lot_ID { get; set; }

        public string Lot_Name { get; set; }

        public string Category { get; set; }

        public int Price { get; set; }

        public int User_FK { get; set; }
        public virtual MUser User { get; set; }

        public int? Current_Price { get; set; }

        public Nullable<int> User_Bought_FK { get; set; }
        public virtual MUser User_Bought { get; set; }

        public bool IsActive { get; set; }

        public bool IsBought { get; set; }
    }
}
