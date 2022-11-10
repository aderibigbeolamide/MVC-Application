using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;

namespace MVCVottingApp.Interface.Services
{
    public interface IContestantService
    {
         Task<BaseResponse> CheckContestantVoteAsync(int id);
         Task<BaseResponse> ContestAsyc(int id, decimal grade);
         Task<BaseResponse> CreateContestantAsync(CreateContestRequestModel model);
         Task<ContestantsResponseModel> GetAllContestantAsync();
    }
}