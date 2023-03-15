using RGT.Services.Core;
using RGT.Services.Core.Data;
using RGT.Services.Core.DTO;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommunications.Connect, "RGTService")]
    [OutputType(typeof(Context))]
    public class ConnectRGTService : BaseCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Login { get; set; }

        [Parameter(Mandatory = true)]
        public string Password { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter ReturnContext { get; set; }

        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await Logon.GetContext(Login, Password));
            task.Wait();
            ContextContainer.CurrentContext = task.Result;
            if (ReturnContext.IsPresent)
            {
                WriteObject(task.Result);
            }
        }
    }
}
