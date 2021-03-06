﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Code
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        
        [Key, Column(Order = 0)]
        public string Code_Id { get; set; }
        [Required]
        public string Code_Type { get; set; }
        public string Code_Name { get; set; }
        public string Code_TypeDesc { get; set; }
        public DateTime Create_Date { get; set; }
        public string Create_User { get; set; }
        public DateTime Modify_Date { get; set; }
        public string Modify_User { get; set; }
     

        public virtual Borrow Borrows { get; set; }
    }
}
