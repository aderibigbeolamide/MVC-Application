using System.ComponentModel.DataAnnotations;
using MVCVottingApp.Data.Base;
using MVCVottingApp.Enum;

namespace MVCVottingApp.Model
{
    public abstract class Person : AuditableEntity
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string NextOfKin { get; set; }
    }
}
