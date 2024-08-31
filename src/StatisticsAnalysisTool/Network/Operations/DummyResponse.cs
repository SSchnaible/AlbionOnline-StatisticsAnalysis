using System.Collections.Generic;

namespace StatisticsAnalysisTool.Network.Operations;

public class DummyResponse
{
    public DummyResponse(Dictionary<byte, object> parameters)
    {
        this.parameters = parameters;
    }

    public Dictionary<byte, object> parameters { get; }
}