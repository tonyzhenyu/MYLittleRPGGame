using System.Collections.Generic;

public class FileManager
{
    public List<DiaNode> NowNodes = new List<DiaNode>();
    public delegate void OnClearScene();
    public OnClearScene onClearScene;
    public void ClearScene()
    {
        NowNodes.Clear();
        onClearScene?.Invoke();
    }
    public void SetScene(string scene)
    {
        ClearScene();
        NowNodes = new ReadDialogFile().ReadFromFile(scene);
    }
    public string[] GetAllScene()
    {
        return new ReadDialogFile().PassOverFile(MyPathConfig.CSV_PATH);
    }
}
