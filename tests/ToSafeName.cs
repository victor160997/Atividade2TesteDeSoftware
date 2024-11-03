using NUnit.Framework;
using StringExtensions;

namespace tests
{
    [TestFixture]
    public class SafeNameTests
    {   
        /// TSN1 e TSN2
        /// Esse caso de teste deve retornar string vazia quando
        /// a entrada for string vazia ou nula
        [Test]
        public void ToSafeName_DeveRetornarStringVazia_QuandoEntradaForStringVaziaOuNula()
        {
            // Arrange
            string input = string.Empty;

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(string.Empty, resultado);
        }

        /// TSN2
        /// Esse caso de teste deve retornar string vazia quando
        /// a entrada for string apenas com espaços em brancos
        [Test]
        public void ToSafeName_DeveRetornarStringVazia_QuandoEntradaForEspacosEmBranco()
        {
            // Arrange
            string input = "   ";

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(string.Empty, resultado);
        }

        /// TSN3 
        /// Teste para remover caracteres especiais
        [Test]
        public void ToSafeName_DeveRemoverCaracteresEspeciais()
        {
            // Arrange
            string input = "@#$TestName123!";
            string expectedOutput = "TestName123";

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(expectedOutput, resultado);
        }

        /// TSN4
        /// Teste para remover acentuação.
        [Test]
        public void ToSafeName_DeveRemoverAcentuacao()
        {
            // Arrange
            string input = "áéíóúTestName";
            string expectedOutput = "aeiouTestName";

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(expectedOutput, resultado);
        }

        /// TSN5
        ///  Teste para remover números no início.
        [Test]
        public void ToSafeName_DeveRemoverNumerosNoInicio()
        {
            // Arrange
            string input = "123Name";
            string expectedOutput = "Name";

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(expectedOutput, resultado);
        }
        /// TSN6
        ///  Teste para truncar strings com mais de 128 caracteres.
        [Test]
        public void ToSafeName_DeveLimitarPara128Caracteres()
        {
            // Arrange
            string input = "ValidNameButVeryLongStringThatExceeds128CharactersInLengthWillBeTruncatedAccordingToTheCodeLogicValidNameButVeryLongStringThatExceeds128Characters";
            string expectedOutput = "ValidNameButVeryLongStringThatExceeds128CharactersInLengthWillBeTruncatedAccordingToTheCodeLogicValidNameButVeryLong";

            // Act
            string resultado = input.ToSafeName();

            // Assert
            Assert.AreEqual(expectedOutput, resultado);
        }
    }
}
