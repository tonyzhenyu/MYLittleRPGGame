using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using System.IO;
using UnityEditor;
using UnityEngine.Networking;

public class ReadDialogFile
{
    private string[] myFile;
    public List<DiaNode> ReadFromFile(string path)
    {
        // path = "resources/.."
        myFile = Read(path).Split('\n');
        List<DiaNode> nodes;
        nodes = IniatilizeData(myFile);
        return nodes;
    }

    /// <summary>
    /// 返回路径
    /// </summary>
    /// <returns></returns>
    public string[] PassOverFile(string path)
    {
        List<string> filesName = new List<string>();
        foreach (FileInfo item in new DirectoryInfo(path).GetFiles())
        {
            if (item.Name.Contains(".meta"))
            {
                continue;
            }
            filesName.Add(item.Name);
        }
        return filesName.ToArray();
    }
    private string Read(string path)
    {
        //return Resources.Load<TextAsset>(path);
        
        return File.ReadAllText(path);
    }
    private List<DiaNode> IniatilizeData(string[] file)
    {
        List<DiaNode> nodes = new List<DiaNode>();
        foreach (var row in file.Skip(1).ToArray())
        {
            DiaNode tempDialogNode = new DiaNode();
            List<string> items = row.Split(',').ToList();
            foreach (var item in items)
            {
                ParseData(items.IndexOf(item),tempDialogNode,item,file[0]);
            }
            nodes.Add(tempDialogNode);
        }
        return nodes;
    }
    private List<IDataParseType> GetParseType(string vs)
    {
        List<IDataParseType> a = new List<IDataParseType>();
        string[] mytype = vs.Split(',');
        mytype[mytype.Length - 1] = mytype[mytype.Length - 1].Replace("\r", "");
        foreach (var item in mytype)
        {
            var type = Type.GetType(item);
            if (type != null)
            { 
                a.Add(Activator.CreateInstance(type) as IDataParseType);
            }
        }
        return a;
    }
    private void ParseData(int index, DiaNode DialogNode,string data,string file)
    {
        IDataParseType[] a = GetParseType(file).ToArray();
        a[index].ParseData(DialogNode,data);
    }

}
