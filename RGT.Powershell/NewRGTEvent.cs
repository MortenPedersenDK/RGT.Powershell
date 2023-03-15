using RGT.Services.Core;
using RGT.Services.Core.DTO;
using System;
using System.Management.Automation;
using System.Threading.Tasks;

namespace RGT.Powershell
{
    [Cmdlet(VerbsCommon.New, "RGTEvent")]
    [OutputType(typeof(EventInformation))]
    public class NewRGTEvent : SecureCmdlet
    {
        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Start { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EventName { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string EventDescription { get; set; }

        [Parameter(Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string RoadUID { get; set; }

        [Parameter(Mandatory = false)]
        public int Laps { get; set; } = 1;

        [Parameter(Mandatory = false)]
        [ValidateSet("Classic", "Spring_in_Europe")]
        public string Scene { get; set; } = "Classic";

        [Parameter(Mandatory = false)]
        public SwitchParameter Public { get; set; } = false;

        [Parameter(Mandatory = false)]
        public Branding Branding { get; set; }

        [Parameter(Mandatory = false)]
        public int Bots { get; set; } = 0;

        [Parameter(Mandatory = false)]
        public int BotsMinPwr { get; set; } = 70;

        [Parameter(Mandatory = false)]
        [ValidateSet("Pacing", "Real")]
        public string BotsType { get; set; } = "Real";

        [Parameter(Mandatory = false)]
        [ValidateSet("Beginner", "Custom", "Distributed", "Expert", "Intermediate")]
        public string BotsMode { get; set; } = "Beginner";

        [Parameter(Mandatory = false)]
        public int BotsMaxPwr { get; set; } = 310;

        [Parameter(Mandatory = false)]
        [ValidateSet("Race", "Group")]
        public string RaceType { get; set; } = "Race";

        [Parameter(Mandatory = false)]
        public int Releasegap { get; set; } = 15;

        [Parameter(Mandatory = false)]
        public int RidersPerRelease { get; set; } = 1;

        [Parameter(Mandatory = false)]
        public SwitchParameter RubberBand { get; set; } = false;

        [Parameter(Mandatory = false)]
        public SwitchParameter NoDrafting { get; set; } = false;

        [Parameter(Mandatory = false)]
        public SwitchParameter NoMassStart { get; set; } = false;

        protected override void InternalProcessRecord()
        {
            if (!DateTime.TryParse(Start, out DateTime start))
            {
                throw new PSArgumentException("Invalid format in Start parameter. Use ISO 8601 format yyyy-mm-ddThh:mm or dd-mm-yyyy hh:mm.");
            }

            var scene = "Classic".Equals(Scene) ? Scenes.Classic : Scenes.SpringInEurope;
            var raceType = "Race".Equals(RaceType) ? RGT.Services.Core.RaceType.Race : Services.Core.RaceType.Groupride;
            var botsType = "Real".Equals(BotsType) ? RGT.Services.Core.BotsType.Real : Services.Core.BotsType.Pacing;
            var botsMode = RGT.Services.Core.BotsMode.Beginner;
            switch (BotsMode)
            {
                case "Custom":
                    botsMode = Services.Core.BotsMode.Custom;
                    break;
                case "Distributed":
                    botsMode = Services.Core.BotsMode.Distributed;
                    break;
                case "Expert":
                    botsMode = Services.Core.BotsMode.Expert;
                    break;
                case "Intermediate":
                    botsMode = Services.Core.BotsMode.Intermediate;
                    break;
            }
            var evt = new Event(Context);

            var task = Task.Run(async () => await evt.Create(start, EventName, EventDescription, RoadUID, laps: Laps, scene: scene, branding: Branding, isPrivate: !Public, raceType: raceType, numBots: Bots, botsMinPwr: BotsMinPwr, botsMaxPwr: BotsMaxPwr, botsMode: botsMode, botsType: botsType, rubberband: RubberBand, drafting: !NoDrafting, massstart: !NoMassStart, releasegap: Releasegap, ridersPerRelease: RidersPerRelease));
            task.Wait();
            WriteObject(task.Result);
        }
    }
}
