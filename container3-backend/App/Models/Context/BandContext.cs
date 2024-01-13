using Newtonsoft.Json;

namespace openComputingLab.Models;

[JsonObject("@context")]
//[Authorize]
public class BandContext {
    [JsonProperty("genre")]
    public string band_ganre{get; set;} = "https://schema.org/genre";
    [JsonProperty("band name")]
    public string band_name{get; set;} = "https://schema.org/name";
}
