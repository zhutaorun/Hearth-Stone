using UnityEngine;
using System.Collections;

public class Blackmask : MonoBehaviour 
{
    public static Blackmask _instance;
    void Awake()
    {
        _instance = this;
        this.gameObject.SetActive(false);
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
