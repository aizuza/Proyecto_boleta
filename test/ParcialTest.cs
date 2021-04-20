using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace Calificaciones
{
    [TestFixture]
    class ParcialTest
    {

        [Test, Description("Se agregan correctamente criterios a un Parcial")]
        public void TestAgregarCriterios()
        {
            Parcial primerParcial = new Parcial();
            Criterio c1 = new Criterio("c1", 0.25f);
            primerParcial.AgregarCriterio(c1);
            Assert.That(primerParcial.criterios[0], Is.EqualTo(c1));

        }

        [Test, Description("Se valida correctamente la suma de porcentajes de criterios en un Parcial")]
        public void TestSumaPorcentajes()
        {
            Parcial primerParcial = new Parcial();
            Parcial segundoParcial = new Parcial();

            Criterio c1 = new Criterio("c1", 0.25f);
            Criterio c2 = new Criterio("c1", 0.25f);
            Criterio c3 = new Criterio("c1", 0.25f);
            Criterio c4 = new Criterio("c1", 0.25f);

            primerParcial.AgregarCriterio(c1);
            primerParcial.AgregarCriterio(c2);
            primerParcial.AgregarCriterio(c3);
            primerParcial.AgregarCriterio(c4);

            segundoParcial.AgregarCriterio(c1);
            segundoParcial.AgregarCriterio(c3);


            bool succes = primerParcial.ValidarSumaCriterios(1.0f);
            Assert.That(succes, Is.EqualTo(true));
            succes = segundoParcial.ValidarSumaCriterios(1.0f);
            Assert.That(succes, Is.EqualTo(false));

        }

        [Test, Description("Se valida correctamente que los criterios en un Parcial deben ser distintos")]
        public void TestCriteriosDistintos()
        {
            Parcial primerParcial = new Parcial();
            Criterio c1 = new Criterio("c1", 0.25f);
            Criterio c2 = new Criterio("c1", 0.25f);
            Criterio c3 = new Criterio("c1", 0.25f);
            Criterio c4 = new Criterio("c1", 0.25f);
            primerParcial.AgregarCriterio(c1);
            primerParcial.AgregarCriterio(c2);
            primerParcial.AgregarCriterio(c3);
            primerParcial.AgregarCriterio(c4);


            Parcial segundoParcial = new Parcial();
            Criterio c5 = new Criterio("c5", 0.25f);
            Criterio c6 = new Criterio("c6", 0.25f);
            Criterio c7 = new Criterio("c7", 0.25f);
            Criterio c8 = new Criterio("c8", 0.25f);
            segundoParcial.AgregarCriterio(c5);
            segundoParcial.AgregarCriterio(c6);
            segundoParcial.AgregarCriterio(c7);
            segundoParcial.AgregarCriterio(c8);

            Assert.That(primerParcial.ValidarCriteriosDistintos(), Is.EqualTo(false));
            Assert.That(segundoParcial.ValidarCriteriosDistintos(), Is.EqualTo(true));

        }

        [Test, Description("Se valida correctamente que los criterios son requeridos en un Parcial")]
        public void TestCriteriosRequeridos()
        {
            Parcial primerParcial = new Parcial();
            Parcial segundoParcial = new Parcial();

            Criterio c1 = new Criterio("c1", 1.0f);

            primerParcial.AgregarCriterio(c1);
            Assert.That(primerParcial.ValidarCriteriosDefinidos, Is.EqualTo(true));
            Assert.That(segundoParcial.ValidarCriteriosDefinidos, Is.EqualTo(false));
        }

        [Test, Description("El Parcial calcula correctamente la calificación")]
        public void TestCalcularCalificacion()
        {
            Parcial primerParcial = new Parcial();

            Criterio c1 = new Criterio("c1", 0.25f);
            Criterio c2 = new Criterio("c1", 0.25f);
            Criterio c3 = new Criterio("c1", 0.25f);
            Criterio c4 = new Criterio("c1", 0.25f);

            List<float> calificacionesCriterios = new List<float>();
            calificacionesCriterios.Add(7f);
            calificacionesCriterios.Add(8f);
            calificacionesCriterios.Add(10f);
            calificacionesCriterios.Add(7f);

            List<float> calificacionesCriterios2 = new List<float>();
            calificacionesCriterios2.Add(10f);
            calificacionesCriterios2.Add(9f);
            calificacionesCriterios2.Add(9f);
            calificacionesCriterios2.Add(0f);

            primerParcial.AgregarCriterio(c1);
            primerParcial.AgregarCriterio(c2);
            primerParcial.AgregarCriterio(c3);
            primerParcial.AgregarCriterio(c4);

            int calificacionPrimerParcial = primerParcial.CalcularCalificacion(calificacionesCriterios);
            Assert.That(calificacionPrimerParcial, Is.EqualTo(8));
            int calificacionPrimerParcial2 = primerParcial.CalcularCalificacion(calificacionesCriterios2);
            Assert.That(calificacionPrimerParcial2, Is.EqualTo(7));
        }
    }
}