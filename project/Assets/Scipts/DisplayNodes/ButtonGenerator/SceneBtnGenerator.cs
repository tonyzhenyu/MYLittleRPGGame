using QuickAnimate;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SceneBtnGenerator : BtnGenerator
{
    public int btncount;
    public AudioSource audiosource;

    public override void GenerateBtns()
    {
        ClearBtns();

        string[] items = GameManager.instance.FileManager.GetAllScene();
        btncount = items.Length;
        foreach (var item in items)
        {
            GameObject generateBtn = Instantiate(origin, content);

            generateBtn.name = item.Replace(".csv", "");
            generateBtn.tag = "Btn";

            //generateBtn.GetComponentInChildren<Text>().text = item.Replace(".csv", "");

            //设置文本

            Text titleText = generateBtn.transform.Find("title").GetComponent<Text>();
            Text contentText = generateBtn.transform.Find("content").GetComponent<Text>();

            titleText.text = item.Replace(".csv", "");
            contentText.text = "预览内容";

            //添加动画
            QuickAnimator quickAnimator = generateBtn.AddComponent<QuickAnimator>();
            quickAnimator.animaType.duration = 0.2f;
            quickAnimator.animaType.animationCurve.keys[0].outTangent = 2;
            quickAnimator.OnEvaluate += new QuickAnimator.QuickAnimationHandler(() => {
                generateBtn.transform.localScale = new Vector3(quickAnimator.animaType.value,1 , 1);
            });

            //添加跳转事件
            generateBtn.GetComponent<Button>().onClick.AddListener(
                () => {
                    GameManager.instance.StartGame(ResourcesPath + item);
                    UIManager.instance.DialogCanvas.GetComponent<DialogCanvas>().RefreashCanvas();
                    audiosource.Play();
            });
        }
    }
}
