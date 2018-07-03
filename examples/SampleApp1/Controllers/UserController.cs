using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleApp1.Business;

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
    }
}
