using RGT.Services.Core;
using RGT.Services.Core.DTO;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Get, "RGTRaceResult")]
    [OutputType(typeof(EventResult))]
    public class GetRaceResult : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EventId { get; set; }

        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async() => await new Operations(Context).GetEventResultAsync(EventId));   
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
