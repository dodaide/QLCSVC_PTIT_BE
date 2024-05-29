using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.AppicationInterfaces;
using Domain.Interfaces.InfrastructureInterfaces;
using Microsoft.Extensions.Caching.Memory;

namespace Application.Services;

public class CampusService : BaseService<Campus, Campus>, ICampusService
{
    public CampusService(IBaseRepo<Campus> iBaseRepo, IBaseRepo<Campus> iBaseDetailRepo, IUnitOfWork iUnitOfWork,
        IMapper iMapper, IMemoryCache iMemoryCache) : base(iBaseRepo, iBaseDetailRepo, iUnitOfWork, iMapper,
        iMemoryCache)
    {
    }

    public override async Task<IEnumerable<DTO>> GetAll<DTO>()
    {
        const string cacheKey = "ProcessedCampuses";
        if (!memoryCache.TryGetValue(cacheKey, out List<DTO> processedCampuses))
        {
            var campus = await base.GetAll<Campus>();
            processedCampuses = ProcessCampuses<DTO>(campus.ToList());
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            };

            memoryCache.Set(cacheKey, processedCampuses, cacheEntryOptions);
        }

        return processedCampuses;
    }

    private List<DTO> ProcessCampuses<DTO>(List<Campus> campuses)
    {
        // Tạo một từ điển để tra cứu campus theo CampusID
        var campusDictionary = campuses.ToDictionary(c => c.CampusID);

        // Duyệt qua từng campus để xây dựng danh sách ParentIDs
        foreach (var campus in campuses)
        {
            var current = campus;
            while (current.ParentID != 0)
                if (campusDictionary.TryGetValue(current.ParentID, out var parentCampus))
                {
                    campus.ParentIDs.Insert(0, parentCampus.CampusID); // Thêm vào đầu danh sách để duy trì thứ tự
                    current = parentCampus;
                }
                else
                {
                    break; // Nếu không tìm thấy parent, thoát khỏi vòng lặp
                }
        }

        var campusesDTO = mapper.Map<List<DTO>>(campuses);

        return campusesDTO;
    }
}