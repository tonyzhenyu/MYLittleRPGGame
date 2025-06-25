using System.Collections.Generic;
[System.Serializable]
public class DiaNode
{

    public int id;
    public string nodeName;
    public string dataStr;
    public string ChoiceStr;
    public List<int> nextNode;
    public List<string> OnEnterEvent;
    public List<string> OnOverEvent;

    public DiaNode()
    {
        id = 0;
        nodeName = "";
        dataStr = "";
        ChoiceStr = "";
        nextNode = new List<int>();
        nextNode.Clear();
        OnEnterEvent = new List<string>();
        OnOverEvent = new List<string>();
    }

}
