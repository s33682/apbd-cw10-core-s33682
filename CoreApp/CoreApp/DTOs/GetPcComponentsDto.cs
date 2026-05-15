namespace CoreApp.DTOs;

public class GetPcComponentsDto
{
    public int Amount { get; set; }
    public GetComponentDto Component { get; set; } = new  GetComponentDto();
}