using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsCtrl : MonoBehaviour{

	public static GameCard[] cards = new GameCard[12];

	public void Start () {
        Vector3[] pos0 = { new Vector3(11, 0, 0), new Vector3(-11, 0, 0) };
        cards[0] = new GameCard("Bear", pos0);
        Vector3[] pos1 = { new Vector3(-11, 0, 11), new Vector3(0, 0, 11), new Vector3(11, 0, 11) };
        cards[1] = new GameCard("Dog", pos1);
        Vector3[] pos2 = { new Vector3(0, 0, -11), new Vector3(11, 0, -11), new Vector3(0, 0, 11), new Vector3(11, 0, 11) };
        cards[2] = new GameCard("Dragon", pos2);
        Vector3[] pos3 = { new Vector3(11, 0, -11), new Vector3(11, 0, 11), new Vector3(-11, 0, 0) };
        cards[3] = new GameCard("Rabbit", pos3);
        Vector3[] pos4 = { new Vector3(0, 0, -11), new Vector3(-11, 0, 11), new Vector3(0, 0, 11), new Vector3(11, 0, -11) };
        cards[4] = new GameCard("Rooster", pos4);
        Vector3[] pos5 = { new Vector3(-11, 0, -11), new Vector3(11, 0, -11), new Vector3(-11, 0, 11), new Vector3(11, 0, 11) };
        cards[5] = new GameCard("Sheep", pos5);
        Vector3[] pos6 = { new Vector3(11, 0, -11), new Vector3(11, 0, 0), new Vector3(11, 0, 11) };
        cards[6] = new GameCard("Horse", pos6);
        Vector3[] pos7 = { new Vector3(11, 0, -11), new Vector3(0, 0, -11), new Vector3(-11, 0, -11) };
        cards[7] = new GameCard("Monkey", pos7);
        Vector3[] pos8 = { new Vector3(0, 0, -22), new Vector3(11, 0, 0), new Vector3(0, 0, 22) };
        cards[8] = new GameCard("Mouse", pos8);
        Vector3[] pos9 = { new Vector3(11, 0, 0), new Vector3(-11, 0, -11), new Vector3(-11, 0, 11) };
        cards[9] = new GameCard("Snake", pos9); 
		Vector3[] pos10 = { new Vector3(22, 0, 0) };
        cards[10] = new GameCard("Tiger", pos10);
		Vector3[] pos11 = { new Vector3(11, 0, 0), new Vector3(0, 0, 11), new Vector3(0, 0, -11)};
        cards[11] = new GameCard("Ox", pos11);
    }

    void Update() {
        
    }
}
