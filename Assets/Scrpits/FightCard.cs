using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FightCard : MonoBehaviour 
{
    public Transform card01;
    public Transform card02;

    private float xOffset = 0;//两个卡片之间在X轴上的偏移
    private List<GameObject> cardList = new List<GameObject>();


    void Start()
    {
        xOffset = card02.position.x - card01.position.x;
    }
    //用来添加卡牌，用来把卡牌放到战斗区域
    public void AddCard(GameObject go)
    {
        go.transform.parent = this.transform;
        cardList.Add(go);
        Vector3 targetPos = CalcPosition();
        iTween.MoveTo(go,targetPos,0.5f);
    }

    //这个方法用来计算新来的卡片位置
    Vector3 CalcPosition()
    {
        int index = cardList.Count;//表示新来的卡牌是第几个卡片，从1开始计数
        if (index % 2 == 0)
        {
            float myXoffset = (index / 2) * xOffset;
            Vector3 pos = new Vector3(card01.position.x - myXoffset, card01.position.y, card01.position.z);
            return pos;
        }
        else
        {
            float myXoffset = (index / 2) * xOffset;
            Vector3 pos = new Vector3(card01.position.x + myXoffset, card01.position.y, card01.position.z);
            return pos;

        }
    }

	
}
