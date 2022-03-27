using Domain.Entities;

namespace Application.Communication.EntityResponses
{
    public class UserResponse : BaseResponse<User>
    {
        public UserResponse(bool success): base(success) { }
        public UserResponse(User user): base(user) { }
        public UserResponse(bool success, string message): base(success, message) { }
    }
}