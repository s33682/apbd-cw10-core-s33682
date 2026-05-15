namespace CoreApp.Services;

using CoreApp.DTOs;

public interface IDbService
{
    Task<IEnumerable<GetPcDto>> GetPCsAsync();
    Task<GetPcByIdDto> GetPcByIdsAsync(int pcId);
}