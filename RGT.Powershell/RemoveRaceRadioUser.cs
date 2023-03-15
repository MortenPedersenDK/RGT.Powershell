using RGT.Services.Core;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Remove, "RGTRaceRadioUser")]
    [OutputType(typeof(bool))]
    public class RemoveRaceRadioUser : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        public string EventId { get; set; }
        [Parameter(Mandatory = true)]
        public int UserId { get; set; }

        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await new Operations(Context).DeleteRaceRadioUserAsync(EventId, UserId));
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
