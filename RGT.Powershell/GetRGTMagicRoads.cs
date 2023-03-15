using RGT.Services.Core;
using RGT.Services.Core.DTO;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Get, "RGTMagicRoads")]
    [OutputType(typeof(IList<MagicRoad>))]
    public class GetRGTMagicRoads : SecureCmdlet
    {
        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await new Operations(Context).GetMagicRoadsAsync());
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
