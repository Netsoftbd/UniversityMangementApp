using System;

namespace Ums.Core.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }

        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }

        public string EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public string DeleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}