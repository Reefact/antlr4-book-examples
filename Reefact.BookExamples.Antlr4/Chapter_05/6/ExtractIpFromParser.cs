#region Usings declarations

using Antlr4.Runtime.Tree;

#endregion

namespace Reefact.BookExamples.Antlr4.Chapter_05._6;

public class ExtractIpFromParser : IP_ParserBaseVisitor<bool> {

    #region Fields declarations

    private readonly HashSet<MyCustomIpAddress> _ipAddresses = new();

    #endregion

    /// <inheritdoc />
    public override bool VisitIp(IP_ParserParser.IpContext context) {
        ITerminalNode[]   @int    = context.INT(); // IP is already split by the parser
        int               ipPart1 = int.Parse(@int[0].GetText());
        int               ipPart2 = int.Parse(@int[1].GetText());
        int               ipPart3 = int.Parse(@int[2].GetText());
        int               ipPart4 = int.Parse(@int[3].GetText());
        MyCustomIpAddress ip      = new(ipPart1, ipPart2, ipPart3, ipPart4); // IP parts just have to be set

        return _ipAddresses.Add(ip);
    }

    public IReadOnlySet<MyCustomIpAddress> GetAddresses() {
        return _ipAddresses;
    }

}