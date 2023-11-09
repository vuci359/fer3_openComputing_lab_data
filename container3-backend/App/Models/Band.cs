using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace openComputingLab.Models;

[Table("Band")]
public class Band {
    [Key, Required]
    public int ident {
        get;
        set;
    }
    [Required]
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