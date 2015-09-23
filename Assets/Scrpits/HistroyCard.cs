using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HistroyCard : MonoBehaviour 
{
    public Transform inCard;
    public Transform outCard;
    public Transform card1;
    public Transform card2;
    public GameObject cardPrefab;

    private float yOffset;
    private List<GameObject> cardList = new List<GameObject>();

    void Start()
    {
        yOffset = card2.position.y - card1.position.y;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            StartCoroutine(AddCard());
        }
    }
    public IEnumerator AddCard()
    { 
        
       GameObject go= GameObject.Instantiate(cardPrefab,inCard.position,Quaternion.identity) as GameObject;
       yield return 0;
       go.transform.position =inCard.position;
       iTween.MoveTo(go,card1.position,1f );

       cardList.Add(go);
       if (cardList.Count > 7)
       {
           iTween.MoveTo(cardList[0], outCard.position, 1f);
           Destroy(cardList[0],2f);
           cardList.RemoveAt(0);
       }
       for (int i = 0; i < cardList.Count - 1; i++)
       {
           iTween.MoveTo(cardList[i],cardList[i].transform.position+new Vector3(0,yOffset,0),0.5f);
       }
    }


}
