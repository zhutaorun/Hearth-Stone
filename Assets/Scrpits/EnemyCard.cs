using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyCard : MonoBehaviour 
{
    public Transform cardOriginal;//用来存放卡牌存放的位置

    //存放所有的卡牌
    private List<GameObject> cardList = new List<GameObject>();

    public void AddCard(GameObject go)
    {
        go.transform.parent = this.transform;
        cardList.Add(go);
        iTween.MoveTo(go,cardOriginal.position,0.5f);
    }

    public void RemoveCard(GameObject go)
    {
        cardList.Remove(go);
    }

}
