namespace MVC_work1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(Customer_Info_ViewMetaData))]
    public partial class Customer_Info_View
    {
    }
    
    public partial class Customer_Info_ViewMetaData
    {
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        [Required]
        public int Id { get; set; }
        [DisplayName("聯絡人數量")]
        public Nullable<int> contact_count { get; set; }
        [DisplayName("銀行帳號數量")]
        public Nullable<int> bank_count { get; set; }
    }
}
