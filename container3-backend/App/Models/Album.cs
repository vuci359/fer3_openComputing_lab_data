using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace openComputingLab.Models;

[Table("Album")]
public class Album {
    [Key, Required]
    public int ident {
        get;
        set;
    }
    [Required]
    public int ? band_ident {
        get;
        set;
    }
    public string ? name {
        get;
        set;
    }
    public string ? label {
        get;
        set;
    }
    public DateOnly date_released {
        get;
        set;
    }
}