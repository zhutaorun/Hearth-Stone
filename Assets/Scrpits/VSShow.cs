using UnityEngine;
using System.Collections;

public class VSShow : MonoBehaviour 
{
    public static VSShow _instance;

    public TweenScale vsTweenScale;
    public TweenPosition hero1Tween;
    public TweenPosition hero2Tween;
    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    void Start()
    {
        //Show("hero1","hero2");
    }

    public void Show(string hero1Name,string hero2Name)
    {
        this.gameObject.SetActive(true);
        PlayerPrefs.SetString("hero1", hero1Name);
        PlayerPrefs.SetString("hero2", hero2Name);
        Blackmask._instance.Show();
        hero1Tween.GetComponent<UISprite>().spriteName = hero1Name;
        hero2Tween.GetComponent<UISprite>().spriteName = hero2Name;
        vsTweenScale.PlayForward();
        hero1Tween.PlayForward();
        hero2Tween.PlayForward();

    }


	
}
