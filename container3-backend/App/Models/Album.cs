using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace openComputingLab.Models;

[Table("Album")]
[JsonObject("album")]
public class Album {
   // [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Required]
    public int ident {
        get;
        set;
    }

  //  [JsonIgnore]
    [Required]
    [Column("band_ident")]

    public int ? Bandident {
        get;
        set;
    }

    //reference navigation to Band
    [JsonProperty("band")]
    public Band ? Band {
        get;
        set;
    }
    [JsonProperty("album name")]
    public string ? name {
        get;
        set;
    }
    [JsonProperty("album label")]
    public string ? label {
        get;
        set;
    }
    [JsonProperty("album release date")]
    public DateOnly date_released {
        get;
        set;
    }
}