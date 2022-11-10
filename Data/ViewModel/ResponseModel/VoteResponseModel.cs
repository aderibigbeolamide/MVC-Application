using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class VoteResponseModel : BaseResponse
    {
        public VoteVM Data { get; set; }
    }
}