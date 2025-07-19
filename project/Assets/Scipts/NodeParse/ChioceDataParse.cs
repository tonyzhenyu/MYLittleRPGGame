using System;
public class ChioceDataParse : IDataParseType
{
    public void ParseData(DiaNode DialogNode, string data)
    {
        DialogNode.ChoiceStr = data;
    }
}
