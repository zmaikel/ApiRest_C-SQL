using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos.Entidades;
using System.Web;
using static CapaDatos.Entidades.RespuestaDTO;
using System.IO;
using System.Net.Http;
using System.Net;

namespace CapaDatos
{
    public class GestorDB : IGestorDB
    {
        RespuestaDTO objRespuesta;

        public RespuestaDTO ObtenerTopPersonasPorSalarioYProvincia(int Provincia )
        {
            objRespuesta = new RespuestaDTO();
            try
            {
                using (ProyectoBDModel contextoBD = new ProyectoBDModel())
                {
                    SqlParameter pProvincia = new SqlParameter("@Provincia", Provincia);
                    List<T_Persona> ListPer = contextoBD.Database.SqlQuery<T_Persona>("SP_SelectPersonaporSalario @Provincia", pProvincia).ToList();
                    objRespuesta.Respuesta = ListPer;
                    objRespuesta.TipoRp = TiposRespuesta.Exitoso;
                    objRespuesta.MsgRespuesta = "[ObtenerTopPersonasPorSalarioYProvincia]->Exitoso";
                }
            }
            catch (Exception ex)
            {
                objRespuesta.TipoRp = TiposRespuesta.Fallido;
                objRespuesta.MsgRespuesta = "[ObtenerTopPersonasPorSalarioYProvincia]->Fallido" + ex.Message;
                objRespuesta.Respuesta = null;
            }

            return objRespuesta;


        }
        public RespuestaDTO ObtenerNumeroAleatorio()
        {
            Random numero = new Random();
            int v =numero.Next(1,4);

            objRespuesta = new RespuestaDTO();
            try
            {
                    objRespuesta.Respuesta = v;
                    objRespuesta.TipoRp = TiposRespuesta.Exitoso;
                    objRespuesta.MsgRespuesta = "[ObtenerNumeroAleatorio]->Exitoso";
                
            }
            catch (Exception ex)
            {
                objRespuesta.TipoRp = TiposRespuesta.Fallido;
                objRespuesta.MsgRespuesta = "[ObtenerNumeroAleatorio]->Fallido" + ex.Message;
                objRespuesta.Respuesta = null;
            }

            return objRespuesta;
        }
        public RespuestaDTO CantPersonasporGeneroYEdad(int Genero,int Edad)
        {
            objRespuesta = new RespuestaDTO();
            try
            {
                using (ProyectoBDModel contextoBD = new ProyectoBDModel())
                {
                    SqlParameter pGenero = new SqlParameter("@Edad", Edad);
                    SqlParameter pEdad = new SqlParameter("@Genero", Genero);

                    object[] ParametrosSp = new object[] { pGenero, pEdad };
                    //List<T_Persona> ListPer;
                    //using (ProyectoBDModel oDB = new ProyectoBDModel())
                    //{
                    //    ListPer = oDB.T_Persona.Where(x => (x.TPE_EDAD == Edad && x.TPE_TGE_ID == Genero)).ToList();

                    //}

                    List<T_Persona> ListPer = contextoBD.Database.SqlQuery<T_Persona>("SP_CantidadPersonaPorGeneroYEdad @Genero, @Edad ",ParametrosSp ).ToList();
                    objRespuesta.Respuesta = ListPer.Count;
                    objRespuesta.TipoRp = TiposRespuesta.Exitoso;
                    objRespuesta.MsgRespuesta = "[CantPersonasporGeneroYEdad]->Exitoso";
                }
            }
            catch (Exception ex)
            {
                objRespuesta.TipoRp = TiposRespuesta.Fallido;
                objRespuesta.MsgRespuesta = "[CantPersonasporGeneroYEdad]->Fallido" + ex.Message;
                objRespuesta.Respuesta = null;
            }

            return objRespuesta;


        }

        
    }
}

