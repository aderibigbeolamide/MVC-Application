using MVCVottingApp.Data.Base;

namespace MVCVottingApp.Model
{
    public class Position : AuditableEntity
    {
        public string PositionName {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
    }
}