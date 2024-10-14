using Microsoft.AspNetCore.Mvc;

// importo las librerias para gestionar la base de datos
using System.Data;
using System.Data.SqlClient;
// importo los modelos
using apiMegaQuiz.Models;
// AGREGAR CORDS

namespace apiMegaQuiz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class preguntasController : Controller
    {
        // obtener la cadena de conexion la base de datos
        private readonly string cadenaSQL;
        // contructo, obtiene la cadena de conexion 
        public preguntasController(IConfiguration config)
        {
            cadenaSQL = config.GetConnectionString("CadenaSQL");
        }

        [HttpGet]
        [Route("ListaPreguntas")]
        public IActionResult ListaPreguntas()
        {
            List<preguntas> lista = new List<preguntas>();

            try
            {
                // me conecto a la base de datos
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    // abro la conexion
                    conexion.Open();
                    // asigno el procedimiento almacenado
                    var cmd = new SqlCommand("sp_mostrarTodasPreguntas", conexion);
                    // defino el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // con los datos que devuelve el procedimieto almacenado
                    using (var rd = cmd.ExecuteReader())
                    {
                        // leo los datos
                        while(rd.Read())
                        {
                            // cada dato lo asigno a un nuevo elemento en la lista de preguntas
                            lista.Add(new preguntas
                            {
                                idPregunta = Convert.ToInt32(rd["idPregunta"]),
                                pregunta = rd["pregunta"].ToString(),
                                estado = Convert.ToInt32(rd["estado"]),
                            });

                        }
                    }
                }
                // retono los datos
                //return StatusCode(StatusCodes.Status200OK, new { mesnaje = "Lista de pregunta devuelta :)", Response = lista });
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesnaje = "ERROR :(", Response = ex.Message });
            }
        }

        // ESTE PROCEDIMETO ALMACENADO DEBE RETORNAR LA LISTA FILTRABA, Y NO FILTRARLA AQUI, SEGUN YO XD
        [HttpGet]
        [Route("ListaPreguntasEspecificas/{estado:int}")]
        public IActionResult ListaPreguntasEspecificas(int estado)
        {
            List<preguntas> lista = new List<preguntas>();

            try
            {
                // me conecto a la base de datos
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    // abro la conexion
                    conexion.Open();
                    // asigno el procedimiento almacenado
                    var cmd = new SqlCommand("sp_mostrarTodasPreguntas", conexion);
                    // defino el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // con los datos que devuelve el procedimieto almacenado
                    using (var rd = cmd.ExecuteReader())
                    {
                        // leo los datos
                        while (rd.Read())
                        {
                            // valido que la pregunta sea del valor seleccionado
                            if (Convert.ToInt32(rd["estado"]) == estado){
                                // cada dato lo asigno a un nuevo elemento en la lista de preguntas
                                lista.Add(new preguntas
                                {
                                    idPregunta = Convert.ToInt32(rd["idPregunta"]),
                                    pregunta = rd["pregunta"].ToString(),
                                    estado = Convert.ToInt32(rd["estado"]),
                                });
                            }
                        }
                    }
                }
                // retono los datos
                //return StatusCode(StatusCodes.Status200OK, new { mesnaje = "Lista de pregunta especifica devuelta :)", Response = lista });
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesnaje = "ERROR :(", Response = ex.Message });
            }
        }

        [HttpGet]
        [Route("ObtenerPregunta/{idPregunta:int}")]
        public IActionResult ObtenerPregunta(int idPregunta)
        {
            preguntas oPreguntas = new preguntas();

            try
            {
                // me conecto a la base de datos
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    // abro la conexion
                    conexion.Open();
                    // asigno el procedimiento almacenado
                    var cmd = new SqlCommand("sp_mostrarUnaPregunta", conexion);
                    // le paso el id de la pregunta que quiero
                    cmd.Parameters.AddWithValue("@idPregunta",idPregunta);  
                    // defino el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // con los datos que devuelve el procedimieto almacenado
                    using (var rd = cmd.ExecuteReader())
                    {
                        // leo los datos
                        while (rd.Read())
                        {
                            // cada dato lo ingreso al objeto pregunta
                            oPreguntas.pregunta = rd["pregunta"].ToString();
                            oPreguntas.rCorrecta= rd["rCorrecta"].ToString();
                            oPreguntas.rIncorrecta1 = rd["rIncorrecta1"].ToString();
                            oPreguntas.rIncorrecta2 = rd["rIncorrecta2"].ToString();
                            oPreguntas.rIncorrecta3 = rd["rIncorrecta3"].ToString();
                            oPreguntas.rIncorrecta4 = rd["rIncorrecta4"].ToString();
                            oPreguntas.rIncorrecta5 = rd["rIncorrecta5"].ToString();                  
                        }
                    }
                }
                // retono los datos
                //return StatusCode(StatusCodes.Status200OK, new { mesnaje = "Pregunta devuelta :)", Response = oPreguntas });
                return StatusCode(StatusCodes.Status200OK, oPreguntas );
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesnaje = "ERROR :(", Response = ex.Message });
            }
        }

        [HttpGet]
        [Route("ObtenerPreguntaAleatorea")]
        public IActionResult ObtenerPreguntaAleatorea()
        {
            preguntas oPreguntas = new preguntas();

            try
            {
                // me conecto a la base de datos
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    // abro la conexion
                    conexion.Open();
                    // asigno el procedimiento almacenado
                    var cmd = new SqlCommand("sp_mostrarUnaPreguntaAleatorea", conexion);
                    // defino el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // con los datos que devuelve el procedimieto almacenado
                    using (var rd = cmd.ExecuteReader())
                    {
                        // leo los datos
                        while (rd.Read())
                        {
                            // cada dato lo ingreso al objeto pregunta
                            oPreguntas.pregunta = rd["pregunta"].ToString();
                            oPreguntas.rCorrecta = rd["rCorrecta"].ToString();
                            oPreguntas.rIncorrecta1 = rd["rIncorrecta1"].ToString();
                            oPreguntas.rIncorrecta2 = rd["rIncorrecta2"].ToString();
                            oPreguntas.rIncorrecta3 = rd["rIncorrecta3"].ToString();
                            oPreguntas.rIncorrecta4 = rd["rIncorrecta4"].ToString();
                            oPreguntas.rIncorrecta5 = rd["rIncorrecta5"].ToString();
                        }
                    }
                }
                // retono los datos
                //return StatusCode(StatusCodes.Status200OK, new { mesnaje = "Pregunta devuelta :)", Response = oPreguntas });
                return StatusCode(StatusCodes.Status200OK, oPreguntas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesnaje = "ERROR :(", Response = ex.Message });
            }
        }

        [HttpGet]
        [Route("ObtenerListaPreguntasAleatoreas")]
        public IActionResult ObtenerListaPreguntasAleatoreas()
        {
            List<preguntas> lPregunta= new List<preguntas>();

            try
            {
                // me conecto a la base de datos
                using (var conexion = new SqlConnection(cadenaSQL))
                {
                    // abro la conexion
                    conexion.Open();
                    // asigno el procedimiento almacenado
                    var cmd = new SqlCommand("sp_mostrarListaIdpreguntasAleatoreas", conexion);
                    // defino el tipo de comando
                    cmd.CommandType = CommandType.StoredProcedure;
                    // con los datos que devuelve el procedimieto almacenado
                    using (var rd = cmd.ExecuteReader())
                    {
                        // leo los datos
                        while (rd.Read())
                        {
                            // cada dato lo asigno a un nuevo elemento en la lista de preguntas
                            lPregunta.Add(new preguntas
                            {
                                idPregunta = Convert.ToInt32(rd["idPregunta"]),
                            });
                        }
                    }
                }
                // retono los datos
                //return StatusCode(StatusCodes.Status200OK, new { mesnaje = "Pregunta devuelta :)", Response = oPreguntas });
                return StatusCode(StatusCodes.Status200OK, lPregunta);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mesnaje = "ERROR :(", Response = ex.Message });
            }
        }
    }
}
