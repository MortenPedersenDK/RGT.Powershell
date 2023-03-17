using RGT.Services.Core.API;
using RGT.Services.Core.Data;
using RGT.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RGT.Services.Core
{
    public class Operations
    {
        RGTAPI api = new RGTAPI();
        private Context _context;

        public Operations(Context context)
        {
            _context = context;
        }

        public async Task<Context> GetContextAsync(string username, string password)
        {
            return await api.Login(username, password);
        }

        public async Task<IList<RaceRadioUser>> GetRaceRadioUsersAsync(string eventId)
        {
            var eventInfoResponse = await api.GetEventInformationAsync(_context, eventId);
            if (eventInfoResponse == null)
            {
                return null;
            }

            var list = new List<RaceRadioUser>();
            var radioUsersResponse = await api.GetRadioUsersAsync(_context, eventInfoResponse.data.id);
            foreach (RadioUsersResponse.RadioUser user in radioUsersResponse.data)
            {
                list.Add(new RaceRadioUser
                {
                    Firstname = user.fname,
                    Lastname = user.fname,
                    Id = user.id,
                    Name = string.Join(" ", user.fname, user.lname)
                });
            }

            return list;
        }

        public async Task<bool> AddRaceRadioUserAsync(string eventId, string email)
        {
            var eventInfoResponse = await api.GetEventInformationAsync(_context, eventId);
            if (eventInfoResponse == null)
            {
                return false;
            }

            var success = await api.AddRadioUserAsync(_context, eventInfoResponse.data.id, email);
            return success;
        }

        public async Task<bool> DeleteRaceRadioUserAsync(string eventId, int userId)
        {
            var eventInfoResponse = await api.GetEventInformationAsync(_context, eventId);
            if (eventInfoResponse == null)
            {
                return false;
            }

            var success = await api.DeleteRadioUser(_context, eventInfoResponse.data.id, userId);
            return success;
        }

        public async Task<IList<RealRoad>> GetRealRoadsAsync()
        {
            var roads = await api.GetRealRoads(_context);
            return roads.Select(x => new RealRoad
            {
                Description = x.description,
                Name = x.name,
                Label = x.label,
                Id = x.id,
                Length = x.length,
                Elevation = x.elevation
            }).ToList();
        }

        public async Task<IList<MagicRoad>> GetMagicRoadsAsync()
        {
            var roads = await api.GetMagicRoadsAsync(_context);
            return roads.Select(x => new MagicRoad
            {
                Description = x.description,
                Name = x.name,
                Label = x.label,
                Id = x.id,
                Length = x.length,
                Elevation = x.elevation
            }).ToList();
        }

        public async Task<EventResult> GetEventResultAsync(string eventId)
        {
            var eventResult = new EventResult();
            var result = await api.GetRaceWebsiteResult(_context, eventId);
            if (result == null)
            {
                return eventResult;
            }

            eventResult.Name = result.name;

            eventResult.Signups = result.subscribers.Select(r => new Rider
            {
                Name = $"{r.fname} {r.lname}",
                UUID = r.uuid,
                Gender = r.gender,
                CountryISOCode = r.country.code1,
                CountryName = r.country.name
            }).ToList();

            var riderDict = eventResult.Signups.ToDictionary(k => k.UUID, k => k);

            int rank = 1;
            eventResult.Result = result.results.Select(r =>
            {
                var rider = riderDict[r.user.uuid];
                rider.Weight = r.user.weight;
                rider.Height = r.user.height;
                rider.Age = CalculateAge(result.start_at, r.user.birthday);

                return new RaceResult
                {
                    Rider = rider,
                    Rank = rank++,
                    Time = TimeSpan.Parse(r.time_min_sec),
                    Distance = r.activity.distance / (double)1000,
                    Kmh = r.activity.avg_speed * 360 / 100,
                    Mph = r.activity.avg_speed * 360 / 160.9344,
                    AvgHr = r.activity.avg_heart_rate,
                    AvgPwr = r.activity.avg_power,
                    Best20MinPwr = r.activity.best_20_min_avg_power
                };
            }).OrderBy(o => o.Rank).ToList();

            var segments = result.segments_leaderboards.GroupBy(x => new Segment { Id = x.segment.id, Name = x.segment.name }).ToDictionary(k => k.Key, k => k.ToList());

            eventResult.Segments = new List<Segment>();

            foreach(var kvp in segments)
            {
                eventResult.Segments.Add(kvp.Key);
                kvp.Key.Results = kvp.Value.Select(x => new SegmentResult 
                { 
                    Best = (x.best_time == 1), 
                    Created = DateTime.Parse(x.created_at), 
                    Rider = riderDict[x.user.uuid], Time = TimeSpan.FromSeconds(x.time / (double)1000) 
                }).ToList();
            }


            return eventResult;
        }

        public async Task<IList<MagicRoad>> SearchMagicRoadsByNameAsync(Context ctx, string namePartial, int limit = 5, int offset = 0)
        {
            var roads = await api.SearchMagicRoadsByName(ctx, namePartial, limit, offset);
            return roads.Select(x => new MagicRoad
            {
                Description = x.description,
                Name = x.name,
                Label = x.label,
                Id = x.id,
                Length = x.length
            }).ToList();
        }

        public async Task<string> AddMagicRoadAsync(string roadId)
        {
            return await api.AttachMagicRoadAsync(_context, roadId);
        }

        public async Task<string> CreateRaceAsync(Context ctx, DateTime start, string roadId, string name, string description, int laps = 1, string scene = "gen01", Branding branding = null, bool isPrivate = true, string type = "0", int numbots = 0, int botsMinPwr = 70, int botsMaxPwr = 310, string botsType = "1", string botsMode = "3", bool rubberband = false, bool drafting = true, bool massstart = true, int releasegap = 1, int ridersPerRelease = 1)
        {
            var eci = new EventCreationInformation();
            eci.StartAt = start.ToString("yyyy-MM-dd HH:mm:ss");
            eci.StartDate = start.ToString("yyyy-MM-dd");
            eci.StartTime = start.ToString("HH:mm");
            eci.Timezone = TimeZoneInfo.Local.GetUtcOffset(start).Hours.ToString();
            eci.RoadId = roadId;
            eci.Name = name;
            eci.Description = description;
            eci.Private = isPrivate ? "1" : "0";
            eci.GenScene = scene;
            eci.Laps = laps.ToString();
            eci.Type = type;
            eci.BotsNum = numbots.ToString();
            eci.BotsMinPwr = botsMinPwr.ToString();
            eci.BotsMaxPwr = botsMaxPwr.ToString();
            eci.BotsType = botsType;
            eci.BotsMode = botsMode;
            eci.RubberBand = rubberband ? "1" : "0";
            eci.Params = $"{{\"drafting\":\"{(drafting ? "true" : "false")}\",\"mass_start\":\"{(massstart ? "true" : "false")}\",\"start_gap_time\":\"{releasegap}\",\"start_wave_size\":\"{ridersPerRelease}\",\"allow_virt_power\":\"false\"}}";

            if (branding != null)
            {
                eci.EventThumbnail = GetFileBytes(branding.EventThumbnail);
                eci.Billboard01 = GetFileBytes(branding.Billboard01);
                eci.Billboard02 = GetFileBytes(branding.Billboard02);
                eci.Billboard03 = GetFileBytes(branding.Billboard03);
                eci.Fence01 = GetFileBytes(branding.Fence01);
                eci.Fence02 = GetFileBytes(branding.Fence02);
                eci.Fence03 = GetFileBytes(branding.Fence03);
                eci.Fence04 = GetFileBytes(branding.Fence04);
                eci.Fence05 = GetFileBytes(branding.Fence05);
                eci.Fence06 = GetFileBytes(branding.Fence06);
                eci.Flag01 = GetFileBytes(branding.Flag01);
                eci.Flag02 = GetFileBytes(branding.Flag02);
                eci.Flag03 = GetFileBytes(branding.Flag03);
                eci.GateMainTop = GetFileBytes(branding.GateMainTop);
                eci.GateMainSide = GetFileBytes(branding.GateMainSide);
                eci.Decal01 = GetFileBytes(branding.Decal01);
                eci.Decal02 = GetFileBytes(branding.Decal02);
                eci.SignDistance = GetFileBytes(branding.SignDistance);
                eci.TentBasicTop = GetFileBytes(branding.TentBasicTop);
                eci.TentBasicWall = GetFileBytes(branding.TentBasicWall);
                eci.TentTechTop = GetFileBytes(branding.TentTechTop);
                eci.TentTechWall = GetFileBytes(branding.TentTechWall);
                eci.GateSegmentTop = GetFileBytes(branding.GateSegmentTop);
                eci.GateSegmentSide = GetFileBytes(branding.GateSegmentSide);
            }

            return await api.CreateEventWithBranding(ctx, eci);
        }

        private byte[] GetFileBytes(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return null;
            }
            return File.ReadAllBytes(path);
        }

        private int CalculateAge(DateTime eventStart, string birthday)
        {
            if (string.IsNullOrWhiteSpace(birthday))
            {
                return 0;
            }

            if (DateTime.TryParse(birthday, out DateTime bday))
            {
                bday = bday.AddHours(12);
                var age = eventStart.Year - bday.Year;
                if (eventStart.Month < bday.Month || ((eventStart.Month == bday.Month) && (eventStart.Day < bday.Day)))
                {
                    age--;
                }
                return age;
            }
            return 0;
        }
    }
}
