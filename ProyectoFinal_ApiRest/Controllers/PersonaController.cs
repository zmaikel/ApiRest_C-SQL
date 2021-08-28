using CapaDatos;
using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Hosting;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace ProyectoFinal_ApiRest.Controllers
{
    public class PersonaController : ApiController
    {
        IGestorDB oGestorBD;
        RespuestaDTO oRespCliente;

        [HttpPost]
        public RespuestaDTO ObtenerPersonasPorProvincia(int provincia)
        {
            oGestorBD = new GestorDB();
            oRespCliente = oGestorBD.ObtenerTopPersonasPorSalarioYProvincia(provincia);
            return oRespCliente;
        }

        [HttpPost]
        public RespuestaDTO CantPersonasporGeneroYEdad(int genero, int edad)
        {
            oGestorBD = new GestorDB();
            oRespCliente = oGestorBD.CantPersonasporGeneroYEdad(genero, edad);
            return oRespCliente;
        }

        [HttpPost]
        public RespuestaDTO ObtenerNumeroAleatorio()
        {
            oGestorBD = new GestorDB();
            oRespCliente = oGestorBD.ObtenerNumeroAleatorio();
            return oRespCliente;
        }

        [HttpPost]
        public async Task<double> ObtenerTipoCambio(string fecha)
        {
            
            double tipoCambio = 0;
            string[] Pametros = { "318", fecha, "29/12/2021", "Nombre", "N", "correoelectronico", "tokenRecibido" };

            string sSoap =
                String.Format(
                        @"<?xml version=""1.0"" encoding=""utf-8""?>
                            <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                              <soap:Body>
                                <ObtenerIndicadoresEconomicos xmlns=""http://ws.sdde.bccr.fi.cr"">
                                  <Indicador>{0}</Indicador>
                                  <FechaInicio>{1}</FechaInicio>
                                  <FechaFinal>{2}</FechaFinal>
                                  <Nombre>{3}</Nombre>
                                  <SubNiveles>{4}</SubNiveles>
                                  <CorreoElectronico>{5}</CorreoElectronico>
                                  <Token>{6}</Token>
                                </ObtenerIndicadoresEconomicos>
                              </soap:Body>
                            </soap:Envelope>
                         ", Pametros);

            var contenido = new StringContent(sSoap, Encoding.UTF8, "text/xml");
            string url = "https://gee.bccr.fi.cr/Indicadores/Suscripciones/WS/wsindicadoreseconomicos.asmx";
            using (var cliente = new HttpClient())
            {
                using (var respuesta = await cliente.PostAsync(url, contenido))
                {
                    var soapRespuesta = await respuesta.Content.ReadAsStringAsync();
                    var document = XDocument.Parse(soapRespuesta);
                    var soapValue = document?.Root?.Descendants()?.Where(p =>
                                       p.Name.LocalName.Equals("NUM_VALOR")).FirstOrDefault();
                    tipoCambio = Convert.ToDouble(soapValue.Value.Replace('.', ','));


                }
            }
            return tipoCambio;
        }

        [HttpPost]
        public HttpResponseMessage SolicitarImagen(int formato)
        {
            if (formato == 1)
            {

                string archivo = HostingEnvironment.MapPath("~/Imagenes/onepiece.jpg");
                byte[] imgData = System.IO.File.ReadAllBytes(archivo);
                MemoryStream ms = new MemoryStream(imgData);
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StreamContent(ms);
                response.Content.Headers.ContentType =
                    new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");

                return response;

            }
            else
            {
                if (formato == 2)
                {

                    string archivo = HostingEnvironment.MapPath("~/Imagenes/onepiecex.png");
                    byte[] imgData = System.IO.File.ReadAllBytes(archivo);
                    MemoryStream ms = new MemoryStream(imgData);
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StreamContent(ms);
                    response.Content.Headers.ContentType =
                        new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");

                    return response;

                }
                else
                {
                    return Request.CreateResponse("Favor ingresar 1 para formato jpg y 2 para formato png");
                }
            }
        }
    }
}
