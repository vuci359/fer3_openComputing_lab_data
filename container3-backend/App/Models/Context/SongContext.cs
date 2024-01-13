using Newtonsoft.Json;

namespace openComputingLab.Models;

[JsonObject("@context")]
//[Authorize]
public class SongContext {
    [JsonProperty("song length")]
    public string song_length{get; set;} = "https://schema.org/duration";
    [JsonProperty("song name")]
    public string song_name{get; set;} = "https://schema.org/name";
    [JsonProperty("lyrics")]
    public string song_lyrics{get; set;} = "https://schema.org/lyrics";
}
