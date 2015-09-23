using UnityEngine;
using System.Collections;

public class startmenu : MonoBehaviour {

    public MovieTexture movieTexture;
    public bool isDrawMov = true;
    public bool isShowMessage = false;

    public TweenScale logoTweenScale;

    public TweenPosition selectRoleTweenPosition;

    public UISprite hero1;

    private bool isCanShowSelectRole = false;//表示是否可以选择角色选择界面
	// Use this for initialization
	void Start () {
        movieTexture.loop = false;
        movieTexture.Play();
        logoTweenScale.AddOnFinished(this.OnLogoTweenFinished);
	}
	
	// Update is called once per frame
	void Update () {

        if (isDrawMov)
        {
            if (Input.GetMouseButtonDown(0) && isShowMessage == false)
            {
                isShowMessage = true;
            }
            else if (Input.GetMouseButtonDown(0) && isShowMessage == true)
            {
                StopMov();
            }
        }
        if (isDrawMov != movieTexture.isPlaying)
        {
            StopMov();
        }
        if (isCanShowSelectRole && Input.GetMouseButtonDown(0))
        { 
            //显示角色选择界面
            selectRoleTweenPosition.PlayForward();
            isCanShowSelectRole = false;
        }
	}

    void OnGUI()
    {
        if (isDrawMov)
        {
            GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),movieTexture);
            if (isShowMessage)
                GUI.Label(new Rect(Screen.width/2-100,Screen.height/2,200,40),"再点击一次屏幕退出动画的播放");
        }
    }

    private void StopMov()
    {
        movieTexture.Stop();
        isDrawMov = false;
        logoTweenScale.PlayForward();
    }

    private void OnLogoTweenFinished()
    {
        isCanShowSelectRole = true;
    }

    public void OnPlaybuttonClick()
    {
        Blackmask._instance.Show();
        string hero2SpriteName ="hero" + Random.Range(1, 10);
        NGUIDebug.Log(hero1.spriteName);
        VSShow._instance.Show(hero1.spriteName,hero2SpriteName);
        StartCoroutine(LoadPlayScene());
    }

    IEnumerator LoadPlayScene()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel(1);
    }
}
