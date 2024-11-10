using StringExtensions;

namespace tests;
[TestFixture]
public class TranslateTests
{
    [Test]
    public void TR01_TraducaoSimples()
    {
        Assert.AreEqual("Hoiio", "Hello".Translate(new char[] { 'e', 'l' }, new char[] { 'o', 'i' }));
    }

    [Test]
    public void TR02_StringVazia()
    {
        Assert.AreEqual("", "".Translate(new char[] { 'a' }, new char[] { 'b' }));
    }

    [Test]
    public void TR03_CaracteresRepetidos()
    {
        Assert.AreEqual("xxyyy", "aabbb".Translate(new char[] { 'a', 'b' }, new char[] { 'x', 'y' }));
    }

    [Test]
    public void TR04_CaractereNaoEncontrado()
    {
        Assert.AreEqual("Hoiio", "Hello".Translate(new char[] { 'e', 'l' }, new char[] { 'o', 'i' }));
    }

    [Test]
    public void TR06_ParametrosNulos()
    {
        Assert.Throws<ArgumentNullException>(() => "Hello".Translate(null, []));
    }

    [Test]
    public void TR07_CaracteresEspeciais()
    {
        Assert.AreEqual("12#$", "!@#$".Translate(new char[] { '!', '@' }, new char[] { '1', '2' }));
    }

    [Test]
    public void TR08_MaiusculasEMinusculas()
    {
        Assert.AreEqual("HOILo", "HelLo".Translate(new char[] { 'e', 'l' }, new char[] { 'O', 'I' }));
    }
}
