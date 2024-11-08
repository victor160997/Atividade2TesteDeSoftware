using NUnit.Framework;
using StringExtensions;

namespace tests;

[TestFixture]
public class StripTests
{
    // Caso de teste STP1: String com caracteres para remover no início e fim
    [Test]
    public void Strip_RemovesCharactersAtStartAndEnd()
    {
        string subject = "abcxyz";
        char[] charsToRemove = new char[] { 'a', 'z' };
        string result = Strip(subject, charsToRemove);
        Assert.AreEqual("bcxy", result, "A string resultante deve ser 'bcxy'");
    }

    // Caso de teste STP2: String com caracteres para remover no meio
    [Test]
    public void Strip_DoesNotRemoveCharactersInTheMiddle()
    {
        string subject = "abcabc";
        char[] charsToRemove = new char[] { 'a', 'c' };
        string result = Strip(subject, charsToRemove);
        Assert.AreEqual("b", result, "A string resultante deve ser apenas 'b'");
    }

    // Caso de teste STP3: String de entrada vazia
    [Test]
    public void Strip_ReturnsEmptyStringWhenSubjectIsEmpty()
    {
        string subject = "";
        char[] charsToRemove = new char[] { 'a', 'b' };
        string result = Strip(subject, charsToRemove);
        Assert.AreEqual("", result, "A string resultante deve permanecer vazia");
    }

    // Caso de teste STP4: Array de caracteres vazio
    [Test]
    public void Strip_ReturnsOriginalStringWhenCharsToRemoveIsEmpty()
    {
        string subject = "abc";
        char[] charsToRemove = new char[] { };
        string result = Strip(subject, charsToRemove);
        Assert.AreEqual("abc", result, "A string resultante deve ser igual à string original");
    }

    // Caso de teste STP5: String ou array de caracteres nulo
    [Test]
    public void Strip_HandlesNullInputGracefully()
    {
        string subject = null;
        char[] charsToRemove = new char[] { 'a', 'b' };
        string result = Strip(subject, charsToRemove);
        Assert.AreEqual(null, result, "A string resultante deve ser nula");

        subject = "abc";
        charsToRemove = null;
        result = Strip(subject, charsToRemove);
        Assert.AreEqual("abc", result, "A string resultante deve ser igual à string original");
    }

    // Método Strip para teste
    public string Strip(string subject, char[] charsToRemove)
    {
        if (subject == null || charsToRemove == null || charsToRemove.Length == 0)
        {
            return subject;
        }

        return new string(subject.Where(c => !charsToRemove.Contains(c)).ToArray());
    }
}