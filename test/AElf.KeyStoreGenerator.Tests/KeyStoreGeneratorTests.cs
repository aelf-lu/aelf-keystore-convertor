using AElf.KeyStore;
// ReSharper disable StringLiteralTypo

namespace AElf.KeyStoreGenerator.Tests;

public class KeyStoreGeneratorTests
{
    [Fact]
    public void GenerateTest()
    {
        const string password = "abcde";
        const string privateKeyHex = "ff96c3463af0b8629f170f078f97ac0147490b92e1784e3bff93f7ee9d1abcb6";
        KeyStoreGenerator.Generate(privateKeyHex, password, "test.json");
        var keystoreService = new AElfKeyStoreService();
        Assert.Equal(privateKeyHex, keystoreService.DecryptKeyStoreFromFile(password, "test.json").ToHex());
    }
}