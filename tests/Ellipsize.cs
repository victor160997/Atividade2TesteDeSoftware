using NUnit.Framework;
using StringExtensions;
namespace tests;


[TestFixture]
public class EllipsizeTeste
{
    [Test]
    public void Ellipsize_DeveRetornarStringVazia_QuandoEntradaForVazia()
    {
        // Arrange (Preparação)
        string entrada = "";
        int limite = 10;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("", resultado);
    }

    [Test]
    public void Ellipsize_DeveRetornarStringOriginal_QuandoComprimentoForMenorQueLimite()
    {
        // Arrange (Preparação)
        string entrada = "Hello";
        int limite = 10;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("Hello", resultado);
    }

    [Test]
    public void Ellipsize_DeveCortarEAdicionarReticencias_QuandoComprimentoExcederLimite()
    {
        // Arrange (Preparação)
        string entrada = "Hello, this is a test string.";
        int limite = 10;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("Hello, thi...", resultado);
    }

    [Test]
    public void Ellipsize_DeveRemoverEspacosExtras_QuandoComprimentoExcederLimiteComEspacos()
    {
        // Arrange (Preparação)
        string entrada = "Hello, this is a test string.   ";
        int limite = 10;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("Hello, thi...", resultado);
    }

    [Test]
    public void Ellipsize_NaoDeveAlterarString_QuandoComprimentoIgualAoLimite()
    {
        // Arrange (Preparação)
        string entrada = "Hello...";
        int limite = 8;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("Hello...", resultado);
    }

    [Test]
    public void Ellipsize_DeveRespeitarLimiteDeCaracteres_ComLimitePersonalizado()
    {
        // Arrange (Preparação)
        string entrada = "Hello, this is a test string.";
        int limite = 15;
        
        // Act (Ação)
        string resultado = entrada.Ellipsize(limite, "...");
        
        // Assert (Verificação)
        Assert.AreEqual("Hello, this...", resultado);
    }
}
