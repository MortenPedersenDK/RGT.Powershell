using RGT.Services.Core.DTO;

namespace RGT.Services.Core
{
    public class Event
    {
        private Context _ctx;
        private Operations ops;

        public Event(Context ctx)
        {
            _ctx = ctx;
            ops = new Operations();
        }



        public async Task<EventInformation> Create(DateTime start, string eventName, string eventDescription, string roadUID, bool magicRoad = true, int laps = 1, Scenes scene = Scenes.Classic, EventType eventType = EventType.Race, Branding? branding = null, bool isPrivate = true)
        {
            if (string.IsNullOrWhiteSpace(eventName)) throw new ArgumentException("eventName cannot be blank");
            if (string.IsNullOrWhiteSpace(eventDescription)) throw new ArgumentException("eventDescription cannot be blank");
            if (start < DateTime.Now) throw new ArgumentException("Event cannot start in the past");

            if(branding != null)
            {
                branding.Validate();
            }

            if (string.IsNullOrWhiteSpace(roadUID))
            {
                throw new ArgumentException("Road UID not specified");
            }

            var road = await GetRoad(roadUID);

            string sceneStr = GetSceneString(scene);

            var eventId = await ops.CreateRace(_ctx, start, road.Id.ToString(), eventName, eventDescription, laps, sceneStr, branding, isPrivate);

            return new EventInformation
            {
                EventId = eventId,
                SignupLink = "https://user.rgtcycling.com/event?code=" + eventId,
                TotalDistance = road.Length * laps,
                TotalElevation = road.Elevation * laps
            };
        }

        public string GetSceneString(Scenes scene)
        {
            switch (scene)
            {
                case Scenes.SpringInEurope:
                    return "gen02";
                default:
                    return "gen01";
            }
        }

        public async Task<Road?> FindRoadInInventory(string name)
        {
            var ops = new Operations();
            var roads = await ops.GetMagicRoads(_ctx);
            var road = roads.FirstOrDefault(x => x.Name.Equals(name) ||x.Label.StartsWith(name));
            return road;
        }

        public async Task<string> FindMagicRoad(string name)
        {
            var roads = await ops.SearchMagicRoadsByName(_ctx, name);
            var road = roads.FirstOrDefault(x => x.Label.StartsWith(name));
            if (road != null)
            {
                return road.Name;
            }
            return null;

        }

        public async Task<string> ImportMagicRoad(string roadUID)
        {
            var id = await ops.AddMagicRoad(roadUID, _ctx);
            return id;
        }

        public async Task<Road> GetRoad(string roadUID)
        {
            if (!string.IsNullOrWhiteSpace(roadUID))
            {
                var road = await FindRoadInInventory(roadUID);
                if (road != null)
                {
                    return road;
                }
            }

            roadUID = await ops.AddMagicRoad(roadUID, _ctx);
            if(string.IsNullOrWhiteSpace(roadUID))
            {
                throw new ApplicationException("Magic road not imported");
            }

            var newRoad = await FindRoadInInventory(name: roadUID);
            if(newRoad != null)
            {
                return newRoad;
            }

            throw new ApplicationException("Road was added to inventory, but could not be found");
        }
    }
}
