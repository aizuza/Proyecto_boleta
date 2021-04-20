using System;
using NUnit.Framework;

namespace calificaciones
{
    [TestFixture]
    class CriterioTest {
        [Test, Description("El Criterio solamente admite porcentajes válidos")]
        public void TestCriterioPercentValid()
        {
            // > 0
            Assert.DoesNotThrow(
                () => {
                    // 1% should not throw (should work correctly)
                    Criterio c1 = new Criterio("c1", 0.01f);
                    // 5%
                    Criterio c2 = new Criterio("c2", 0.05f);
                    // 50%
                    Criterio c3 = new Criterio("c3", 0.5f);
                }
            );

            // <= 100
            Assert.DoesNotThrow(
                () => {
                    // 100%
                    Criterio c1 = new Criterio("c1", 1.0f);
                    // 99%
                    Criterio c2 = new Criterio("c2", 0.99f);
                    // 70%
                    Criterio c3 = new Criterio("c3", 0.7f);
                }
            );

            // <= 0
            Assert.Throws<ArgumentException>(
                () => {
                    // 0%
                    Criterio c1 = new Criterio("c1", 0.0f);
                }
            );
            Assert.Throws<ArgumentException>(
                () => {
                    // -1%
                    Criterio c2 = new Criterio("c2", -0.01f);
                }
            );
            Assert.Throws<ArgumentException>(
                () => {
                    // -45%
                    Criterio c3 = new Criterio("c3", -0.45f);
                }
            );

            // > 100
            Assert.Throws<ArgumentException>(
                () => {
                    // 100.001%
                    Criterio c1 = new Criterio("c1", 1.00001f);
                }
            );
            Assert.Throws<ArgumentException>(
                () => {
                    // 101%
                    Criterio c2 = new Criterio("c2", 1.01f);
                }
            );
            Assert.Throws<ArgumentException>(
                () => {
                    // 120%
                    Criterio c3 = new Criterio("c3", 1.2f);
                }
            );
        }

        [Test, Description("El Criterio solamente admite nombres válidos")]
        public void TestCriterioNameValid()
        {
            Assert.Throws<ArgumentException>(
                () => {
                    Criterio c1 = new Criterio("", 0.25f);
                }
            );

            Assert.Throws<ArgumentException>(
                () => {
                    Criterio c1 = new Criterio(null, 0.25f);
                }
            );

            Assert.DoesNotThrow(
                () => {
                    Criterio c1 = new Criterio("c1", 0.25f);
                }
            );
        }
    }
}