using Domain.Interfaces.DomainInterfaces;

namespace Domain.Entities;

public class DeviceErrorReport : IHasID
{
    public int ID { get; set; }
    public int DeviceID { get; set; }
    public int UserID { get; set; }
    public string Note { get; set; }
    public string Image { get; set; }
    public DateTime CreatedAt { get; set; }

    public int GetID()
    {
        return ID;
    }

    public void SetID(int id)
    {
        ID = id;
    }
}