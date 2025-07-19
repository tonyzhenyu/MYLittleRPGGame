using System;

public class NodeIDParse : IDataParseType
{
    public void ParseData(DiaNode DialogNode, string data)
    {
        int.TryParse(data, out DialogNode.id);
    }
}
