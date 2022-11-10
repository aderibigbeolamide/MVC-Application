using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class ContestantsResponseModel : BaseResponse
    {
        public List<ContestantVM> Data { get; set; } = new List<ContestantVM>();
    }
}