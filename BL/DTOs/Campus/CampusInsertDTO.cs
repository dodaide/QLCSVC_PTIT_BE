using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Campus
{
    public class CampusInsertDTO
    {
        public int ParentID { get; set; }
        public string CampusName { get; set; }
        public string CampusCode { get; set; }
        public string? Description { get; set; }
        public int CampusType { get; set; }
        public int SeatNumber { get; set; }
    }
}
