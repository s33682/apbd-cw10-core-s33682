namespace CoreApp.Services;

using CoreApp.DTOs;

public interface IDbService
{
    Task<IEnumerable<GetPcDto>> GetPCsAsync();
    Task<GetPcByIdDto> GetPcByIdsAsync(int pcId);
    Task<GetPcDto> AddPcAsync(PostPcDto postPc);
    Task<GetPcDto> UpdatePcAsync(int pcId, PostPcDto postPc);
    Task DeletePcAsync(int pcId);
}