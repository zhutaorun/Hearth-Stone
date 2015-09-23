using UnityEngine;
using System.Collections;


public enum GameState
{ 
    CardGenerating,//系统随机发放卡牌阶段
    PlayCard,//出牌对战阶段
    End//游戏结束阶段
}
public class GameController : MonoBehaviour 
{
    public static GameController _instance;
    public GameState gameState = GameState.CardGenerating;

    public float cycleTime = 60f;
    public MyCard myCard;
    public EnemyCard enemyCard;

    public int roundIndex = 0;//表示流转次数，当前的回合数
    public delegate void OnNewRoundEvent(string heroName);//当前回合（控制方，发牌方）转变的时候
    public event OnNewRoundEvent OnNewRound;

    private UISprite wickpopeSprite;
    private float timer = 0;
    private float wickpopeLength;
    private string currentHeroName = "hero1";//当前回合的英雄
    private CardGenerator cardGenerator;


    void Awake()
    {
        _instance = this;
        wickpopeSprite = this.transform.Find("wickpope").GetComponent<UISprite>();
        wickpopeLength=wickpopeSprite.width;
        wickpopeSprite.width=0;
        this.cardGenerator = this.GetComponent<CardGenerator>();
        StartCoroutine(GenerateCardForHero1());
    }

    void Update()
    {
        if(gameState==GameState.PlayCard)//游戏状态为对战的时候，才开始计时
        {
            timer+=Time.deltaTime;
            if(timer>cycleTime)
            {
                //强制结束当前回合，进行下一个回合
                TransformPlayer();
            }
            else if((cycleTime-timer)<15)//如果当前时间小于15秒，我们就要显示绳子动画
            {
                wickpopeSprite.width=(int)(((cycleTime-timer)/15f)*wickpopeLength);
            }
            
        }
    }

    public void TransformPlayer()//转变发牌方
    {
        timer = 0;
        if (currentHeroName == "hero1")
        {
            currentHeroName = "hero2";
        }
        else
        {
            currentHeroName = "hero1";
        }
        roundIndex++;
        OnNewRound(currentHeroName);

        //给当前回合英雄发牌
        if (roundIndex >= 2)
        {
            StartCoroutine(DealCard());
        }
    }
    //处理每回合的发牌
    IEnumerator DealCard()
    {
        gameState = GameState.CardGenerating;
        if (currentHeroName == "hero1")
        {
            GameObject cardGo = cardGenerator.RandomGenerCard();//调用方法生成一个随机卡牌//等2秒
            yield return new WaitForSeconds(2f);
            //把这个卡片放在卡牌管理器内
            myCard.AddCard(cardGo);

            cardGo = cardGenerator.RandomGenerCard();//调用方法生成一个随机卡牌//等2秒
            yield return new WaitForSeconds(2f);
            //把这个卡片放在卡牌管理器内
            enemyCard.AddCard(cardGo);
        }
        else
        {
            GameObject cardGo = cardGenerator.RandomGenerCard();//调用方法生成一个随机卡牌//等2秒
            yield return new WaitForSeconds(2f);
            //把这个卡片放在卡牌管理器内
            enemyCard.AddCard(cardGo);
        }

        gameState = GameState.PlayCard;
        timer = 0;
    }

    private IEnumerator GenerateCardForHero1()
    { 
        //最开始发牌是4张牌
        GameObject cardGo= cardGenerator.RandomGenerCard();//调用方法生成一个随机卡牌//等2秒
        yield return new WaitForSeconds(2f);
        //把这个卡片放在卡牌管理器内
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        myCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();//调用方法生成一个随机卡牌//等2秒
        yield return new WaitForSeconds(2f);
        //把这个卡片放在卡牌管理器内
        enemyCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        enemyCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        enemyCard.AddCard(cardGo);

        cardGo = cardGenerator.RandomGenerCard();
        yield return new WaitForSeconds(2f);
        enemyCard.AddCard(cardGo);

        gameState = GameState.PlayCard;
        timer = 0;
    }
}
     
           