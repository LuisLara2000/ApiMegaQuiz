using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace apiMegaQuiz.Models
{
    public class preguntas
    {
        public int idPregunta {  get; set; }
        public string pregunta { get; set; }
        public string rCorrecta { get; set; }
        public string rIncorrecta1 { get; set; }
        public string rIncorrecta2 { get; set; }
        public string rIncorrecta3 { get; set; }
        public string rIncorrecta4 { get; set; }
        public string rIncorrecta5 { get; set; }
        public string rIncorrecta6 { get; set; }
        public int estado { get; set; }
        public int dificultad {  get; set; }


    }
}
