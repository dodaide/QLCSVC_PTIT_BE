using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.ApplicationInterfaces
{
    public interface IBaseService<T, TDetail>
    {
        Task<IEnumerable<DTO>> GetAll<DTO>();
        Task<int> Insert<DTO, DTODetail>(DTO t, List<DTODetail> detailDTOs);
        Task<int> Update<DTO, DTODetail>(DTO t, List<DTODetail> detailDTOs);
        Task<int> Delete<DTO>(DTO id);
        Task<IEnumerable<DTO>> GetDetailsByID<DTO>(int id);
    }
}
