using Domain.Interfaces.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Area : IHasID
    {
        public int AreaID { get; set; }
        public string AreaCode { get; set; }
        public string AreaName { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
        public int GetID()
        {
            return AreaID;
        }

        public void SetID(int id)
        {
            AreaID = id;
        }
    }
}
