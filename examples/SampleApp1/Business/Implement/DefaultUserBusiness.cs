using Hstar.Lara.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp1.Business.Implement
{
    [AutoRegister()]
    public class DefaultUserBusiness : IUserBusiness
    {
        public async Task<string> GetUserName()
        {
            return await Task.Run(() => "hello");
        }
    }
}
