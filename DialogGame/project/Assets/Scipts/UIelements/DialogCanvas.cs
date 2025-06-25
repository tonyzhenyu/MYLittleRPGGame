using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UICanvas/DialogCanvas")]
public class DialogCanvas : MonoBehaviour
{
    struct Constructor
    {
        public Text textId;
        public Text textDialog;

        public Image upponBG;
        public Image bottomBG;
        public Image background;

        public GameObject HealthContent;
        public DiaBtnGenerator btnGenerator;
    }
    Constructor constructor;

    private void Awake()
    {
        constructor = new Constructor();
        constructor.textId = transform.Find("MainBG/MainPatten/panel_uppon/panel_uppon/txt_id").GetComponent<Text>();
        constructor.HealthContent = transform.Find("MainBG/MainPatten/panel_uppon/panel_uppon/healthcontent").gameObject;
        constructor.textDialog = transform.Find("MainBG/MainPatten/panel_uppon/ScrollView/Content/txt_dialog").GetComponent<Text>();

        constructor.upponBG = transform.Find("MainBG/MainPatten/panel_uppon").GetComponent<Image>();
        constructor.bottomBG = transform.Find("MainBG/MainPatten/panel_bottom").GetComponent<Image>();
        constructor.background = transform.Find("MainBG").GetComponent<Image>();
        InitialBtn();
    }
    private void Start()
    {
        RefreashCanvas();
    }
    private void InitialBtn()
    {
        #region InitialButtonGenerator
        if (gameObject.GetComponent<DiaBtnGenerator>() == null)
            constructor.btnGenerator = gameObject.AddComponent<DiaBtnGenerator>();
        constructor.btnGenerator.dialogCanvas = this;
        constructor.btnGenerator.origin = Resources.Load<GameObject>(MyPathConfig.BTN_CHOICE);
        constructor.btnGenerator.content = constructor.bottomBG.transform;
        constructor.btnGenerator.ResourcesPath = MyPathConfig.ADB_SCENE_PATH;
        constructor.btnGenerator.audiosource = GameObject.Find("/SoundSystem/C01Sound").GetComponent<AudioSource>();
        #endregion
    }

    public void RefreashCanvas()
    {
        int currentNodeid = GameManager.instance.nowDiaId;
        List<DiaNode> diaNode = GameManager.instance.FileManager.NowNodes;
        string nodeName = diaNode[currentNodeid].nodeName;

        constructor.textId.text = $"{nodeName}\n<size=10>currentid:{currentNodeid}</size>";
        SetDialogText(currentNodeid, diaNode);

        constructor.btnGenerator.nowNodes = diaNode;
        constructor.btnGenerator.nowid = currentNodeid;

        constructor.btnGenerator.GenerateBtns();
    }

    private void SetDialogText(int currentNodeid, List<DiaNode> diaNode)
    {
        if (constructor.textDialog.gameObject.GetComponent<PrintTextAnimation>() == null)
        {
            PrintTextAnimation pta = constructor.textDialog.gameObject.AddComponent<PrintTextAnimation>();
            pta.str = diaNode[currentNodeid].dataStr;
        }
        else
        {
            PrintTextAnimation pta = constructor.textDialog.gameObject.GetComponent<PrintTextAnimation>();
            pta.str = diaNode[currentNodeid].dataStr;
        }
    }
}
