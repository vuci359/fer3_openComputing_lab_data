using Newtonsoft.Json;

namespace openComputingLab.Models;

[JsonObject("@context")]
//[Authorize]
public class AlbumContext {
    [JsonProperty("album release date")]
    public string release_date{get; set;} = "https://schema.org/datePublished";
    [JsonProperty("name")]
    public string album_name{get; set;} = "https://schema.org/name";
    [JsonProperty("label")]
    public string album_label{get; set;} = "https://schema.org/publisher";
}
