using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MouseCtrl : MonoBehaviour
{

	public GameObject[] tile = new GameObject[25];
	public ButtonCtrl buttonScript;
	public UIManagerScript UIscript;
	public SceneManager sceneScript;

	public Vector3 PlayerPos;
	public string PlayerTag;
	public GameObject player;

	public bool isTrigger;
	public bool isPick;

	public Vector3 blueTarget;
	public Vector3 redTarget;
    
	public GameObject Object;

	public void Start()
	{
		isTrigger = false;
		isPick = false;

		blueTarget = tile[14].transform.position;
		blueTarget.y = 2;
		redTarget = tile[10].transform.position;
		redTarget.y = 2;
	}


	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit = Physics.RaycastAll(ray);

		for (int i = 0; i < hit.Length; i++)
		{
        
			if (hit[i].transform.tag == "Tile" && isTrigger && isPick
				&& hit[i].transform.GetComponent<Renderer>().material.color == Color.yellow)
			{ // 點擊後移動角色 
				if (Input.GetMouseButtonDown(0))
				{
					Vector3 TilePos = hit[i].transform.position;
					movePlayer(TilePos);

					isTrigger = false;
					isPick = false;
				}
			}
		}
	}

	public void movePlayer(Vector3 TilePos)
    {
        TilePos.y = 2;
        player.transform.position = TilePos;
        buttonScript.changeCard(buttonScript.order);
        for (int i = 0; i < 25; i++)
        {
            tile[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

	public void pickTile(){
		//遇到對方小兵，吃掉
        if (PlayerTag == "Player_blue")
        {
            for (int j = 0; j < 5; j++)
            {
				if (UIscript.player_red[j] != null){
					if (player.transform.position == UIscript.player_red[j].transform.position)
                    {
                        if (j != 2)
                        {
                            Debug.Log("blue same place");
							UIscript.player_red[j].gameObject.SetActive(false);
                        }
                        else if (j == 2)
                        {
                            Debug.Log("blue king");
							UIscript.player_red[2].SetActive(false);
							loadRestart();
						}
                    }
				}
            }

			if (player.transform.position == redTarget)
            {
				loadRestart();
			}
        }
        
        if (PlayerTag == "Player_red")
        {
            for (int j = 0; j < 5; j++)
			{
				if (UIscript.player_blue[j] != null){
					if (player.transform.position == UIscript.player_blue[j].transform.position)
                    {
                        if (j != 2)
                        {
                            Debug.Log("red same place");
							UIscript.player_blue[j].gameObject.SetActive(false);
                        }
                        else if (j == 2)
                        {
                            Debug.Log("red king");
							UIscript.player_blue[2].SetActive(false);
							loadRestart();
						}
                    }
				}
            }

			if (player.transform.position == blueTarget)
            {
				loadRestart();
			}
        }
	}

	public void pickPlayer() //點擊後角色後取得角色位置
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit[] hit = Physics.RaycastAll(ray);

		if (hit[0].transform.tag == "Player_blue" && !isPick)
		{
			isPick = true;
			PlayerTag = hit[0].transform.tag;

			player = hit[0].transform.gameObject;
			PlayerPos = player.gameObject.transform.position;
			Debug.Log(player.transform.name + PlayerPos);

			for (int j = 0; j < 5; j++)
			{
				if (buttonScript.Card[j] != null)
				{
					buttonScript.Card[j].GetComponent<Button>().enabled = true;
				}
			}
		}

		if (hit[0].transform.tag == "Player_red" && !isPick)
        {
			isPick = true;
			PlayerTag = hit[0].transform.tag;

            player = hit[0].transform.gameObject;
            PlayerPos = player.gameObject.transform.position;
			Debug.Log(player.transform.name + PlayerPos);

            for (int j = 0; j < 5; j++)
            {
                if (buttonScript.Card[j] != null)
                {
                    buttonScript.Card[j].GetComponent<Button>().enabled = true;
                }
            }
        }

		isTrigger = true;
	}

	public void loadGamePlay()
	{
		Object.SetActive(true);
	}

	public void loadRestart()
    {
        Object.SetActive(false);
		sceneScript.RestartCanvas.SetActive(true);
    }
}

