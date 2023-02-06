﻿using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstract
{
    public interface IProjectService : IGenericServices<Project>
    {
        List<Project> GetListPendingProject();

        List<Project> GetListWorkInProgressProject();

        List<Project> GetListCompletedProject();
    }
}