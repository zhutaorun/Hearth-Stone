using UnityEngine;
using System.Collections;

public class Hero1Crystal : MonoBehaviour {

    public int usableNumber = 1;
    public int totalNumber = 1;
    public int maxNumber;
    public UISprite[] crystals;
    private UILabel label;

	// Use this for initialization
	void Awake() {
        maxNumber = crystals.Length;
        label = this.GetComponent<UILabel>();
	}

    void Start()
    {
        GameController._instance.OnNewRound += this.OnNewRound;
    }
    void UpdateShow() 
    {
        for (int i = totalNumber; i < maxNumber; i++)
        {
            crystals[i].gameObject.SetActive(false);
        }
        for (int i = usableNumber; i < totalNumber; i++)
        {
            crystals[i].spriteName = "TextInlineImages_normal";
        }
        for (int i = 0; i < usableNumber; i++)
        {
            if (i == 9)
            {
                crystals[i].spriteName = "TextInlineImages_" + (i + 1);
            }
            else
            {
                crystals[i].spriteName = "TextInlineImages_0" + (i + 1);
            }
        }
        label.text = usableNumber + "/" + totalNumber;
    }

    void Update()
    {
        UpdateShow();
    }

    public void RefreshCryStalNumber()
    {
        if (totalNumber < maxNumber)
        {
            totalNumber++;
        }
        usableNumber = totalNumber;
        UpdateShow();
    }

    public bool GetCryStal(int number) //消耗水晶的方法,返回值表示是否成功取得水晶
    {
        if (usableNumber >= number)
        {
            usableNumber -= number;
            UpdateShow();
            return true;
        }
        else//水晶不足的情况
        {
            return false;
        }
    }

    public void OnNewRound(string heroName)
    {
        if (heroName == "hero1")//说明回合转到hero1
        {
            RefreshCryStalNumber();//刷新水晶数量
        }
    }
}
