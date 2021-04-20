using System;
using System.Collections.Generic;

namespace calificaciones
{
        class Parcial
    {
        // public Criterio criterio; ???
        public List<Criterio> criterios = new List<Criterio>();


        // TODO: calcularlo

        public void AgregarCriterio(Criterio criterio)
        {
            this.criterios.Add(criterio);
        }
        // Suma de criterios da 100%
        // Criterios distintos
        // Debe haber por lo menos 1 criterio

        public bool ValidarSumaCriterios(float porcentaje)
        {   
            float SumaC = 0f;

            for (int i = 0; i < this.criterios.Count; i++)
            {
                SumaC = SumaC + this.criterios[i].porcentaje;

            }
            if (SumaC == 1.0f)
            {
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool ValidarCriteriosDistintos()
        {
            // TODO: validar que todos los criterios tienen nombre distinto
            return true;
        }

        public bool ValidarCriteriosDefinidos()
        {
            // TODO: validar que por lo menos hay 1 criterio
            return true;
        }

        public int CalcularCalificacion(List<float> calificacionesDeCadaCriterio)
        {
            return 10;
        }
    }

}