using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour 
{
    public int needCraystal;
    public int hp;
    public int harm;

    private UISprite sprite;
    private UILabel hpLabel;
    private UILabel harmLabel;

    private string CardName
    {
        get 
        {
            return sprite.spriteName;
        }
    }
    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
        hpLabel = transform.Find("hpLabel").GetComponent<UILabel>();
        harmLabel = transform.Find("harmLabel").GetComponent<UILabel>();
    }
    void OnPress(bool isPressed)
    {
        if (isPressed)
        {
            DesCard._instance.ShowCard(CardName);
        }
    }

    public void SetDepth(int depth)
    {
        sprite.depth = depth;
        hpLabel.depth = depth + 1;
        harmLabel.depth = depth + 1;
    }

    public void ResetPos()//更新血量和伤害的位置
    {
        harmLabel.GetComponent<UIAnchor>().enabled = true;
        hpLabel.GetComponent<UIAnchor>().enabled = true;
    }

    public void ResetShow()//更新血量和伤害的显示
    {
        harmLabel.text = harm + "";
        hpLabel.text = hp + "";
    }

    public void InitProperty()//初始化属性，
    {
        string spriteName = sprite.spriteName;
        //needCraystal = spriteName[5] - '0';
        //harm= spriteName[7]-'0';
        //hp=spriteName[9]-'0';
        //ResetShow();

        string[] str= spriteName.Split('_');
        needCraystal = int.Parse(str[1]);
        harm = int.Parse(str[2]);
        hp = int.Parse(str[3]);
        ResetShow();

    }
}
