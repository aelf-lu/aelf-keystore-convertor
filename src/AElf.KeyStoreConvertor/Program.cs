using System.CommandLine;
using System.CommandLine.Invocation;
using System.Threading.Tasks;

namespace AElf.KeyStoreConvertor;

internal static class Program
{
    private static async Task<int> Main(string[] args)
    {
        // Define Root command
        var rootCommand = new RootCommand("This is a tool for converting PrivateKey into a KeyStore");

        // Define argument type, name and description
        var privateKey = new Argument<string>(name: "PrivateKey", description: "PrivateKey of convert");
        var keyStorePassword = new Argument<string>(name: "KeyStorePassword", description: "Password of keyStore file");
        var keyStorePath = new Argument<string>(name: "KeyStorePath", description: "Path of keyStore file");
        rootCommand.AddArgument(privateKey);
        rootCommand.AddArgument(keyStorePassword);
        rootCommand.AddArgument(keyStorePath);

        rootCommand.Handler = CommandHandler.Create<string, string, string>(KeyStoreConvertor.Convert);

        return await rootCommand.InvokeAsync(args);
    }

}