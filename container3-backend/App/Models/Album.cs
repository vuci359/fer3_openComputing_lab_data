using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using openComputingLab.DTO;
namespace openComputingLab.Models;

[Table("Album")]
[JsonObject("album")]
[Authorize]
public class Album {

    public Album(){}
    public Album(AlbumDTO dto){
        Bandident = dto.Bandident;
        name = dto.name;
        label = dto.label;
        date_released = dto.date_released;
    }

    [JsonObject("@context")]
    public class Context{
        [JsonProperty("album release date")]
        public string release_date{get; set;} = "https://schema.org/datePublished";
        [JsonProperty("name")]
        public string album_name{get; set;} = "https://schema.org/name";
        [JsonProperty("label")]
        public string album_label{get; set;} = "https://schema.org/publisher";
    }

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