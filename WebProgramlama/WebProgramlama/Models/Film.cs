//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebProgramlama.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Film
    {
        public Film()
        {
            this.FilmTur = new HashSet<FilmTur>();
            this.Galeri = new HashSet<Galeri>();
            this.OyuncuFilm = new HashSet<OyuncuFilm>();
        }
    
        public int FilmID { get; set; }
        public string Ad { get; set; }
        public Nullable<System.DateTime> CikisTarihi { get; set; }
        public string Slogan { get; set; }
        public string Sure { get; set; }
        public string Butce { get; set; }
        public string Konusu { get; set; }
        public byte[] Fotograf { get; set; }
        public string Facebook { get; set; }
        public string Yas { get; set; }
    
        public virtual ICollection<FilmTur> FilmTur { get; set; }
        public virtual ICollection<Galeri> Galeri { get; set; }
        public virtual ICollection<OyuncuFilm> OyuncuFilm { get; set; }
    }
}
