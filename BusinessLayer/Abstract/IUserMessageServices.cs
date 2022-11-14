using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IUserMessageServices : IGenericServices<UserMessage>
    {
        List<UserMessage> GetUserMessageWithUserService();
    }
}
