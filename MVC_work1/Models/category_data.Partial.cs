namespace MVC_work1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(category_dataMetaData))]
    public partial class category_data
    {
    }
    
    public partial class category_dataMetaData
    {
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string cateogry { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string description { get; set; }
    
        public virtual ICollection<客戶資料> 客戶資料 { get; set; }
    }
}
