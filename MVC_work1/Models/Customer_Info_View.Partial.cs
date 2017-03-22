namespace MVC_work1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(customer_info_viewMetaData))]
    public partial class customer_info_view
    {
    }
    
    public partial class customer_info_viewMetaData
    {
        [Required]
        public int Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 客戶名稱 { get; set; }
        public Nullable<int> contact_count { get; set; }
        public Nullable<int> bank_count { get; set; }
    }
}
