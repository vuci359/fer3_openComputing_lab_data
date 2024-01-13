using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using openComputingLab.DTO;
namespace openComputingLab.Models;

[Table("Band")]
[JsonObject("band")]
//[Authorize]
public class Band {
    
    public Band(){}
    public Band(BandDTO dto){
        band_name = dto.band_name;
        genre = dto.genre;
        year_founded = dto.year_founded;
        members = dto.members;
    }
    [NotMapped]
    [JsonProperty("@context")]
    public BandContext @context{
        get;
        set;
    } = new BandContext();

   // [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
    public int ? year_founded {
        get;
        set;
    }
    [Required]
    [JsonProperty("band members")]
    [Column(TypeName = "varchar(25)[]")]

    public List<string> ? members {
        get;
        set;
    }
}