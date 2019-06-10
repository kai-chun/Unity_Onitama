using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCard {
	public string cardName { get; set; }
	public Vector3[] posMove { get; set; }
    //public Color color;
    
	public GameCard(string cardName, Vector3[] posMove){
		this.cardName = cardName;
		this.posMove = posMove;
	}

	public void CardCanMove(){ //如果是可移動的位置 
		
		// item.transform.GetComponent<TileCtrl>() = true;
	}

	public void UseCard(){ //使用卡片，能夠移動
		
	}
}

