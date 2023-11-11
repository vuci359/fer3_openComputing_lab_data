using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace openComputingLab.Models;

//[Table("Band")]
public class SongsData {
    [Key, Required]
    [Column("ident")]
    public int ident {
        get;
        set;
    }
    [Required]
    [Column("ident")]

    public string ? band_name {
        get;
        set;
    }
    public string ? genre {
        get;
        set;
    }
    public int ? year_founded {
        get;
        set;
    }
    [Required]
    public List<string> ? members {
        get;
        set;
    }
}