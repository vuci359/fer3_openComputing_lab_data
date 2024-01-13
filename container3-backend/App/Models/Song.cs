using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;

using openComputingLab.DTO;
namespace openComputingLab.Models;

[Table("Song")]
[JsonObject("song")]
//[Authorize]
public class Song {
    public Song(){}
    public Song(SongDTO dto){
        Albumident = dto.Albumident;
        name = dto.name;
        length = dto.length;
        no_on_album = dto.no_on_album;
        lyrics_writers = dto.lyrics_writers;
        music_writers = dto.music_writers;
        lyrics = dto.lyrics;
    }
    [JsonObject("@context")]
    public class Context{
        [JsonProperty("song length")]
        public string song_length{get; set;} = "https://schema.org/duration";
        [JsonProperty("song name")]
        public string song_name{get; set;} = "https://schema.org/name";
        [JsonProperty("lyrics")]
        public string song_lyrics{get; set;} = "https://schema.org/lyrics";
    }

  //  [JsonIgnore]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key, Required]
    public int ident {
        get;
        set;
    }

   // [JsonIgnore]
    [Required]
    [Column("album_ident")]
    public int ? Albumident {
        get;
        set;
    }
//reference navigation to album
    [JsonProperty("album")]
    public Album ? Album {
        get;
        set;
    }
    [JsonProperty("song name")]
    public string ? name {
        get;
        set;
    }
    [JsonProperty("song length")]
    public TimeSpan ? length {
        get;
        set;
    }
    [JsonProperty("position on album")]
    public int no_on_album {
        get;
        set;
    }
    [JsonProperty("lyrics writers")]
    [Column(TypeName = "varchar(25)[]")]

    public List<string> ? lyrics_writers{
        get;
        set;
    }
    [JsonProperty("music writers")]
    [Column(TypeName = "varchar(25)[]")]
    public List<string> ? music_writers{
        get;
        set;
    }
    [JsonProperty("lyrics")]
    public string ? lyrics{
        get;
        set;
    }
}