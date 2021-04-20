using System;

namespace calificaciones
{
    class Criterio
    {
        public string nombre;

        public float porcentaje;

        public Criterio(string nombre, float porcentaje)
        {
            if (nombre == "" || nombre == null)
            {
                throw new ArgumentException("El nombre es requerido");
            }
            if (!(porcentaje > 0f && porcentaje <= 1f))
            {
                throw new ArgumentException("El porcentaje debe ser mayor que 0 y menor o igual que 1");
            }
            this.nombre = nombre;
            this.porcentaje = porcentaje;
        }
    }
}