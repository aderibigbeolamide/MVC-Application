using MVCVottingApp.Data.Base;

namespace MVCVottingApp.Model
{
    public class Voter : AuditableEntity
    {
        public int CastVote {get; set;}
        public int StudentId {get; set;}
        public Student Student {get; set;}
        public int ElectionId {get; set;}
        public Election Election {get; set;}
        public List<Student> Students {get; set;} = new List<Student>();
    }
}