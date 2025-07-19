using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using QuickAnimate;
public class DiaBtnGenerator : BtnGenerator
{
    public int nowid;
    public DialogCanvas dialogCanvas;
    public List<DiaNode> nowNodes;
    public AudioSource audiosource;

    public override void GenerateBtns()
    {
        ClearBtns();
        List<DiaNode> nowNodes = GameManager.instance.FileManager.NowNodes;
        int currentid = GameManager.instance.nowDiaId;

        foreach (var item in nowNodes[currentid].nextNode)
        {
            GameObject generateBtn = Instantiate(origin, content);

            generateBtn.name = item.ToString();
            generateBtn.tag = "Btn";

            generateBtn.GetComponentInChildren<Text>().text = nowNodes[item].ChoiceStr;

            //添加动画
            QuickAnimator quickAnimator = generateBtn.AddComponent<QuickAnimator>();
            quickAnimator.animaType.duration = 0.2f;
            quickAnimator.animaType.animationCurve.keys[0].outTangent = 2;
            quickAnimator.OnEvaluate += new QuickAnimator.QuickAnimationHandler(() => {
                generateBtn.transform.localScale = new Vector3(1, quickAnimator.animaType.value, 1);
            });

            //添加跳转事件
            generateBtn.GetComponent<Button>().onClick.AddListener(() => {

                GameManager.instance.nowDiaId = int.Parse(generateBtn.name);
                
                audiosource.Play();
                dialogCanvas.RefreashCanvas();
            });
        }
    }
}
