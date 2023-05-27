namespace Diefesson.Cryptool.Cli;

using System.Text;

public static class CliConventions
{

    public static Stream GetInStream(string path)
    {
        if (path == "-")
        {
            return Console.OpenStandardInput();
        }
        else
        {
            return new FileStream(path, FileMode.Open);
        }
    }

    public static Stream GetOutStream(string path)
    {
        if (path == "-")
        {
            return Console.OpenStandardOutput();
        }
        else
        {
            return new FileStream(path, FileMode.Append);
        }
    }

    public static StreamReader GetStreamReader(string path)
    {
        return new StreamReader(GetInStream(path), Encoding.UTF8);
    }

    public static StreamWriter GetStreamWriter(string path)
    {
        return new StreamWriter(GetOutStream(path), Encoding.UTF8);
    }

}