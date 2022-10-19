namespace sistemaDual.Models
{
    public class Estatus
    {
        public int EstatusID { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<AlumnoDual> AlumnosDuales { get; set; }

    }
   
}
