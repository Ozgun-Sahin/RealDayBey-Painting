using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Abstract
{
    public interface IUserMessageDal :IGenericDal<UserMessage>
    {
        public List<UserMessage> GetUserMessagesWithUser();
    }
}
