using RGT.Services.Core;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsData.Import, "RGTMagicRoad")]
    [OutputType(typeof(string))]
    public class ImportMagicRoad : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Identity { get; set; }

        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await new Operations(Context).AddMagicRoadAsync(Identity));
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
