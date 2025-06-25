using System;

public class NodeDataParse : IDataParseType
{
    public void ParseData(DiaNode DialogNode, string data)
    {
        DialogNode.dataStr = data;
    }
}