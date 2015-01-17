using System;
using Hstar.Core.Serializer;

namespace Hstar.Core.ConsoleDemo
{
    public class Test1
    {
        public string GetTest()
        {
            return "ioc test";
        }

        public string TestJson()
        {
            return JsonSerializerHelper.Serialize(new {Name = "Jay", Date = DateTime.Now});
        }
    }
}
