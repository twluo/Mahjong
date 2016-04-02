using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
	
	// Use this for initialization
	void Start () {	
		
	}
	
	// Update is called once per frame
	void Update () {


	}
	void OnMouseDown() {
		transform.position += new Vector3(0,0.5f,0);
	}
	
	void onMouseUp() {
		transform.position += new Vector3(0,-0.5f,0);
	}
}
