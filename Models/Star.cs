using System.ComponentModel.DataAnnotations;

namespace gwiazdy.Models
{
    public class Star
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa gwiazdy jest wymagana.")]
        [StringLength(50, ErrorMessage = "Nazwa gwiazdy nie może być dłuższa niż 50 znaków.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Nazwa gwiazdozbioru jest wymagana.")]
        [StringLength(50, ErrorMessage = "Nazwa gwiazdozbioru nie może być dłuższa niż 50 znaków.")]
        public string Constellation { get; set; }

        [Required(ErrorMessage = "Wartość wielkości gwiazdowej jest wymagana.")]
        [Range(-30, 30, ErrorMessage = "Wartość wielkości gwiazdowej musi mieścić się w zakresie od -30 do 30.")]
        public double Magnitude { get; set; }

        [Required(ErrorMessage = "Odległość gwiazdy jest wymagana.")]
        [Range(0, double.MaxValue, ErrorMessage = "Odległość gwiazdy musi być dodatnia.")]
        public double Distance { get; set; }

        [StringLength(50, ErrorMessage = "Typ widmowy gwiazdy nie może być dłuższy niż 50 znaków.")]
        public string SpectralType { get; set; }

        [Required(ErrorMessage = "Masa gwiazdy jest wymagana.")]
        [Range(0, double.MaxValue, ErrorMessage = "Masa gwiazdy musi być dodatnia.")]
        public double Mass { get; set; }

        [Required(ErrorMessage = "Promień gwiazdy jest wymagany.")]
        [Range(0, double.MaxValue, ErrorMessage = "Promień gwiazdy musi być dodatni.")]
        public double Radius { get; set; }

        [Required(ErrorMessage = "Jasność gwiazdy jest wymagana.")]
        [Range(0, double.MaxValue, ErrorMessage = "Jasność gwiazdy musi być dodatnia.")]
        public double Luminosity { get; set; }

        [StringLength(500, ErrorMessage = "Opis gwiazdy nie może być dłuższy niż 500 znaków.")]
        public string Description { get; set; }
    }


}
