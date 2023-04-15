using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio05
{
    public class Torneo
    {
        public static Equipo[][] SimularTorneo(Equipo[] equipos)
        {
            if (equipos.Lenght < 2 || !isPowerOf2(equipos.Lenght))
                throw new Exception("La cantidad de equipos debe ser una potencia de dos y deben existir al menos dos equipos");

            int newS = (int)Math.Log2(equipos.Length) + 1;

            Equipo[][] result = new Equipo[newS][];

            result[0] = copyArray(equipos, equipos.Length);

            int equiposR = equipos.Length;
            int fase = 1;

            while (equiposR > 1)
            {
                for (int i = 0; i < equiposR / 2; i++)
                {
                    Partido partido = new Partido(equipos[i], equipos[equiposR - i - 1]);
                    Equipo ganador = partido.SeleccionarEquipoGanador();
                    equipos[i] = ganador;
                }

                equiposR = equiposR / 2;

                result[fase] = copyArray(equipos, equiposR);

                fase++;
            }

            return result;
        }

        private static bool isPowerOf2(int x)
        {
            double log2 = Math.Log2(x);

            return (log2 - (int)log2) == 0.0;
        }

        private static Equipo[] copyArray(Equipo[] equipos, int top)
        {
            Equipo[] copy = new Equipo[top];

            for (int i = 0; i < top; i++)
            {
                copy[i] = equipos[i];
            }

            return copy;
        }
    }
    
}
