using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;

namespace MVCVottingApp.Interface.Services
{
    public interface IStudentService
    {
         Task<BaseResponse> CreateStudentAsync(CreateStudentRequestModel model);
         Task<BaseResponse> UpdateStudentAsync(UpdateStudentRequestModel model, int id);
         Task<BaseResponse> DeleteStudnetAsync(int id);
         Task<StudentResponseModel> ApproveStudentAsync(int id);
         Task<StudentResponseModel> LoginByMatricNoAndPasswordAsync(string MatricNo, string password);
    }
}