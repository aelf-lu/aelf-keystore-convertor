using AElf.Cryptography;
using AElf.KeyStore;
using AElf.Types;

namespace AElf.KeyStoreConvertor;

public static class KeyStoreConvertor
{
    public static void Convert(string privateKey, string keyStorePassword, string keyStoreDir)
    {
        var aelfKeyStoreService = new AElfKeyStoreService();
        var jsonContent = aelfKeyStoreService.EncryptKeyStoreAsJson(keyStorePassword, privateKey);
        var keyPair = CryptoHelper.FromPrivateKey(ByteArrayHelper.HexStringToByteArray(privateKey));
        var address = Address.FromPublicKey(keyPair.PublicKey).ToBase58();
        var keyStorePath = Path.Combine(GetKeyStoreDir(keyStoreDir), $"{address}.json");
        File.WriteAllText(keyStorePath, jsonContent);
    }

    private static string GetKeyStoreDir(string keyStoreDir)
    {
        if (string.IsNullOrEmpty(keyStoreDir))
        {
            return Directory.GetCurrentDirectory();
        }

        if (!Directory.Exists(keyStoreDir))
        {
            throw new KeyStoreConvertorException($"Directory {keyStoreDir} not exist.");
        }

        return keyStoreDir;
    }

}