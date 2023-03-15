using RGT.Services.Core.DTO;

namespace RGT.Services.Core.Data
{
    public class ContextContainer
    {
        public static Context CurrentContext { get; set; } = null;
    }
}
