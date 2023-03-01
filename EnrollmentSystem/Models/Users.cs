using System.Runtime.Serialization;

namespace EnrollmentSystem.Models
{
    [DataContract]
    [Serializable]
    public class Users
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string EmailAddress { get; set; } = "";
        public string UserName { get; set; } = "";
        public string Password { get; set; } = "";

    }
}





/*
[Key]

[Required]
[Column(TypeName = "nvarchar(150)")]

public int Student_Id { get; set; }
public string FirstName { get; set; } = "";
public string LastName { get; set; } = "";
public string Address { get; set; } = "";
}
}
*/