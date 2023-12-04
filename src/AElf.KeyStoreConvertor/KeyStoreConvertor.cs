using System.IO;
using AElf.KeyStore;

namespace AElf.KeyStoreConvertor;

public static class KeyStoreConvertor
{
    public static void Convert(string privateKey, string keyStorePassword, string keyStorePath)
    {
        AElfKeyStoreService aelfKeyStoreService = new AElfKeyStoreService();
        var json = aelfKeyStoreService.EncryptKeyStoreAsJson(keyStorePassword, privateKey);
        File.WriteAllText(keyStorePath, json);
    }
}