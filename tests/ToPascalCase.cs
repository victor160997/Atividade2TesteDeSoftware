using NUnit.Framework;
using StringExtensions;

namespace tests;

[TestFixture]
public class ToPascalCase
{
    [Test]
    public void ToPascalCase_SingleWordWithMixedCase_ReturnsFirstLetterUpperCase()
    {
        // Arrange
        string input = "palavraTeste";
        char delimiter = ' '; 

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("PalavraTeste", result);
    }
        [Test]
    public void ToPascalCase_StringWithHyphenDelimiter_ReturnsPascalCase()
    {
        // Arrange
        string input = "caso-de-teste";
        char delimiter = '-';

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("CasoDeTeste", result);
    }
        [Test]
    public void ToPascalCase_SingleWordWithoutDelimiter_ReturnsFirstLetterUpperCase()
    {
        // Arrange
        string input = "teste";
        char delimiter = '-'; 

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("Teste", result);
    }
        [Test]
    public void ToPascalCase_EmptyString_ReturnsEmptyString()
    {
        // Arrange
        string input = "";
        char delimiter = '-'; 

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("", result);
    }
        [Test]
    public void ToPascalCase_AllUppercaseSingleWord_ReturnsFirstLetterUppercaseRestLowercase()
    {
        // Arrange
        string input = "PALAVRACASODETESTE";
        char delimiter = '-'; 

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("Palavracasodeteste", result);
    }
        [Test]
    public void ToPascalCase_StringAlreadyInPascalCase_ReturnsSameString()
    {
        // Arrange
        string input = "UmTeste";
        char delimiter = '-'; 

        // Act
        string result = input.ToPascalCase(delimiter);

        // Assert
        Assert.AreEqual("UmTeste", result);
    }   
}

