using MVCVottingApp.Data.ViewModel.ResponseModel;

namespace MVCVottingApp.Interface.Services
{
    public interface IVoteService
    {
         Task<BaseResponse> CastVoteAsync(int VoterId);
         Task<VoteResponseModel> GetHighestVoteByContestantIdAsync();
         Task<VotesResponseModel> GetAllVotesAsync();
    }
}