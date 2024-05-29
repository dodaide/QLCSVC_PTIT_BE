using Domain.Interfaces.DomainInterfaces;

namespace Domain.Entities;

public class AreaCampus : IHasID
{
    public int AreaID { get; set; }
    public int CampusID { get; set; }
    public string CampusName { get; set; }
    public int SortIndex { get; set; }

    public int GetID()
    {
        return CampusID;
    }

    public void SetID(int id)
    {
        AreaID = id;
    }
}