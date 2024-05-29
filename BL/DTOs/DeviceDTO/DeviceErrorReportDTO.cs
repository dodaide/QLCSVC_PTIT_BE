namespace Application.DTOs.DeviceDTO;

public class DeviceErrorReportDTO
{
    public int ID { get; set; }
    public int DeviceID { get; set; }
    public int UserID { get; set; }
    public string Note { get; set; }
    public string Image { get; set; }
}