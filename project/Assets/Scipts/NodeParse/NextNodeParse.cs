using System;

public class NextNodeParse : IDataParseType
{
    public void ParseData(DiaNode DialogNode, string data)
    {
        foreach (var item in data.Split('|'))
        {
            //跳过空节点   空节点不生成
            if (item.Equals(""))
            {
                continue;
            }
            int a;
            int.TryParse(item, out a);
            DialogNode.nextNode.Add(a);
        }
    }
}
