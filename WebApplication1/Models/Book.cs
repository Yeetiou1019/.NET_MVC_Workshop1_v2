using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Book
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column(Order = 0)]
        public int Book_Id { get; set; }
        [Required]
        public string Book_Name { get; set; }
        public string Book_Author { get; set; }
  
        public string Book_Class_Id { get; set; }
        public DateTime Book_BoughtDate { get; set; }
        public string Book_Publisher { get; set; }
        public string Book_Note { get; set; }
        public string Book_Status { get; set; }
        public string Book_Keeper { get; set; }
        public DateTime Create_Date { get; set; }
        public string Create_User { get; set; }
        public DateTime Modify_Date { get; set; }
        public string Modify_User { get; set; }



        public virtual ICollection<Borrow> Borrows { get; set; }
    }
}
