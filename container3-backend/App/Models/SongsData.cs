using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;


namespace openComputingLab.Models;

//[Table("SongsData")]
[Keyless]
public class SongsData {
    [Required]
    [Column("song name")]
    public string ? song_name {
        get;
        set;
    }
    [Required]
    [Column("band name")]
    public string ? band_name {
        get;
        set;
    }
    [Required]
    [Column("band members")]

    public List<string> ? band_members {
        get;
        set;
    }
    [Required]
    [Column("genre")]
    public string ? genre {
        get;
        set;
    }
    [Required]
    [Column("album name")]
    public string ? album_name {
        get;
        set;
    }
    [Required]
    [Column("album label")]
    public string ? album_label {
        get;
        set;
    }
    [Required]
    [Column("album release date")]
    public DateOnly ? date_released {
        get;
        set;
    }
    [Required]
    [Column("song length")]
    public TimeSpan ? song_length {
        get;
        set;
    }
    [Required]
    [Column("position on album")]
    public int ? song_position {
        get;
        set;
    }
    [Required]
    [Column("lyrics writers")]
    public List<string> ? lyrics_writers {
        get;
        set;
    }
    [Required]
    [Column("music writers")]
    public List<string> ? music_writers {
        get;
        set;
    }
    [Required]
    [Column("lyrics")]
    public List<string> ? lyrics {
        get;
        set;
    }
}
