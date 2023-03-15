using Newtonsoft.Json;
using RGT.Services.Core.Data;
using RGT.Services.Core.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RGT.Services.Core.API
{
    public class RGTAPI
    {
        public Uri APIEndpoint { get; set; } = new Uri("https://api.rgtcycling.com");

        public async Task<EventInformationResponse> GetEventInformationAsync(Context ctx, string eventId)
        {
            var client = GetHttpClient(ctx);
            var response = JsonConvert.DeserializeObject<EventInformationResponse>(await client.GetStringAsync($"/v1/race/{eventId}"));
            if (response != null && response.status == 200 && response.data != null)
            {
                return response;
            }
            return null;
        }

        public async Task<RadioUsersResponse> GetRadioUsersAsync(Context ctx, int raceId)
        {
            var client = GetHttpClient(ctx);
            var response = JsonConvert.DeserializeObject<RadioUsersResponse>(await client.GetStringAsync($"/v1/race/radio-users?race_id={raceId}"));
            if (response != null && response.status == 200 && response.data != null)
            {
                return response;
            }
            return null;
        }

        public async Task<bool> AddRadioUserAsync(Context ctx, int raceId, string userEmail)
        {
            var client = GetHttpClient(ctx);
            var json = JsonConvert.SerializeObject(new AddRadioUserRequest { email= userEmail, race_id = raceId });
            var payload = new StringContent(json);
            var result = await client.PostAsync($"/v1/race/radio-users", payload);
            var response = JsonConvert.DeserializeObject<AddRadioUserResponse>(await result.Content.ReadAsStringAsync());
            if (response != null && response.status == 200 && response.data != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteRadioUser(Context ctx, int raceId, int userId)
        {
            var client = GetHttpClient(ctx);
            var result = await client.DeleteAsync($"/v1/race/radio-users?race_id={raceId}&user_id={userId}");
            var response = JsonConvert.DeserializeObject<DeleteRadioUserResponse>(await result.Content.ReadAsStringAsync());
            if (response != null && response.status == 200 && response.data != null)
            {
                return true;
            }
            return false;
        }


        public async Task<string> CreateEventWithBranding(Context ctx, EventCreationInformation creationInformation)
        {
            var client = GetHttpClient(ctx);

            using (var request = new HttpRequestMessage(HttpMethod.Post, "/v1/race"))
            {
                using (var content = new MultipartFormDataContent())
                {
                    if (creationInformation.Name != null) content.Add(new StringContent(creationInformation.Name), "name");
                    if (creationInformation.Description != null) content.Add(new StringContent(creationInformation.Description), "description");
                    if (creationInformation.StartDate != null) content.Add(new StringContent(creationInformation.StartDate), "start_date");
                    if (creationInformation.StartTime != null) content.Add(new StringContent(creationInformation.StartTime), "start_time");
                    if (creationInformation.StartAt != null) content.Add(new StringContent(creationInformation.StartAt), "start_at");
                    if (creationInformation.RoadId != null) content.Add(new StringContent(creationInformation.RoadId), "road_id");
                    if (creationInformation.Laps != null) content.Add(new StringContent(creationInformation.Laps), "laps");
                    if (creationInformation.Timezone != null) content.Add(new StringContent(creationInformation.Timezone), "timezone");
                    if (creationInformation.Type != null) content.Add(new StringContent(creationInformation.Type), "type");
                    if (creationInformation.BotsType != null) content.Add(new StringContent(creationInformation.BotsType), "bots_type");
                    if (creationInformation.BotsReal != null) content.Add(new StringContent(creationInformation.BotsReal), "bots_real");
                    if (creationInformation.BotsMode != null) content.Add(new StringContent(creationInformation.BotsMode), "bots_mode");
                    if (creationInformation.BotsNum != null) content.Add(new StringContent(creationInformation.BotsNum), "bots_num");
                    if (creationInformation.BotsMinPwr != null) content.Add(new StringContent(creationInformation.BotsMinPwr), "bots_min_pwr");
                    if (creationInformation.BotsMaxPwr != null) content.Add(new StringContent(creationInformation.BotsMaxPwr), "bots_max_pwr");
                    if (creationInformation.Private != null) content.Add(new StringContent(creationInformation.Private), "private");
                    if (creationInformation.RubberBand != null) content.Add(new StringContent(creationInformation.RubberBand), "rubber_band");
                    if (creationInformation.GenScene != null) content.Add(new StringContent(creationInformation.GenScene), "gen_scene");
                    if (creationInformation.ParamsPreset != null) content.Add(new StringContent(creationInformation.ParamsPreset), "params_preset");
                    if (creationInformation.Params != null) content.Add(new StringContent(creationInformation.Params), "params");
                    if (creationInformation.WorkoutName != null) content.Add(new StringContent(creationInformation.WorkoutName), "workout_name");

                    if (creationInformation.EventThumbnail != null) AddFileToForm(content, creationInformation.EventThumbnail, "thumbnail");
                    if (creationInformation.Billboard01 != null) AddFileToForm(content, creationInformation.Billboard01, "billboard01");
                    if (creationInformation.Billboard02 != null) AddFileToForm(content, creationInformation.Billboard02, "billboard02");
                    if (creationInformation.Billboard03 != null) AddFileToForm(content, creationInformation.Billboard03, "billboard03");
                    if (creationInformation.Fence01 != null) AddFileToForm(content, creationInformation.Fence01, "fence01");
                    if (creationInformation.Fence02 != null) AddFileToForm(content, creationInformation.Fence02, "fence02");
                    if (creationInformation.Fence03 != null) AddFileToForm(content, creationInformation.Fence03, "fence03");
                    if (creationInformation.Fence04 != null) AddFileToForm(content, creationInformation.Fence04, "fence04");
                    if (creationInformation.Fence05 != null) AddFileToForm(content, creationInformation.Fence05, "fence05");
                    if (creationInformation.Fence06 != null) AddFileToForm(content, creationInformation.Fence06, "fence06");
                    if (creationInformation.Flag01 != null) AddFileToForm(content, creationInformation.Flag01, "flag01");
                    if (creationInformation.Flag02 != null) AddFileToForm(content, creationInformation.Flag02, "flag02");
                    if (creationInformation.Flag03 != null) AddFileToForm(content, creationInformation.Flag03, "flag03");
                    if (creationInformation.GateMainTop != null) AddFileToForm(content, creationInformation.GateMainTop, "gatemaintop");
                    if (creationInformation.GateMainSide != null) AddFileToForm(content, creationInformation.GateMainSide, "gatemainside");
                    if (creationInformation.Decal01 != null) AddFileToForm(content, creationInformation.Decal01, "decal01");
                    if (creationInformation.Decal02 != null) AddFileToForm(content, creationInformation.Decal02, "decal02");
                    if (creationInformation.SignDistance != null) AddFileToForm(content, creationInformation.SignDistance, "signdistance");
                    if (creationInformation.TentBasicTop != null) AddFileToForm(content, creationInformation.TentBasicTop, "tentbasictop");
                    if (creationInformation.TentBasicWall != null) AddFileToForm(content, creationInformation.TentBasicWall, "tentbasicwall");
                    if (creationInformation.TentTechTop != null) AddFileToForm(content, creationInformation.TentTechTop, "tenttechtop");
                    if (creationInformation.TentTechWall != null) AddFileToForm(content, creationInformation.TentTechWall, "tenttechwall");
                    if (creationInformation.GateSegmentTop != null) AddFileToForm(content, creationInformation.GateSegmentTop, "gatesegmenttop");
                    if (creationInformation.GateSegmentSide != null) AddFileToForm(content, creationInformation.GateSegmentSide, "gatesegmentside");

                    request.Content = content;

                    var response = await client.SendAsync(request);

                    var stream = await response.Content.ReadAsStreamAsync();
                    using (var sr = new StreamReader(stream))
                    {
                        var str = sr.ReadToEnd();

                        var creationResponse = JsonConvert.DeserializeObject<EventWithBrandingCreationResponse>(str);
                        if (creationResponse != null && creationResponse.status >= 200 && creationResponse.status < 300)
                        {
                            return creationResponse.data.code;
                        }

                        throw new ApplicationException(str);
                    }
                }
            }
        }
        public async Task<string> AttachMagicRoadAsync(Context ctx, string id)
        {
            var client = GetHttpClient(ctx);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("code", id)
            });
            var httpresponse = await client.PostAsync($"/v1/road/magic/attach?code={id}", content);
            var json = await httpresponse.Content.ReadAsStringAsync();
            var roadMagicAttach = JsonConvert.DeserializeObject<RoadMagicAttach>(json);
            if (roadMagicAttach != null && roadMagicAttach.status == 200 && roadMagicAttach.data != null)
            {
                System.Diagnostics.Trace.WriteLine("Imported road id: " + roadMagicAttach.data);
                System.Console.WriteLine("Imported road id: " + roadMagicAttach.data);

                return roadMagicAttach.data;
            }
            return null;
        }

        public async Task<List<RoadsRealResponse.Road>> GetRealRoads(Context ctx, int limit = 1000)
        {
            var client = GetHttpClient(ctx);
            var response = JsonConvert.DeserializeObject<RoadsRealResponse>(await client.GetStringAsync($"/v1/roads/real?limit={limit}&order=name&direction=asc"));
            if (response != null && response.status == 200 && response.data != null)
            {
                return response.data.ToList();
            }
            return null;
        }
        public async Task<IList<RoadsMagicResponse.Road>> GetMagicRoadsAsync(Context ctx, int limit = 1000)
        {
            var client = GetHttpClient(ctx);
            var response = JsonConvert.DeserializeObject<RoadsMagicResponse>(await client.GetStringAsync($"/v1/roads/magic?limit={limit}&order=name&direction=asc"));
            if (response != null && response.status == 200 && response.data != null)
            {
                return response.data.ToList();
            }
            return null;
        }
        public async Task<IList<RoadsMagicResponse.Road>> SearchMagicRoadsByName(Context ctx, string namePartial, int limit = 5, int offset = 0)
        {
            var nameUrlEncoded = WebUtility.UrlEncode(namePartial);

            var client = GetHttpClient(ctx);

            var responseStr = await client.GetStringAsync($"/v1/roads/magic?limit={limit}&offset={offset}&name={nameUrlEncoded}");
            var response = JsonConvert.DeserializeObject<RoadsMagicResponse>(responseStr);

            if (response != null && response.status == 200 && response.data != null)
            {
                return response.data.ToList();
            }
            return null;
        }

        public async Task<Data.RaceWebsite.Data> GetRaceWebsiteResult(Context ctx, string eventId)
        {
            var client = GetHttpClient(ctx);

            var responseStr = await client.GetStringAsync($"/v1/race/website/{eventId}");
            var response = JsonConvert.DeserializeObject<Data.RaceWebsite.RaceWebsiteResponse>(responseStr);

            if (response != null && response.status == 200 && response.data != null)
            {
                return response.data;
            }
            return null;
        }

        public async Task<Context> Login(string username, string password)
        {
            var client = GetHttpClient();
            var payload = new StringContent(JsonConvert.SerializeObject(new LoginRequest() { email = username, password = password }), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/v1/auth/login", payload);

            var response = JsonConvert.DeserializeObject<LoginResponse>(await result.Content.ReadAsStringAsync());

            if (response != null && response.status == 200 && response.data != null)
            {
                return new Context { UUID = response.data.uuid, Token = response.data.token };
            }
            return null;
        }

        private HttpClient GetHttpClient(Context context = null)
        {
            var client = new HttpClient() { BaseAddress = APIEndpoint };
            client.DefaultRequestHeaders.Add("UserAgent", "eCDK");
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            if (context != null)
            {
                client.DefaultRequestHeaders.Add("token", context.Token);
                client.DefaultRequestHeaders.Add("uuid", context.UUID);
            }
            return client;
        }

        private void AddFileToForm(MultipartFormDataContent content, byte[] barr, string name)
        {
            content.Add(new StreamContent(new MemoryStream(barr)), $"assets[{name}]", $"{name}.png");
        }

    }
}
