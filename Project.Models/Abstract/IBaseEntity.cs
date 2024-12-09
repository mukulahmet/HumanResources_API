using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Models.Enums;

namespace Project.Models.Abstract
{
    public interface IBaseEntity
    {  
        public DateTime? CreationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public Status? Status { get; set; }
    }
}
