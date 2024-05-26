using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.DomainInterfaces
{
    public interface IHasID
    {
        public int GetID();
        public void SetID(int id);
    }
}
