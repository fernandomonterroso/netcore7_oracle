using ApiNetCore7.Models;
using System.Data;
using System.Data.Common;

namespace ApiNetCore7.Helpers
{
    public class EjemploHandler
    {
        private readonly OracleDbManager _OracleDbManager;
        public EjemploHandler(OracleDbManager oracleDbManager)
        {
            _OracleDbManager = oracleDbManager;
        }

        public async Task<RespuestaHttp> getPaciente()
        {
            RespuestaHttp response = null;
            try
            {
                // Definir la consulta SQL para obtener médicos
                string query = @"SELECT * FROM medico";

                // Crear un diccionario de parámetros si es necesario
                Dictionary<string, object> parameters = new Dictionary<string, object>();

                // Ejecutar la consulta y obtener los médicos
                IEnumerable<Paciente> medicos = await _OracleDbManager.DapperExecuteQuery<Paciente>(query, parameters);
                response = new RespuestaHttp(
                    true,
                    DefResponseMessage.DEF_SUCCESS,
                    medicos
                );
            }
            catch (Exception ex)
            {
                response = new RespuestaHttp(
                    false,
                    ex.Message,
                    null
                );

            }
            return response;
        }
    }
}
