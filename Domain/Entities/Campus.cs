using Domain.Interfaces.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Campus : IHasID
    {
        public int CampusID { get; set; }
        public int ParentID { get; set; }
        public List<int> ParentIDs { get; set; } = new List<int>();
        public string CampusName { get; set; }
        public string CampusCode { get; set; }
        public string? Description { get; set; }
        public string CampusType { get; set; }
        public int SeatNumber { get; set; }
        public bool IsDeleted { get; set; }

        public int GetID()
        {
            return CampusID;
        }

        public void SetID(int id)
        {
            CampusID = id;
        }
    }
}
