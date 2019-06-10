using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour {

	public GameObject[] player_red = new GameObject[5];
	public GameObject[] player_blue = new GameObject[5];

	public void Start () {
        
		for (int i = 0; i < 5; i++) {
			player_red[i].SetActive(true);
			player_red[i].transform.position = new Vector3(-22, 2, 17 - 11 * i);
			player_blue[i].SetActive(true);
            player_blue[i].transform.position = new Vector3(22, 2, 17 - 11 * i);
        }

	}

	void Update () {
		
	}

}
