using Domain.Interfaces.DomainInterfaces;

namespace Domain.Entities;

public class Campus : IHasID
{
    public int CampusID { get; set; }
    public int ParentID { get; set; }
    public List<int> ParentIDs { get; set; } = new();
    public string CampusName { get; set; }
    public string CampusCode { get; set; }
    public string? Description { get; set; }
    public string CampusType { get; set; }
    public int SeatNumber { get; set; }
    public bool IsDeleted { get; set; }

    public int GetID()
    {
        return CampusID;
    }

    public void SetID(int id)
    {
        CampusID = id;
    }
}