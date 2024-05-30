namespace Application.DTOs.Campus;

public class CampusGetAllDTO
{
    public int CampusID { get; set; }
    public List<int> ParentIDs { get; set; }
    public string CampusName { get; set; }
    public string CampusCode { get; set; }
    public string? Description { get; set; }
    public int CampusType { get; set; }
    public int SeatNumber { get; set; }
    public bool IsDeleted { get; set; }
}