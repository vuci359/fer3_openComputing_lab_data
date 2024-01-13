namespace openComputingLab.DTO;

public class SongDTO {

    public int ? Albumident {
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