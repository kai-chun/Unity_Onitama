using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonCtrl : MonoBehaviour
{
	public UIManagerScript UIscript;

	public GameCard[] fiveCards = new GameCard[5];
	public GameObject[] Card = new GameObject[5];
	public Sprite[] card_pic;
	public GameObject button;
	public MouseCtrl mouseScript;
	public Vector3[] movePos = new Vector3[4];

	public int[] random = new int[12];
	public int order = -1;

	public void Start()
	{
		card_pic = Resources.LoadAll<Sprite>("Sprite/card");

		button.SetActive(true);

		for (int i = 0; i < 12; i++)
		{
			random[i] = i;
		}

		for (int i = 0; i < 5; i++)
		{
			Card[i].GetComponent<Button>().enabled = false;
		}

		for (int i = 0; i < 4; i++)
		{
			movePos[i] = new Vector3(-50, -50, -50);
		}

		for (int i = 0; i < 12; i++)
		{
			int r = Random.Range(0, 12);
			int temp = random[i];
			random[i] = random[r];
			random[r] = temp;
		}
	}

	public void dealCard()
	{

		for (int i = 0; i < 5; i++)
		{
			fiveCards[i] = CardsCtrl.cards[random[i]];
		}

		button.SetActive(false);

		reload(random);
	}

	public void reload(int[] order)
	{
		for (int i = 0; i < 5; i++)
		{
			Card[i].GetComponent<Image>().sprite = card_pic[random[i]];
			Card[i].GetComponent<Button>().enabled = false;
			int temp = random[i];
			Card[i].GetComponent<Button>().onClick.RemoveAllListeners();
			Card[i].GetComponent<Button>().onClick.AddListener(delegate { chooseCard(temp); });
		}
	}

	public void chooseCard(int index)
	{ // 點擊後取得卡牌資訊
		int[] count = new int[25];
		order = index;

		for (int i = 0; i < 4; i++)
		{
			movePos[i] = new Vector3(-50, -50, -50);
		}

		if (index >= 0)
		{
			Debug.Log(CardsCtrl.cards[index].cardName);

			// 角色可移動的位置tile改變顏色
			if (mouseScript.PlayerTag == "Player_blue")
			{
				for (int j = 0; j < CardsCtrl.cards[index].posMove.Length; j++)
				{
					movePos[j] = mouseScript.PlayerPos - CardsCtrl.cards[index].posMove[j];
					movePos[j].y = 0;
				}
			}
			else
			{
				for (int j = 0; j < CardsCtrl.cards[index].posMove.Length; j++)
				{
					movePos[j] = mouseScript.PlayerPos + CardsCtrl.cards[index].posMove[j];
					movePos[j].y = 0;
				}
			}

			for (int k = 0; k < 25; k++)
			{
				count[k] = 0;
				for (int w = 0; w < 4; w++)
				{
					if (mouseScript.tile[k].transform.position == movePos[w])
					{
						count[k]++;
					}
				}
                /*
				for (int j = 0; j < 5; j++)
				{
					if (mouseScript.PlayerTag == "Player_red")
					{
						if (mouseScript.PlayerPos == UIscript.player_red[j].transform.position)
						{
							count[k]--;
						}
					}
					else if (mouseScript.PlayerTag == "Player_blue")
					{
						if (mouseScript.PlayerPos == UIscript.player_blue[j].transform.position)
						{
							count[k]--;
						}
					}
				}*/
			}

			for (int i = 0; i < 25; i++)
			{
				if (count[i] > 0)
				{
					mouseScript.tile[i].GetComponent<Renderer>().material.color = Color.yellow;
				}
				else
				{
					mouseScript.tile[i].GetComponent<Renderer>().material.color = Color.white;
				}
			}
		}
	}

	public void changeCard(int index){
		int temp = index;
        for (int j = 0; j < 5; j++)
        {
            if (random[j] == index)
            {
                random[j] = random[2];
            }
        }
        random[2] = temp;
        //Debug.Log(temp);

		dealCard();
	}
}

 