using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{

        public enum Status
        {
            A, B, C, U
        }

        public class Borrow
        {
            
            [Key, Column(Order = 0)]
            public string User_Id { get; set; }
        [Key, Column(Order = 1)]
            public int Book_Id { get; set; }
        [Key,Column(Order = 2)]
            public string Code_Id { get; set; }
            public string Status { get; set; }
        
        public virtual Book Book { get; set; }
            public virtual Member Member { get; set; }
        }
    
}
