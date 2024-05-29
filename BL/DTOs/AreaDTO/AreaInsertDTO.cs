using Application.DTOs.AreaCampusDTO;

namespace Application.DTOs.AreaDTO;

public class AreaInsertDTO
{
    public AreaInsertMasterDTO Area { get; set; }
    public List<AreaCampusSaveDTO> Details { get; set; }
}