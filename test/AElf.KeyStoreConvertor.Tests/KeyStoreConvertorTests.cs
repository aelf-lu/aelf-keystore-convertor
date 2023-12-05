// ReSharper disable StringLiteralTypo

namespace AElf.KeyStoreConvertor.Tests;

public class KeyStoreConvertorTests
{
    private const string Password = "abcde";
    private const string PrivateKeyHex = "ff96c3463af0b8629f170f078f97ac0147490b92e1784e3bff93f7ee9d1abcb6"; 
    private const string Address = "VQFq9atg4fMtFLhqpVh48ZnhX8FXMGBHW8MDANPpCSHcZisU6";
    
    [Fact]
    public void ConvertTest()
    {
        var dir = Directory.GetCurrentDirectory();
        KeyStoreConvertor.Convert(PrivateKeyHex, Password, dir);
        Assert.True(File.Exists(Path.Combine(dir, $"{Address}.json")));
    }
    
    [Fact]
    public void ConvertTest_DirIsNull()
    {
        const string password = "abcde";
        const string privateKeyHex = "ff96c3463af0b8629f170f078f97ac0147490b92e1784e3bff93f7ee9d1abcb6";
        KeyStoreConvertor.Convert(privateKeyHex, password, null);
        Assert.True(File.Exists(Path.Combine(Directory.GetCurrentDirectory(), $"{Address}.json")));
    }
}