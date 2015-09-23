using UnityEngine;
using System.Collections;

public class Hero2 : Hero {
    void Start()
    {
  
        string heroName = PlayerPrefs.GetString("hero2");
        sprite.spriteName = heroName;
    }
    
}
