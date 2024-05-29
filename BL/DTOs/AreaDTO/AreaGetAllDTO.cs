namespace Application.DTOs.AreaDTO;

public class AreaGetAllDTO
{
    public int AreaID { get; set; }
    public string AreaCode { get; set; }
    public string AreaName { get; set; }
    public bool IsDeleted { get; set; }
}