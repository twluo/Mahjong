using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	public string suit;
	public string value;

	void initializeTile(string suit, string value) {
		this.suit = suit;
		this.value = value;
		Start ();
	}
	// Use this for initialization
	void Start () {	
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
