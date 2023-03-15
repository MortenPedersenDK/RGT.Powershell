using RGT.Services.Core.API;
using RGT.Services.Core.Data;
using RGT.Services.Core.DTO;

using System.Linq;

namespace RGT.Services.Core
{
    public class Operations
    {
        RGTAPI api = new RGTAPI();

        public Operations()
        {
        }

        public async Task<Context> GetContext(string username, string password)
        {
            return await api.Login(username, password);
        }

        public async Task<IList<MagicRoad>> GetMagicRoads(Context ctx)
        {
            var roads = await api.GetMagicRoadsAsync(ctx);
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

        public async Task<IList<MagicRoad>> SearchMagicRoadsByName(Context ctx, string namePartial, int limit = 5, int offset = 0)
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


        public async Task<string> AddMagicRoad(string roadId, Context ctx)
        {
            return await api.AttachMagicRoadAsync(ctx, roadId);
        }

        public async Task<string> CreateRace(Context ctx, DateTime start, string roadId, string name, string description, int laps = 1, string scene = "gen01", Branding? branding = null, bool isPrivate = true)
        {
            var eci = new EventCreationInformation();
            eci.StartAt = start.ToString("yyyy-MM-dd HH:mm:ss");
            eci.StartDate = start.ToString("yyyy-MM-dd");
            eci.StartTime = start.ToString("HH:mm");
            eci.RoadId = roadId;
            eci.Name = name;
            eci.Description = description;
            eci.Private = isPrivate ? "1" : "0";
            eci.GenScene = scene;
            eci.Laps = laps.ToString();

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
            }

            return await api.CreateEventWithBranding(ctx, eci);
        }

        private byte[] GetFileBytes(string path)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                return null;
            }
            return File.ReadAllBytes(path);
        }
    }
}
