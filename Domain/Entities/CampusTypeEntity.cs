using Domain.Interfaces.DomainInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CampusTypeEntity : IHasID
    {
        public int CampusType { get; set; }
        public string CampusTypeName { get; set; }    
        public string Description { get; set; }

        public int GetID()
        {
            throw new NotImplementedException();
        }

        public void SetID(int id)
        {
            throw new NotImplementedException();
        }
    }
}
