using AutoMapper;
using Dapper;
using Domain.Entities;
using Domain.Interfaces.ApplicationInterfaces;
using Domain.Interfaces.DomainInterfaces;
using Domain.Interfaces.InfrastructureInterfaces;
using Domain.Resource;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services;

public class BaseService<T, TDetail> : IBaseService<T, TDetail> where T : IHasID where TDetail : IHasID
{
    protected readonly IMapper mapper;
    protected readonly string masterName;
    protected readonly IMemoryCache memoryCache;
    protected readonly List<string> messages = new();
    protected IBaseRepo<TDetail> baseDetailRepo;
    protected IBaseRepo<T> baseRepo;
    protected IUnitOfWork unitOfWork;

    public BaseService(IBaseRepo<T> iBaseRepo, IBaseRepo<TDetail> iBaseDetailRepo, IUnitOfWork iUnitOfWork,
        IMapper iMapper, IMemoryCache iMemoryCache)
    {
        baseRepo = iBaseRepo;
        baseDetailRepo = iBaseDetailRepo;
        unitOfWork = iUnitOfWork;
        mapper = iMapper;
        masterName = typeof(T).Name;
        memoryCache = iMemoryCache;
    }

    public virtual async Task<IEnumerable<DTO>> GetAll<DTO>()
    {
        var res = await baseRepo.GetAll();
        var resDTO = mapper.Map<IEnumerable<DTO>>(res);
        return resDTO;
    }

    public async Task<int> UpdateSingleRecord<DTO>(DTO dto)
    {
        var t = mapper.Map<T>(dto);
        var res = await baseRepo.Update(t);
        return res;
    }

    public virtual async Task<int> Delete<DTO>(DTO dto)
    {
        var t = mapper.Map<T>(dto);
        var res = await baseRepo.Delete(t);
        return res;
    }

    public virtual async Task<int> Insert<DTO, DTODetail>(DTO dto, List<DTODetail> detailDTOs)
    {
        var t = mapper.Map<T>(dto);
        var details = mapper.Map<List<TDetail>>(detailDTOs);
        Validate(t, details);
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var masterID = await baseRepo.Insert(t);
            foreach (var detail in details)
            {
                detail.SetID(masterID);
                await baseDetailRepo.Insert(detail);
            }

            await unitOfWork.CommitAsync();
            return 1;
        }
        catch (Exception)
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public async Task<int> InsertSingleRecord<DTO>(DTO dto)
    {
        var t = mapper.Map<T>(dto);
        var res = await baseRepo.Insert(t);
        return res;
    }

    public virtual async Task<int> Update<DTO, DTODetail>(DTO dto, List<DTODetail> detailDTOs)
    {
        var t = mapper.Map<T>(dto);
        var details = mapper.Map<List<TDetail>>(detailDTOs);
        Validate(t, details);
        try
        {
            await unitOfWork.BeginTransactionAsync();
            var res = await baseRepo.Update(t);

            foreach (var detail in details) detail.SetID(t.GetID());

            var existingDetails = await baseDetailRepo.GetDetailsByID(t.GetID(), masterName);
            var existingDetailIds = new HashSet<int>(existingDetails.Select(d => d.GetID()));
            var updatedDetailIds = new HashSet<int>(details.Select(d => d.GetID()));

            // Delete details that are not in the updated list
            var detailsToDelete = existingDetails.Where(d => !updatedDetailIds.Contains(d.GetID())).ToList();

            foreach (var detail in detailsToDelete)
            {
                detail.SetID(t.GetID());
                await baseDetailRepo.Delete(detail);
            }

            foreach (var detail in details)
                if (existingDetailIds.Contains(detail.GetID()))
                {
                    await baseDetailRepo.Update(detail);
                }
                else
                {
                    detail.SetID(t.GetID());
                    await baseDetailRepo.Insert(detail);
                }

            await unitOfWork.CommitAsync();
            return 1;
        }
        catch (Exception)
        {
            await unitOfWork.RollbackAsync();
            throw;
        }
    }

    public virtual async Task<IEnumerable<DTO>> GetDetailsByID<DTO>(int id)
    {
        var res = await baseDetailRepo.GetDetailsByID(id, masterName);
        var resDTO = mapper.Map<IEnumerable<DTO>>(res);
        return resDTO;
    }

    protected virtual void Validate(T t, List<TDetail>? tDetails = null)
    {
        CustomValidate(t, tDetails);
        if (messages.Count > 0) throw new ValidateException(CommonResource.ValidateMessage, messages);
    }

    protected virtual void CustomValidate(T t, List<TDetail>? tDetails = null)
    {
    }
}