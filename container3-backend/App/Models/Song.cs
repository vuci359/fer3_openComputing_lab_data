using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace openComputingLab.Models;

[Table("Song")]
public class Song {
    [Key, Required]
    public int ident {
        get;
        set;
    }
    [Required]
    public int ? album_ident {
        get;
        set;
    }
    public string ? name {
        get;
        set;
    }
    public TimeSpan ? length {
        get;
        set;
    }
    public int no_on_album {
        get;
        set;
    }
    public List<string> ? lyrics_writers{
        get;
        set;
    }
    public List<string> ? music_writers{
        get;
        set;
    }
    public string ? lyrics{
        get;
        set;
    }
}