using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    internal class EFSocialMediaDal: GenericRepository<SocialMedia> , ISocialMediaDal
    {
    }
}
