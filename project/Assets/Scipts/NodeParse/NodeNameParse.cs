using System;

public class NodeNameParse : IDataParseType
{
    public void ParseData(DiaNode DialogNode, string data)
    {
        DialogNode.nodeName = data;
    }
}