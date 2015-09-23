using UnityEngine;
using System.Collections;

public class DesCard : MonoBehaviour 
{
    public static DesCard _instance;
    public float showTime = 2f;

    private UISprite sprite;
    private float timer = 0;
    private bool isShow = false;
    private UILabel hpLabel;
    private UILabel harmLabel;

    void Awake()
    {
        _instance = this;
        sprite = this.GetComponent<UISprite>();
        //this.gameObject.SetActive(false);
        sprite.alpha = 0;
        hpLabel = this.transform.Find("hpLabel").GetComponent<UILabel>();
        harmLabel = this.transform.Find("harmLabel").GetComponent<UILabel>();
        if (harmLabel == null)
        {
            Debug.Log("null");
        }
    }

    void Update()
    {
        if (isShow)
        {
            timer += Time.deltaTime;
            if (timer > showTime)
            {
                sprite.alpha = 0;
                timer = 0;
                isShow = false;
            }
            else
            {
                sprite.alpha=(showTime - timer) / showTime;
            }
        }
    }

    public void ShowCard(string cardname)
    {
        this.gameObject.SetActive(true);
        sprite.spriteName = cardname;
        //iTween.FadeTo(this.gameObject,0,3f);
        sprite.alpha = 1;
        isShow = true;
        timer = 0; 

        string spriteName = sprite.spriteName;
        string[] str = spriteName.Split('_');
        int harm = int.Parse(str[2]);
        int hp = int.Parse(str[3]);

        harmLabel.text = harm + "";
        hpLabel.text = hp + "";
    }
}
