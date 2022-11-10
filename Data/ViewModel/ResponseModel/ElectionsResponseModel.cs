using MVCVottingApp.ViewModel;

namespace MVCVottingApp.Data.ViewModel.ResponseModel
{
    public class ElectionsResponseModel
    {
        public List<ElectionVM> ElectionVMs { get; set; } = new List<ElectionVM>();
    }
}