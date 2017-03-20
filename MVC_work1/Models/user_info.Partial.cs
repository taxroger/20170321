namespace MVC_work1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    [MetadataType(typeof(user_infoMetaData))]
    public partial class user_info : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.loginCheck())
            {
                yield return ValidationResult.Success;
                yield break;
            }

            yield return new ValidationResult("登入失敗", new string[] { this.username });
        }

        private bool loginCheck()
        {
            var loginRepo = RepositoryHelper.Getuser_infoRepository();

            var data = loginRepo.All().AsQueryable();

            data = data.Where(p => p.username == this.username && p.password == this.password);

            if (data.Count() ==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public partial class user_infoMetaData
    {
        
        [StringLength(10, ErrorMessage="欄位長度不得大於 10 個字元")]
        [Required]
        [DisplayName("使用者名稱")]
        public string username { get; set; }
        
        [StringLength(20, ErrorMessage="欄位長度不得大於 20 個字元")]
        [Required]
        [DisplayName("密碼")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        
        [StringLength(30, ErrorMessage="欄位長度不得大於 30 個字元")]
        public string description { get; set; }
    }
}
