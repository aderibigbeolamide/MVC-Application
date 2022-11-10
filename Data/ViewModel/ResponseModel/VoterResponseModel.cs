using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class VoterResponseModel : BaseResponse
    {
        public VoterVM Data { get; set; }
    }
}