using System.CommandLine;

namespace cqt;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var connectionOption= new Option<string>(
            name: "--connection",
            description: "连接字符串");
        connectionOption.AddAlias("-c");


        var profileCommand = new Command("profile");
        profileCommand.Add(connectionOption);


        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.Add(profileCommand);


        profileCommand.SetHandler(str =>
        {
            DBHelp.sqliteConnection = str;
        });
        return await rootCommand.InvokeAsync(args);
    }
};
