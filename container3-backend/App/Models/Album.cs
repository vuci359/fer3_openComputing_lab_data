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
    [Column("band_ident")]

    public int ? Bandident {
        get;
        set;
    }

    //reference navigation to Band
    [Column("band_ident")]
        public Band ? Band {
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