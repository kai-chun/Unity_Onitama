using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public GameObject MenuCanvas;
    public GameObject RestartCanvas;

	public MouseCtrl mouseScript;
	public ButtonCtrl buttonScript;
	public UIManagerScript UIscript;
	public CardsCtrl cardScript;

	void Start () {
        mouseScript.Object.SetActive(false);
		MenuCanvas.SetActive(true);
	}
	
	void Update () {
		
	}

	public void GameStart()
    {
		MenuCanvas.SetActive(false);
		mouseScript.loadGamePlay();
    }

	public void Restart()
	{
        RestartCanvas.SetActive(false);

		mouseScript.loadGamePlay();

		mouseScript.Object.SetActive(true);
		mouseScript.Start();
		buttonScript.Start();
		UIscript.Start();
		cardScript.Start();
	}
}
