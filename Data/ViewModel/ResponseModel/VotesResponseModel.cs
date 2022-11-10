using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class VotesResponseModel : BaseResponse
    {
        public List<VoteVM> Data { get; set; } = new List<VoteVM>();
    }
}