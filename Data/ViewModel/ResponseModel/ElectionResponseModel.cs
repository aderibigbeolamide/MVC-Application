using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class ElectionResponseModel : BaseResponse
    {
        public ElectionVM Data {get; set;}
    }
}