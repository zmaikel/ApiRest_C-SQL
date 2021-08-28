using CapaDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public interface IGestorDB
    {
        //Obtiene top100 personas con salarios mas altos por provincia
        RespuestaDTO ObtenerTopPersonasPorSalarioYProvincia(int provincia);
        //Obtiene numero aleatorio entre 1-3 para calcular el riesgo financiero
        RespuestaDTO ObtenerNumeroAleatorio();
        //Obtiene Cantidad de personas por Genero y Edad
        RespuestaDTO CantPersonasporGeneroYEdad(int genero, int edad);
    }
}
