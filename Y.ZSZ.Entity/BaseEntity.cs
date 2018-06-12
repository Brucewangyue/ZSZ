using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.Entity
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }

        public bool IsDelete { get; set; } = false;

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime? DeleteDate { get; set; }
    }
}
