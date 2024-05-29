using Application.DTOs.AreaCampusDTO;

namespace Application.DTOs.AreaDTO;

public class AreaUpdateDTO
{
    public AreaUpdateMasterDTO Area { get; set; }
    public List<AreaCampusSaveDTO> Details { get; set; }
}