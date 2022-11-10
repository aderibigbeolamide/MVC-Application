using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class VotersResponseModel : BaseResponse
    {
        public List<VoterVM> Data { get; set; } = new List<VoterVM>();
    }
}