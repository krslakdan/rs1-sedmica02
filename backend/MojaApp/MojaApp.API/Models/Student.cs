namespace MojaApp.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Broj_indeksa { get; set; }
        public int? OpstinaRodjenjaId { get; set; }
        public Opstina OpstinaRodjenja { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public DateTime CreatedTime { get; set; }
        public string SlikaStudenta { get; set; }

    }
}
