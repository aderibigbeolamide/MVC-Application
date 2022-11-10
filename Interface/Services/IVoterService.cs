using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;

namespace MVCVottingApp.Interface.Services
{
    public interface IVoterService
    {
        Task<BaseResponse> CreateVoterAsync(CreateVoterRequestModel model);
        Task<VotersResponseModel> GetAllVotersAsync();
        Task<VoterResponseModel> GetVoterByMatricNumberForElectionAsync(string matricNumber, int electionId);
    }
}