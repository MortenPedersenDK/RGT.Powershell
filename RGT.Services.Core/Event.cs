using RGT.Services.Core.DTO;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RGT.Services.Core
{
    public class Event
    {
        private Context _ctx;
        private Operations ops;

        public Event(Context ctx)
        {
            _ctx = ctx;
            ops = new Operations(_ctx);
        }

        public async Task<EventInformation> Create(DateTime start, string eventName, string eventDescription, string roadUID, int laps = 1, Scenes scene = Scenes.Classic, Branding branding = null, bool isPrivate = true, int numBots = 0, int botsMinPwr = 70, int botsMaxPwr = 310, RaceType raceType = RaceType.Race, BotsType botsType = BotsType.Real, BotsMode botsMode = BotsMode.Beginner, bool rubberband = false, bool drafting = true, bool massstart = true, int releasegap = 1, int ridersPerRelease = 1)
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

            Road road;
            if(!int.TryParse(roadUID, out int road_id))
            {
                road = await GetRoad(roadUID);
                road_id = road.Id;
            }
            else
            {
                var roads = await ops.GetRealRoadsAsync();
                road = roads.Where(x => x.Id == road_id).FirstOrDefault();
                if(road == null)
                {
                    throw new ArgumentException("Road not found");
                }
            }

            string sceneStr = GetSceneString(scene);

            string raceTypeStr = GetRaceType(raceType);
            string botsTypeStr = GetBotsType(botsType);
            string botsModeStr = GetBotsMode(botsMode);

            var eventId = await ops.CreateRaceAsync(_ctx, start, road_id.ToString(), eventName, eventDescription, laps, sceneStr, branding, isPrivate, raceTypeStr, numBots, botsMinPwr, botsMaxPwr, botsTypeStr, botsModeStr, rubberband, drafting, massstart, releasegap, ridersPerRelease);

            return new EventInformation
            {
                EventId = eventId,
                SignupLink = "https://user.rgtcycling.com/event?code=" + eventId,
                TotalDistance = road.Length * laps,
                TotalElevation = road.Elevation * laps,
                Laps = laps,
                Title = eventName
            };
        }

        private string GetRaceType(RaceType raceType)
        {
            switch(raceType)
            {
                case RaceType.Groupride:
                    return "1";
                default:
                    return "0";
            }
        }

        private string GetBotsType(BotsType botsType)
        {
            switch (botsType)
            {
                case BotsType.Pacing:
                    return "0";
                default:
                    return "1";
            }
        }

        private string GetBotsMode(BotsMode botsMode)
        {
            switch(botsMode)
            {
                case BotsMode.Distributed:
                    return "0";
                case BotsMode.Intermediate:
                    return "4";
                case BotsMode.Expert:
                    return "5";
                case BotsMode.Custom:
                    return "6";
                default:
                    return "3";
            }
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

        public async Task<Road> FindRoadInInventory(string name)
        {
            var ops = new Operations(_ctx);
            var roads = await ops.GetMagicRoadsAsync();
            var road = roads.FirstOrDefault(x => x.Name.Equals(name) ||x.Label.StartsWith(name));
            return road;
        }

        public async Task<string> FindMagicRoad(string name)
        {
            var roads = await ops.SearchMagicRoadsByNameAsync(_ctx, name);
            var road = roads.FirstOrDefault(x => x.Label.StartsWith(name));
            if (road != null)
            {
                return road.Name;
            }
            return null;

        }

        public async Task<string> ImportMagicRoad(string roadUID)
        {
            var id = await ops.AddMagicRoadAsync(roadUID);
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

            roadUID = await ops.AddMagicRoadAsync(roadUID);
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
