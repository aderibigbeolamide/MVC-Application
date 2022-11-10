using System;
using MVCVottingApp.Data.Base;

namespace MVCVottingApp.Model
{
    public class Election : AuditableEntity
    {
        public string ElectionName {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public bool IsDisplay {get; set;}
        public List<Position> PositionId {get; set;} = new List<Position>();  
    }
}