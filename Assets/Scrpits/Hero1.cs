using UnityEngine;
using System.Collections;

public class Hero1 : Hero {
    
    void Start()
    {
        string heroName = PlayerPrefs.GetString("hero1");
        sprite.spriteName = heroName;
   }
}
