using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public FileManager FileManager;

    public UnityEvent OnGameStart;
    public UnityEvent OnGameEnd;

    public int nowDiaId = 0;

    private void Awake()
    {
        instance = this;
        FileManager = new FileManager();
        
    }
    // Use this for initialization
    void Start()
    {
        OnGameEnd.AddListener(() => { UIManager.instance.DisplayCanvas(0); });
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EndGame(); 
        }
#if UNITY_ANDROID
        if (Application.platform == RuntimePlatform.Android && (Input.GetKeyDown(KeyCode.Escape)))
        {
            EndGame();
        }
    }
#endif
    public void StartGame(string scene)
    {
        FileManager.SetScene(scene);
        OnGameStart?.Invoke();
    }
    public void EndGame()
    {
        nowDiaId = 0;
        OnGameEnd?.Invoke();
    }
}
