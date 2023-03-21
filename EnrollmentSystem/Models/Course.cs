using System.Runtime.Serialization;

namespace EnrollmentSystem.Models
{
    [DataContract]
    [Serializable]
    public class Course
    {
        public int Course_Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
      }
}
 
