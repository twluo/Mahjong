using UnityEngine;
using System.Collections;

public class CreateWall : MonoBehaviour {
	public GameObject tile;
	// Use this for initialization
	void Start () {
		if (GetComponent<MeshFilter>())
		{
			Destroy(GetComponent <MeshFilter>());
		}
		if (GetComponent<MeshRenderer>())
		{
			Destroy(GetComponent <MeshRenderer>());
		}
		Vector3 initialPos = transform.position;
		Vector3 size = tile.transform.localScale;
		initialPos.y += size.z / 2;
		for (int x = -9; x < 9; x++) {
			for (int y = 0; y < 2; y++) {
				Vector3 spawnLocation = initialPos - new Vector3(x * size.x, -y * size.z, 0); 
				GameObject childTile = (GameObject) Object.Instantiate (tile, spawnLocation, Quaternion.Euler (-90, 0, 0));
				childTile.transform.SetParent (this.transform);
				childTile.transform.name = (x+9) + "-" + y;
				childTile.SendMessage ("changeTexture", "test");
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
