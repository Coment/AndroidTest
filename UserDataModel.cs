using System;
using System.Collections.Generic;
using System.Text;

namespace AndroidTest
{
    public class UserDataModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string PreferedProgrammingLanguage { get; set; }
        public string AcceptAdds { get; set; }
        public string PreferedCar { get; set; }

        public static UserDataModel DefaultData => new UserDataModel
        {
            UserName = "TestUser",
            Email = "test@test.com",
            Password = "123456",
            Name = "TestName",
            PreferedProgrammingLanguage ="C#",
            AcceptAdds = "true",
            PreferedCar = "Mercedes"
        };
    }
}
