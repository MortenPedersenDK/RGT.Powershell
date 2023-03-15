using RGT.Services.Core;
using RGT.Services.Core.DTO;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Get, "RGTRaceRadioUsers")]
    [OutputType(typeof(IList<RaceRadioUser>))]
    public class GetRaceRadioUsers : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        public string EventId { get; set; }

        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await new Operations(Context).GetRaceRadioUsersAsync(EventId));
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
