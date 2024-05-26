using Domain.Interfaces.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class AreaCampus : IHasID
    {
        public int AreaID { get; set; } 
        public int CampusID { get; set; }
        public string CampusName { get; set; }
        public int SortIndex { get; set; }

        public int GetID()
        {
            return CampusID;
        }

        public void SetID(int id)
        {
            AreaID = id;
        }
    }
}
