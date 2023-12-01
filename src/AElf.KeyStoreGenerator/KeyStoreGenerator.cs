using AElf.KeyStore;

namespace AElf.KeyStoreGenerator;

public class KeyStoreGenerator
{
    public static void Generate(string privateKey, string keyStorePassword, string keyStorePath)
    {
        AElfKeyStoreService aelfKeyStoreService = new AElfKeyStoreService();
        var json = aelfKeyStoreService.EncryptKeyStoreAsJson(keyStorePassword, privateKey);
        File.WriteAllText(keyStorePath, json);
    }
}