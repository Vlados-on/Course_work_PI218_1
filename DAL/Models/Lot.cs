using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Models
{
    public partial class Lot
    {
        [Key]
        public int Lot_ID { get; set; }

        public string Lot_Name { get; set; }

        public string Category { get; set; }

        public int? Current_Price { get; set; }

        public int Price { get; set; }

        [ForeignKey("User")]
        public int User_FK { get; set; }
        
        public virtual User User { get; set; }

        [ForeignKey("User_Bought")]
        public Nullable<int> User_Bought_FK { get; set; }
        
        public virtual User User_Bought { get; set; }

        public bool IsActive { get; set; }

        public bool IsBought { get; set; }

    }
}
