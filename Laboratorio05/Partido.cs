using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio05
{
    public class Partido
    {
        private Equipo equipo1;
        private Equipo equipo2;

        private Equipo ganador;

        public Partido(Equipo equipo1, Equipo equipo2)
        {
            
        }

        public Equipo GetEquipo1()
        { 
            return equipo1;
        }

        public Equipo GetEquipo2() 
        {
            return equipo2;
        }

        public Equipo SeleccionarEquipoGanador()
        {
            if (ganador != null)
                return ganador;

            double puntajeE1, puntajeE2;

            do
            {
                puntajeE1 = IRandomGenerator.RandomGenerator.Next() * (((equipo1.GetPartidosGanados() * 0.7) + (equipo1.GetPartidosPerdidos() * 0.1) + (equipo1.GetPartidosEmpatados() * 0.2)) / (equipo1.GetGolesFavor() - equipo1.GetGolesContra() + 0.001));

                puntajeE2 = IRandomGenerator.RandomGenerator.Next() * (((equipo2.GetPartidosGanados() * 0.7) + (equipo2.GetPartidosPerdidos() * 0.1) + (equipo2.GetPartidosEmpatados() * 0.2)) / (equipo2.GetGolesFavor() - equipo2.GetGolesContra() + 0.001));
            } while (puntajeE1 == puntajeE2);

            if (puntajeE1 > puntajeE2)
                ganador = equipo1;
            else
                ganador = equipo2;

            return ganador;

        }
    }
}
