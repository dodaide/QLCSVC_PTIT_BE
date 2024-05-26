using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Campus
{
    public class CampusGetAllDTO
    {
        public int CampusID { get; set; }
        public List<int> ParentIDs { get; set; }
        public string CampusName { get; set; }
        public string CampusCode { get; set; }
        public string? Description { get; set; }
        public string CampusType { get; set; }
        public int SeatNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}
