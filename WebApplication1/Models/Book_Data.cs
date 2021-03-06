//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Book_Data
    {
       [Required]
        public string Book_Name { get; set; }
        public string Book_Author { get; set; }
        public Nullable<System.DateTime> Book_Bought_Date { get; set; }
        public string Book_Publisher { get; set; }
        public string Book_Note { get; set; }
        public string Book_Status { get; set; }
        public string Book_Keeper { get; set; }
        public Nullable<System.DateTime> Create_Date { get; set; }
        public string Create_User { get; set; }
        public Nullable<System.DateTime> Modify_Date { get; set; }
        public string Modify_User { get; set; }
        [Key, Column(Order = 3)]
        public string User_Id { get; set; }
        [Key, Column(Order = 2)]
        public string Code_Id { get; set; }
        [Key, Column(Order = 1)]
        public string Book_Class_Id { get; set; }
        [Key, Column(Order = 0)]
        public int Book_Id { get; set; }
    
        public virtual Member Member { get; set; }
        public virtual Book_Code Book_Code { get; set; }
        public virtual Book_Class Book_Class { get; set; }
    }
}
