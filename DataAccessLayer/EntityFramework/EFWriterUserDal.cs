﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityFramework
{
    public class EFWriterUserDal : GenericRepository<WriterUser> , IWriterUserDal
    {

    }
}
