// ReSharper disable StringLiteralTypo

using System.IO;

namespace AElf.KeyStoreConvertor.Tests;

public class KeyStoreConvertorTests
{
    [Fact]
    public void ConvertTest()
    {
        const string password = "abcde";
        const string privateKeyHex = "ff96c3463af0b8629f170f078f97ac0147490b92e1784e3bff93f7ee9d1abcb6";
        KeyStoreConvertor.Convert(privateKeyHex, password, "test.json");
        Assert.True(File.Exists("test.json"));
    }
}