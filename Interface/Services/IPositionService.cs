using MVCVottingApp.Data.Base;
using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;
using MVCVottingApp.Model;

namespace MVCVottingApp.Interface.Services
{
    public interface IPositionService 
    {
         Task<BaseResponse> CreatePositionAsync(CreatePositionRequestModel model);
    }
}