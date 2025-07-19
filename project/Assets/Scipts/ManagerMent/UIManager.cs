using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

public class UIManager : MonoBehaviour
{
    public GameObject ScenePanel;
    public GameObject DialogCanvas;
    public GameObject TitleCanvas;
    EventSystem EventSystem;
    GameObject[] canvas;
    public static UIManager instance;
    
    private void Awake()
    {
        instance = this;
        EventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        canvas = new GameObject[3] { TitleCanvas, ScenePanel, DialogCanvas };
    }

    private void Update()
    {

    }
    public void RefreashCanvas()
    {
        ScenePanel.GetComponent<SceneCanvas>().RefreashCanvas();
    }
    public void DisplayCanvas(int displayID)
    {
        for (int i = 0; i <= canvas.Length - 1; i++)
        {
            if (i == displayID)
            {
                canvas[i].SetActive(true);
                continue;
            }
            canvas[i].SetActive(false);
        }
    }
    public int ActivedCanvasID()
    {
        int k = 0;
        for (int i = 0; i <= canvas.Length-1; i++)
        {
            if (canvas[i].activeSelf == true)
            {
                i = k;
            }
        }
        return k;
    }
    [ContextMenu("TestWebRequest")]
    void TestWebRequest()
    {
        StartCoroutine(Get());
    }
    IEnumerator Get()
    {
        string a = "https://raw.githubusercontent.com/tonyzhenyu/MYLittleRPGGame/main";
        UnityWebRequest webRequest = UnityWebRequest.Get(a);

        yield return webRequest.SendWebRequest();
        //异常处理，很多博文用了error!=null这是错误的，请看下文其他属性部分
        if (webRequest.isHttpError || webRequest.isNetworkError)
            Debug.Log(webRequest.error);
        else
        {
            Debug.Log(webRequest.downloadHandler.text);
        }
    }
}
