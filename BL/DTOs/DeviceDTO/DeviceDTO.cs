namespace Application.DTOs.DeviceDTO;

public class DeviceDTO
{
    public int DeviceID { get; set; }
    public string DeviceName { get; set; }
    public string DeviceCode { get; set; }
    public string Note { get; set; }
    public int Quality { get; set; }
    public int IsDeleted { get; set; }
    public int UserManagerID { get; set; }
    public int CampusID { get; set; }
    public DateTime CreatedTime { get; set; }
}