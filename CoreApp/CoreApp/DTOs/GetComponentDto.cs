namespace CoreApp.DTOs;

public class GetComponentDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public GetManufacturerDto Manufacturer { get; set; } = new GetManufacturerDto();
    public GetTypeDto Type { get; set; } = new GetTypeDto();
}