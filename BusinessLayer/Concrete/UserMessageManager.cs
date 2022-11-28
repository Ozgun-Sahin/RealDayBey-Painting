using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class UserMessageManager: IUserMessageServices
    {
        IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public List<UserMessage> GetUserMessageWithUserService()
        {
           return _userMessageDal.GetUserMessagesWithUser();
        }

        public void TAdd(UserMessage t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(UserMessage t)
        {
            throw new NotImplementedException();
        }

        public UserMessage TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserMessage> TGetList()
        {
           return _userMessageDal.GetList();
        }

        public List<UserMessage> TGetListByFilter()
        {
            throw new NotImplementedException();
        }

        public List<UserMessage> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(UserMessage t)
        {
            throw new NotImplementedException();
        }
    }
}
