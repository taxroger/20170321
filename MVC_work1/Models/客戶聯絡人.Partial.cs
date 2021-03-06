using System.Linq;

namespace MVC_work1.Models
{
    using System.ComponentModel.DataAnnotations;
    using Validations;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人
    {
        //public bool checkEmailAddress(int custId, string custEmail)
        //{
        //    客戶聯絡人Repository custContactRepo = RepositoryHelper.Get客戶聯絡人Repository();

        //    var data = custContactRepo.All().AsQueryable();

        //    data = data.Where(p => p.客戶Id == custId && p.Email == custEmail);

        //    if (data.Count() > 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    }

    public partial class 客戶聯絡人MetaData
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int 客戶Id { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 職稱 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string 姓名 { get; set; }
        
        [StringLength(250, ErrorMessage="欄位長度不得大於 250 個字元")]
        [Required]
        [EmailAddress]
        //[DuplicateEmail("客戶Id")]
        public string Email { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [TelephoneAttribute]
        public string 手機 { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string 電話 { get; set; }
        [Required]
        public bool isDeleted { get; set; }
    
        public virtual 客戶資料 客戶資料 { get; set; }
    }
}
