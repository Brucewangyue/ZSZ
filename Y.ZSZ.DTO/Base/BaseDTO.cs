using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO
{
    [Serializable]
    public class BaseDTO
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
