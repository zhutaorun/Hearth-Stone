using UnityEngine;
using System.Collections;

public class CardGenerator: MonoBehaviour 
{
    public GameObject cardPrefab;
    public Transform fromCard;
    public Transform toCard;
    public string[] cardNames;

    public float transformTime = 2f;
    public int transformSpeed = 20;

    private bool isTramsforming = false;
    private float timer = 0;
    private UISprite nowGenerateCard;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomGenerCard();
        }

        if (isTramsforming)
        {
            timer += Time.deltaTime;
            int index =(int) (timer / (1f / transformSpeed));
            index %= cardNames.Length;//
            nowGenerateCard.spriteName = cardNames[index];
            if (timer > transformTime)
            { 
                //变换结束
                //随机生成一个卡牌名字
                string cardName = cardNames[Random.Range(0,cardNames.Length)];
                nowGenerateCard.spriteName = cardName;
                nowGenerateCard.GetComponent<Card>().InitProperty();
                timer = 0;
                isTramsforming = false;
            }
        }
    }
    public GameObject RandomGenerCard()
    {
        GameObject go = NGUITools.AddChild(this.gameObject,cardPrefab);
        go.transform.position = fromCard.position;
        nowGenerateCard = go.GetComponent<UISprite>();
        iTween.MoveTo(go, toCard.position, 1f);
        isTramsforming=true;
        return go;
    }
}
