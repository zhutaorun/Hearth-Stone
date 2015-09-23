using UnityEngine;
using System.Collections;

public class Hero : MonoBehaviour 
{
    public int maxHp = 30;
    public int minHp = 0;

    protected UISprite sprite;
    private UILabel hpLabel;
    private int hpCount = 30;
    void Awake()
    {
        sprite = this.GetComponent<UISprite>();
        //string heroName = PlayerPrefs.GetString("hero1");
        //sprite.spriteName = heroName;

        hpLabel = this.transform.Find("hp").GetComponent<UILabel>();
    }
    //吸收伤害
    public void TakeDamage(int damage)
    {
        hpCount -= damage;
        hpLabel.text = hpCount + "";
        if (hpCount <= minHp)
        {
            //处理游戏结束的逻辑
        }
    }

    public void PlusHp(int hp)
    {
        hpCount += hp;
        if (hpCount >= maxHp)
        {
            hpCount = maxHp;
        }
        hpLabel.text = hpCount + "";

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            TakeDamage(Random.Range(1, 5));
        }
        if (Input.GetKey(KeyCode.R))
        {
            PlusHp(Random.Range(1, 5));
        }
    }
}
