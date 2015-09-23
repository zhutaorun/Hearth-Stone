using UnityEngine;
using System.Collections;

public class EndButton : MonoBehaviour 
{
    private UILabel label;

    void Awake()
    {
        label = transform.Find("Label").GetComponent<UILabel>();
    }

    void Start()
    {
        GameController._instance.OnNewRound += this.OnNewRound;
    }
    public void OnEndButtonClick()
    {
        if (label.text == "结束回合")
        {
            label.text = "对方回合";
            GameController._instance.TransformPlayer();
        }
    }

    public void OnNewRound(string heroName)
    {
        if (heroName == "hero1")
        {
            label.text = "结束回合";
        }
    }
}
