using NUnit.Framework;
using StringExtensions;

namespace tests


[TestFixture]
public class TranslateTests
{
    // Função fictícia de exemplo para o caso de uso.
    // Substitua com a implementação real da função Translate.
    public string Translate(string input, string source, string target)
    {
        if (input == null || source == null || target == null)
            throw new ArgumentNullException();
        
        if (source.Length != target.Length)
            throw new ArgumentException("Arrays de tamanhos diferentes");

        // Exemplo de tradução simples, você deve implementar sua lógica real.
        foreach (var c in source)
        {
            input = input.Replace(c, target[source.IndexOf(c)]);
        }

        return input;
    }

    [Test]
    public void TR01_TraducaoSimples()
    {
        Assert.AreEqual("Hoio", Translate("Hello", "el", "oi"));
    }

    [Test]
    public void TR02_StringVazia()
    {
        Assert.AreEqual("", Translate("", "a", "b"));
    }

    [Test]
    public void TR03_CaracteresRepetidos()
    {
        Assert.AreEqual("xxyyy", Translate("aabbb", "ab", "xy"));
    }

    [Test]
    public void TR04_CaractereNaoEncontrado()
    {
        Assert.AreEqual("Hoio", Translate("Hello", "el", "oi"));
    }

    [Test]
    public void TR05_ArraysDeTamanhosDiferentes()
    {
        Assert.Throws<ArgumentException>(() => Translate("Hello", "el", "oia"));
    }

    [Test]
    public void TR06_ParametrosNulos()
    {
        Assert.Throws<ArgumentNullException>(() => Translate(null, "a", "b"));
    }

    [Test]
    public void TR07_CaracteresEspeciais()
    {
        Assert.AreEqual("12#", Translate("!@#$", "!@", "12"));
    }

    [Test]
    public void TR08_MaiusculasEMinusculas()
    {
        Assert.AreEqual("HoIO", Translate("HelLo", "el", "OI"));
    }
}
