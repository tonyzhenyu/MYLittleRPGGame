using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UICanvas/SceneCanvas")]
public class SceneCanvas : MonoBehaviour
{
    struct Constructor
    {
        public Image        BG;
        public Text         TitleText;
        public Transform   SceneContent;
        public RectTransform contentrect;
        public GameObject   Btn;
        public SceneBtnGenerator btnGenerator;
    }
    Constructor constructor;

    
    private void Awake()
    {
        constructor              = new Constructor();
        constructor.BG           = gameObject.transform.Find("panel_bg").GetComponent<Image>();
        constructor.TitleText    = gameObject.transform.Find("panel_bg/panel_main/panel_uppon/txt").GetComponent<Text>();
        constructor.SceneContent = gameObject.transform.Find("panel_bg/panel_main/scrollview/Viewport/SceneContent");
        constructor.Btn          = Resources.Load(MyPathConfig.BTN_SCENE) as GameObject;

        constructor.contentrect = constructor.SceneContent.gameObject.GetComponent<RectTransform>();

        #region InitialButtonGenerator
        if (gameObject.GetComponent<SceneBtnGenerator>() == null) 
            constructor.btnGenerator = gameObject.AddComponent<SceneBtnGenerator>();

        constructor.btnGenerator.origin = constructor.Btn;
        constructor.btnGenerator.content = constructor.SceneContent.transform;
        constructor.btnGenerator.ResourcesPath = MyPathConfig.ADB_SCENE_PATH;
        constructor.btnGenerator.audiosource = GameObject.Find("/SoundSystem/S02Sound").GetComponent<AudioSource>();
        #endregion
    }
    private void Start()
    {
        UIManager.instance.ScenePanel = gameObject;
    }
    private void OnEnable()
    {
        RefreashCanvas();
    }
    public void RefreashCanvas()
    {

        const int ChildrendHeight = 30 + 40;

        constructor.btnGenerator.GenerateBtns();
        constructor.contentrect.sizeDelta = new Vector2(0, ChildrendHeight * constructor.btnGenerator.btncount);
    }
}
