using RGT.Services.Core.API;
using RGT.Services.Core.DTO;
using System.Threading.Tasks;

namespace RGT.Services.Core
{
    public class Logon
    {
        public static async Task<Context> GetContext(string username, string password)
        {
            return await new RGTAPI().Login(username, password);
        }
    }
}
