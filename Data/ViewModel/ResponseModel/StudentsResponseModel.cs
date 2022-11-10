using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class StudentsResponseModel : BaseResponse
    {
        public List<StudentVM> Data {get; set;} = new List<StudentVM>();
    }
}