using UnityEngine;
using System.Collections;

public class DragableCard : UIDragDropItem
{
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if (surface!=null&&surface.tag == "FightCard")
        {
            //拖拽到了可发牌区域
            //首先需要得到需要的水晶数够不够
            Debug.Log("o");
            int needCrystal = this.GetComponent<Card>().needCraystal;
            Debug.LogError(needCrystal);
            Hero1Crystal hero1CryStal = GameObject.Find("hero1_crystal").GetComponent<Hero1Crystal>();
            bool isSuccess = hero1CryStal.GetCryStal(needCrystal);

            //如果够，可以出牌
            if (isSuccess)
            {
                Debug.Log("22");
                this.transform.parent.GetComponent<MyCard>().RemoveCard(this.gameObject);
                surface.GetComponent<FightCard>().AddCard(this.gameObject);
            }
            else//如果不够，不可以出牌
            {
                Debug.Log("11");
                transform.parent.GetComponent<MyCard>().UpdateShow();
            }
        }
        else
        {
            transform.parent.GetComponent<MyCard>().UpdateShow();
        }

    }
}
