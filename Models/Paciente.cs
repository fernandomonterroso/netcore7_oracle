namespace ApiNetCore7.Models
{
    public class Paciente
    {
        public int ID_PACIENTE { get; set; }
        public string NOMBRE { get; set; }
        public int EDAD { get; set; }
        public string GENERO { get; set; }
        public DateTime FEC_ING { get; set; }
    }
}
