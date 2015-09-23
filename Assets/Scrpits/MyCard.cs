using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyCard : MonoBehaviour 
{
    public GameObject cardPrefab;
    public Transform card1;
    public Transform card2;

    private int startDepth=8;
    private float xOffset;
    private List<GameObject> cards = new List<GameObject>();

    void Start()
    {
        xOffset = card2.position.x - card1.position.x;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            AddCard();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            LoseCard();
        }
    }

    public string[] cardNames;
    public void AddCard(GameObject cardGo=null)
    {
        GameObject go = null;
        if (cardGo == null)
        {
            //如果这个方法没有传递过来卡片的话，就自己创建(测试时用)
            go = NGUITools.AddChild(this.gameObject, cardPrefab);
            go.GetComponent<UISprite>().spriteName = cardNames[Random.Range(0, cardNames.Length)];
        }
        else
        {
            go = cardGo;
            go.transform.parent = this.transform;
        }
        go.GetComponent<UISprite>().width = 80;
        go.GetComponent<Card>().ResetPos();
        Vector3 toPosition = card1.position + new Vector3(xOffset,0,0)*cards.Count;

        iTween.MoveTo(go,toPosition,1f);

        cards.Add(go);
        go.GetComponent<Card>().SetDepth(startDepth + (cards.Count-1)*2);

    }
    
    //卡牌出牌后，把这个卡牌移除管理交给FightCard管理
    public void RemoveCard(GameObject go)
    { 
        
    }
    public void LoseCard()
    {
        int index = Random.Range(0,cards.Count);
        Destroy(cards[index]);
        cards.RemoveAt(index);
        UpdateShow();
    }

   public void UpdateShow()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 toPosition = card1.position + new Vector3(xOffset, 0, 0) * i;
            iTween.MoveTo(cards[i], toPosition, 0.5f);
            cards[i].GetComponent<Card>().SetDepth ( startDepth + i*2);
        }
    }

}
