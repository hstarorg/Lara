﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp1.Business
{
    public interface IUserBusiness
    {
        Task<string> GetUserName();
    }
}
