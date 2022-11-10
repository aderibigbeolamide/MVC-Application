using MVCVottingApp.Data.ViewModel.RequestModel;
using MVCVottingApp.Data.ViewModel.ResponseModel;
using MVCVottingApp.Interface.Repository;
using MVCVottingApp.Interface.Services;
using MVCVottingApp.Model;

namespace MVCVottingApp.Implementation.Services
{
    public class PositionService : IPositionService
    {
        private readonly IPositionRepository _positionRepository;
        public PositionService(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        public async Task<BaseResponse> CreatePositionAsync(CreatePositionRequestModel model)
        {
            var position = await _positionRepository.GetAsync(x => x.PositionName == model.PositionName);
            if (position != null)
            {
                return new BaseResponse
                {
                    Message = "Position already exist",
                    Success = false
                };
            }
            var newPosition = new Position
            {
                PositionName = model.PositionName
            };
            return new BaseResponse
            {
                Message = "Position created successfully",
                Success = true
            };
        }
    }
}