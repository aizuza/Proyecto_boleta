using System;
using NUnit.Framework;

namespace Calificaciones
{
    [TestFixture]
    class MateriaTest
    {
         [Test, Description("Se validan correctamente las calificaciones de los parciales para crear una Materia")]
        public void TestCalificacionesParciales()
        {

            Assert.DoesNotThrow(
               () =>
               {
                   Materia Matematicas = new Materia(7, 9, 10);
                   Materia Español = new Materia(0, 8, 9);
                   Materia Alpinismo = new Materia(9, 9, 10);
               }
           );

            Assert.Throws<ArgumentException>(
                 () =>
                 {
                     Materia Matematicas = new Materia(7, 6, -9);
                     Materia Español = new Materia(9, -30, 9);
                     Materia Alpinismo = new Materia(0, 2, 12);
                     Materia Materias_taco = new Materia(0, 1, 9);
                 }
             );
        }

        [Test, Description("Se calcula correctamente el promedio de los primeros 2 parciales")]
        public void TestPromedioParciales()
        {                                
            Materia Matematicas = new Materia(9, 9, 8);          
            Assert.That(Matematicas.CalcularPromedioParciales(), Is.EqualTo(9f));
            Materia Español = new Materia(7, 8, 9);
            Assert.That(Español.CalcularPromedioParciales(), Is.EqualTo(8f));
        }

        [Test, Description("Se calcula correctamente el promedio final")]
        public void TestPromedioFinal()                                                 
        {                                      
            Materia Matematicas = new Materia(6, 6, 10);        
            Assert.That(Matematicas.CalcularPromedioFinal(), Is.EqualTo(7.3f));
            Materia Español = new Materia(4,7,7);
            Assert.That(Español.CalcularPromedioFinal(), Is.EqualTo(6));
        }

        [Test, Description("Se indica correctamente cuando se requiere aplicar evaluación extraordinaria")]
        public void TestEvaluacionExtraordinario()
        {                           
            Materia Matematicas = new Materia(8, 6, 9);      
            Assert.That(Matematicas.RevisarRequiereAplicarEvaluacionExtraordinario(), Is.EqualTo(true));
            Materia Español = new Materia(7,6, 7);
            Assert.That(Español.RevisarRequiereAplicarEvaluacionExtraordinario(), Is.EqualTo(true));
            Materia Alpinismo = new Materia(8, 9, 9);
            Assert.That(Alpinismo.RevisarRequiereAplicarEvaluacionExtraordinario(), Is.EqualTo(true));
        }
    }
}