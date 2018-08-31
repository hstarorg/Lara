using Hstar.Lara.DI;
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