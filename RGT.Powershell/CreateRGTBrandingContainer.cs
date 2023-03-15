using RGT.Services.Core.DTO;
using System.IO;
using System.Linq;
using System.Management.Automation;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.New, "RGTBrandingContainer")]
    [OutputType(typeof(Branding))]
    public class CreateRGTBrandingContainer : BaseCmdlet
    {
        [Parameter(Mandatory = false)]
        public string BrandingFolder { get; set; }
        protected override void InternalProcessRecord()
        {
            var branding = new Branding();
            if (!string.IsNullOrWhiteSpace(BrandingFolder))
            {
                FindBrandingFiles(branding);
            }
            WriteObject(branding);
        }

        private void FindBrandingFiles(Branding branding)
        {
            if (!Directory.Exists(BrandingFolder))
            {
                return;
            }

            var files = Directory.GetFiles(BrandingFolder, "*.png");
            branding.Billboard01 = files.FirstOrDefault(x => x.EndsWith("Billboard01.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Billboard02 = files.FirstOrDefault(x => x.EndsWith("Billboard02.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Billboard03 = files.FirstOrDefault(x => x.EndsWith("Billboard03.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Decal01 = files.FirstOrDefault(x => x.EndsWith("Decal01.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Decal02 = files.FirstOrDefault(x => x.EndsWith("Decal02.png", System.StringComparison.OrdinalIgnoreCase));
            branding.EventThumbnail = files.FirstOrDefault(x => x.EndsWith("EventThumbnail.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence01 = files.FirstOrDefault(x => x.EndsWith("Fence01.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence02 = files.FirstOrDefault(x => x.EndsWith("Fence02.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence03 = files.FirstOrDefault(x => x.EndsWith("Fence03.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence04 = files.FirstOrDefault(x => x.EndsWith("Fence04.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence05 = files.FirstOrDefault(x => x.EndsWith("Fence05.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Fence06 = files.FirstOrDefault(x => x.EndsWith("Fence06.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Flag01 = files.FirstOrDefault(x => x.EndsWith("Flag01.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Flag02 = files.FirstOrDefault(x => x.EndsWith("Flag02.png", System.StringComparison.OrdinalIgnoreCase));
            branding.Flag03 = files.FirstOrDefault(x => x.EndsWith("Flag03.png", System.StringComparison.OrdinalIgnoreCase));
            branding.GateMainSide = files.FirstOrDefault(x => x.EndsWith("GateMainSide.png", System.StringComparison.OrdinalIgnoreCase));
            branding.GateMainTop = files.FirstOrDefault(x => x.EndsWith("GateMainTop.png", System.StringComparison.OrdinalIgnoreCase));
            branding.GateSegmentSide = files.FirstOrDefault(x => x.EndsWith("GateSegmentSide.png", System.StringComparison.OrdinalIgnoreCase));
            branding.GateSegmentTop = files.FirstOrDefault(x => x.EndsWith("GateSegmentTop.png", System.StringComparison.OrdinalIgnoreCase));
            branding.SignDistance = files.FirstOrDefault(x => x.EndsWith("SignDistance.png", System.StringComparison.OrdinalIgnoreCase));
            branding.TentBasicTop = files.FirstOrDefault(x => x.EndsWith("TentBasicTop.png", System.StringComparison.OrdinalIgnoreCase));
            branding.TentBasicWall = files.FirstOrDefault(x => x.EndsWith("TentBasicWall.png", System.StringComparison.OrdinalIgnoreCase));
            branding.TentTechTop = files.FirstOrDefault(x => x.EndsWith("TentTechTop.png", System.StringComparison.OrdinalIgnoreCase));
            branding.TentTechWall = files.FirstOrDefault(x => x.EndsWith("TentTechWall.png", System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
