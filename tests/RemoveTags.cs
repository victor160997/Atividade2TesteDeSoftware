using NUnit.Framework;
using StringExtensions;

namespace tests;

[TestFixture]
public class HtmlExtensionsTests
{
    [Test]
    public void RemoveTags_DeveRetornarStringVazia_QuandoEntradaForStringVazia()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string resultado = input.RemoveTags();

        // Assert
        Assert.AreEqual(string.Empty, resultado);
    }

    [Test]
    public void RemoveTags_DeveRetornarMesmaString_QuandoNaoHaTagsHtml()
    {
        // Arrange
        string input = "Texto sem tags HTML";

        // Act
        string resultado = input.RemoveTags();

        // Assert
        Assert.AreEqual(input, resultado);
    }

    [Test]
    public void RemoveTags_DeveRemoverTagHtmlSimples()
    {
        // Arrange
        string input = "Texto com <b>tag</b> HTML.";
        string expectedOutput = "Texto com tag HTML.";

        // Act
        string resultado = input.RemoveTags();

        // Assert
        Assert.AreEqual(expectedOutput, resultado);
    }

    [Test]
    public void RemoveTags_DeveRemoverTagsHtmlAninhadas()
    {
        // Arrange
        string input = "<div><p>Texto <b>com</b> várias <i>tags</i> HTML aninhadas.</p></div>";
        string expectedOutput = "Texto com várias tags HTML aninhadas.";

        // Act
        string resultado = input.RemoveTags();

        // Assert
        Assert.AreEqual(expectedOutput, resultado);
    }

    [Test]
    public void RemoveTags_DeveDecodificarCaracteresHtml_QuandoHtmlDecodeForVerdadeiro()
    {
        // Arrange
        string input = "Texto com &lt;b&gt;tag&lt;/b&gt; HTML.";
        string expectedOutput = "Texto com <b>tag</b> HTML.";

        // Act
        string resultado = input.RemoveTags(htmlDecode: true);

        // Assert
        Assert.AreEqual(expectedOutput, resultado);
    }

    [Test]
    public void RemoveTags_NaoDeveDecodificarCaracteresHtml_QuandoHtmlDecodeForFalso()
    {
        // Arrange
        string input = "Texto com &lt;b&gt;tag&lt;/b&gt; HTML.";
        string expectedOutput = "Texto com &lt;b&gt;tag&lt;/b&gt; HTML.";

        // Act
        string resultado = input.RemoveTags(htmlDecode: false);

        // Assert
        Assert.AreEqual(expectedOutput, resultado);
    }
}