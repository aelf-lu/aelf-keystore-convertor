using System.CommandLine;
using System.CommandLine.Invocation;

namespace AElf.KeyStoreGenerator;

internal class Program
{
    static async Task<int> Main(string[] args)
    {
        // Define Root command
        var rootCommand = new RootCommand("This is a tool for converting PrivateKey into a KeyStore");

        // Define argument type, name and description
        Argument<string> privateKey = new Argument<string>(name: "PrivateKey", description: "PrivateKey of convert");
        Argument<string> keyStorePassword = new Argument<string>(name: "KeyStorePassword", description: "Password of keyStore file");
        Argument<string> keyStorePath = new Argument<string>(name: "KeyStorePath", description: "Path of keyStore file");
        rootCommand.AddArgument(privateKey);
        rootCommand.AddArgument(keyStorePassword);
        rootCommand.AddArgument(keyStorePath);

        rootCommand.Handler = CommandHandler.Create<string, string, string>((privateKey, keyStorePassword, keyStorePath) =>
        {
            KeyStoreGenerator.Generate(privateKey, keyStorePassword, keyStorePath);
        });

        return await rootCommand.InvokeAsync(args);
    }

}