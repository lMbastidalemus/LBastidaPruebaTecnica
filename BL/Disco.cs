using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaEntities context = new DL.LBastidaPruebaTecnicaEntities())
                {
                    var query = context.AddDisco( disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Anio, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaEntities context = new DL.LBastidaPruebaTecnicaEntities())
                {
                    var query = context.GetAll().ToList();
                    result.Objetcs = new List<object>();
                    if(query != null)
                    {
                        ML.Disco disco = new ML.Disco();
                        foreach(var registro in query)
                        {
                            disco.IdDisco = registro.IdDisco;
                            disco.Titulo = registro.Titulo;
                            disco.Artista = registro.Artista;
                            disco.GeneroMusical = registro.GeneroMusical;
                            disco.Duracion = TimeSpan.Parse(registro.Duracion.ToString());
                            disco.Anio = int.Parse(registro.Anio.ToString());
                            disco.Distribuidora = registro.Distribuidora;
                            disco.Ventas = int.Parse(registro.Ventas.ToString());
                            disco.Disponibilidad = int.Parse(registro.Disponibilidad.ToString());
                            result.Objetcs.Add(disco);
                        }
                        result.Correct = true;

                        
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaEntities context = new DL.LBastidaPruebaTecnicaEntities())
                {
                    var query = context.DeleteDisco(IdDisco);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaEntities context = new DL.LBastidaPruebaTecnicaEntities())
                {
                    var query = context.UpdateDisco(disco.IdDisco, disco.Titulo, disco.Artista, disco.GeneroMusical, disco.Duracion, disco.Anio, disco.Distribuidora, disco.Ventas, disco.Disponibilidad);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


    }
}
