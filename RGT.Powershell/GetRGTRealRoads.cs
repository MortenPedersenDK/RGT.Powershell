using RGT.Services.Core;
using RGT.Services.Core.DTO;
using System.Collections.Generic;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.Get, "RGTRealRoads")]
    [OutputType(typeof(IList<RealRoad>))]
    public class GetRGTRealRoads : SecureCmdlet
    {
        protected override void InternalProcessRecord()
        {
            var task = Task.Run(async () => await new Operations(Context).GetRealRoadsAsync());
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
