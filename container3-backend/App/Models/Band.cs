using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace openComputingLab.Models;

[Table("Band")]
[JsonObject("band")]
public class Band {

    [JsonIgnore]
    [Key, Required]
    public int ident {
        get;
        set;
    }
    [Required]
    [JsonProperty("band name")]
    public string ? band_name {
        get;
        set;
    }
    [JsonProperty("genre")]
    public string ? genre {
        get;
        set;
    }
    [JsonIgnore]
    public int ? year_founded {
        get;
        set;
    }
    [Required]
    [JsonProperty("band members")]
    public List<string> ? members {
        get;
        set;
    }
}