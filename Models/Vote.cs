using MVCVottingApp.Data.Base;

namespace MVCVottingApp.Model
{
    public class Vote : AuditableEntity
    {
        public Contestant Contestant {get; set;}
        public int ContestantId {get; set;}
        public string ContestantName {get; set;}
        public string ElectionName {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
        public int VoterId {get; set;}
        public Voter Voter {get; set;}
        public Student Student {get; set;}
    }
}