using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Entidades
{
    public class RespuestaDTO
    {
        public enum TiposRespuesta { Exitoso = 1, Fallido = 0 }
        
            public TiposRespuesta TipoRp { get; set; }

            public string MsgRespuesta { get; set; }

            public object Respuesta { get; set; }

            public RespuestaDTO()
            {
                TipoRp = TiposRespuesta.Fallido;
                MsgRespuesta = string.Empty;
                Respuesta = null;
            }
        
    }
}
