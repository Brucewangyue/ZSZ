using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Y.ZSZ.DTO.OptionDTO
{
    public class HouseAppointmentOption:BaseDTO
    {
        public long UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime VisitDate { get; set; }
        public long HouseId { get; set; }
        public string Status { get; set; }
    }
}
