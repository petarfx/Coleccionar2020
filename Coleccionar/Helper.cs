using Coleccionar.Enums;
using System;

namespace Coleccionar
{
    public static class Helper
    {
        public static string getTipoPublicacionById(int tipoPub)
        {
            return Convert.ToString((EnumTipoPublicacion)tipoPub);
        }

        internal static string getFechaPublicacion(DateTime fecha)
        {
            int datediff = Convert.ToInt32((DateTime.Now - fecha).TotalDays);
            return datediff == 0 ? "Publicado HOY" : datediff == 1 ? "Publicado AYER" : String.Format("Publicado hace {0} días",datediff.ToString());
        }
    }
}