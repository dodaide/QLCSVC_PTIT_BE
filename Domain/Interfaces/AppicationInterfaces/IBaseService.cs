namespace Domain.Interfaces.ApplicationInterfaces;

public interface IBaseService<T, TDetail>
{
    Task<IEnumerable<DTO>> GetAll<DTO>();
    Task<int> Insert<DTO, DTODetail>(DTO t, List<DTODetail> detailDTOs);
    Task<int> Insert<DTO>(DTO t);
    Task<int> Update<DTO, DTODetail>(DTO t, List<DTODetail> detailDTOs); 
    Task<int> Update<DTO>(DTO t); 
    Task<int> Delete<DTO>(DTO id);
    Task<IEnumerable<DTO>> GetDetailsByID<DTO>(int id);
}