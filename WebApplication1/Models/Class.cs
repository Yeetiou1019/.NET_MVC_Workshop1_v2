using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Class
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        [Key, Column(Order = 0)]
        public string Book_Class_Id { get; set; }
        [Required]
        public string Book_Class_Name { get; set; }
        public DateTime Create_Date { get; set; }
        public string Create_User { get; set; }
        public DateTime Modify_Date { get; set; }
        public string Modify_User { get; set; }


        public virtual ICollection<Book> Books { get; set; }
    }
}
