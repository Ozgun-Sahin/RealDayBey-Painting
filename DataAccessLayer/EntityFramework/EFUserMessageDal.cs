using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntitiyLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFUserMessageDal : GenericRepository<UserMessage>, IUserMessageDal
    {
        public List<UserMessage> GetUserMessagesWithUser()
        {
            using (var c = new Context())
            {
                return c.UserMessages.Include(x => x.User).ToList();
            }

            //Context c = new Context();

            //return c.UserMessages.Include(x => x.User).ToList();

        }
    }
}
