using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp1.Business;
using SampleApp1.Models;

namespace SampleApp1.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserBusiness userBiz;

        public UserController(IUserBusiness userBiz)
        {
            this.userBiz = userBiz;
        }

        /// <summary>
        /// Get username.
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("username")]
        public async Task<object> GetUserNameAsync()
        {
            return await this.userBiz.GetUserName();
        }

        /// <summary>
        /// Test error
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("error")]
        public async Task<object> TestError()
        {

            var isEven = new Random().Next(0, 10) % 2 == 0;
            if (isEven)
            {
                int a = 0;
                var b = 100 / a;
            }
            else
            {
                throw new BusinessException("这是一个业务异常");
            }
            return await this.userBiz.GetUserName();
        }
    }
}
