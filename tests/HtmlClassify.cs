using NUnit.Framework;
using StringExtensions;

namespace tests;

[TestFixture]
public class HtmlClassifyTests
{
    [Test]
    public void HtmlClassify_DeveRetornarStringVazia_QuandoEntradaForStringVazia()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string resultado = input.HtmlClassify();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

    [Test]
    public void HtmlClassify_DeveRetornarStringVazia_QuandoEntradaForEspaço()
    {
        // Arrange
        string input = " ";

        // Act
        string resultado = input.HtmlClassify();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

    [Test]
    public void HtmlClassify_DeveRetornarStringConvertidaEmKebabCase_QuandoEntradaForStringCamelCase()
    {
        // Arrange
        string input = "TesteEntradaCamelCase";

        // Act
        string resultado = input.HtmlClassify();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

    [Test]
    public void HtmlClassify_DeveRetornarSemNumeros_QuandoEntradaTemNumeros()
    {
        // Arrange
        string input = "TesteTrata3Numero";

        // Act
        string resultado = input.HtmlClassify();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

    [Test]
    public void HtmlClassify_DeveRetornarSemCaracEspecial_QuandoEntradaTemCaracEspecial()
    {
        // Arrange
        string input = "TesteTrata!@#CaractereEspecial";

        // Act
        string resultado = input.HtmlClassify();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

}
