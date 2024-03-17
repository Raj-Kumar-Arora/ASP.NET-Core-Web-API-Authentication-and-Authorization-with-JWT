namespace JWT_Demo.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel()
            {Username = "user1_admin", Email = "user1@email.com", Password="user@Password", Role="Administrator", DisplayName = "User_1 (Admin)"},
            new UserModel()
            {Username = "user2_non_admin", Email = "user2@email.com", Password="user@Password", Role="StandardUsr", DisplayName = "User_2 (Non-Admin)" },
        };
    }
}
