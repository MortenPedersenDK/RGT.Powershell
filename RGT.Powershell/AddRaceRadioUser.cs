using RGT.Services.Core;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Add, "RGTRaceRadioUser")]
    [OutputType(typeof(bool))]
    public class AddRaceRadioUser : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        public string EventId { get; set; }

        [Parameter(Mandatory = true)]
        public string UserEmail { get; set; }

        protected override void InternalProcessRecord()
        {
            if (string.IsNullOrWhiteSpace(EventId)) { throw new PSArgumentException("EventId not valid"); }
            if (string.IsNullOrWhiteSpace(UserEmail)) { throw new PSArgumentException("UserEmail not valid"); } // TODO: Make better validation on email format.

            var task = Task.Run(async () => await new Operations(Context).AddRaceRadioUserAsync(EventId, UserEmail));
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
