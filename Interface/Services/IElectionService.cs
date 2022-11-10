using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;

namespace MVCVottingApp.Interface.Services
{
    public interface IElectionService
    {
         Task<BaseResponse> CreateElectionAsync(CreateElectionRequestModel model);
         Task<List<ElectionResponseModel>> GetElectionToDisplayAsync();
        Task<ElectionResponseModel> GetElectionByStartDateAsync(int id, DateTime StartDate);
        Task<ElectionResponseModel> GetElectionByEndDateAsync(int id, DateTime EndDate);
    }
}