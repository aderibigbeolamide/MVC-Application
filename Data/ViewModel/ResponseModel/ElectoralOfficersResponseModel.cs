using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class ElectoralOfficersResponseModel : BaseResponse
    {
        public List<ElectoralOfficerVM> Data { get; set; } = new List<ElectoralOfficerVM>();
    }
}