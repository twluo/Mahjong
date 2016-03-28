using UnityEngine;
using System.Collections;
using UnityEditor;

public class ApplyTexture : MonoBehaviour {
	Vector2 uv1 = new Vector2 (0.555f, 0.8f);
	Vector2 uv2 = new Vector2(0.666f, 0.8f);
	Vector2 uv3 = new Vector2(0.555f, 1.0f); 
	Vector2 uv4 = new Vector2(0.666f, 1.0f);

	void setTile(string tileName) {
		print (tileName [0]);
		float x;
		float y;
		if (tileName [1] == 'm')
			y = 0.6f;
		else if (tileName [1] == 'p')
			y = 0.4f;
		else if (tileName [1] == 'b')
			y = 0.2f;
		else
			y = 0.0f;
		if (tileName == "east")
			x = 0.0f;
		else if (tileName == "south")
			x = 0.111f;
		else if (tileName == "west")
			x = 0.222f;
		else if (tileName == "north")
			x = 0.333f;
		else if (tileName == "red")
			x = 0.444f;
		else if (tileName == "green")
			x = 0.555f;
		else if (tileName == "white")
			x = 0.666f;
		else
			x = (float)(char.GetNumericValue(tileName [0]) - 1) * 0.111f;
		uv1 = new Vector2 (x, y);
		uv2 = new Vector2 (x + 0.111f, y);
		uv3 = new Vector3 (x, y + 0.2f);
		uv4 = new Vector3 (x + 0.111f, y + 0.2f);
		
	}
	void ApplyTextureMap() {
		Mesh mesh = null;
		MeshFilter mf = GetComponent<MeshFilter>();
		if (mf != null)
			mesh = mf.mesh;
		
		if (mesh == null || mesh.uv.Length != 24) {
			Debug.Log("Script needs to be attached to built-in cube");
			return;
		}
		
		Vector2[] uvs = mesh.uv;
		
		// Back
		uvs[0]  = new Vector2(0.3333f, 0.8f);
		uvs[1]  = new Vector2(0.4444f, 0.8f);
		uvs[2]  = new Vector2(0.3333f, 1.0f);
		uvs[3]  = new Vector2(0.4444f, 1.0f);
		
		// Bottom
		uvs[8]  = new Vector2(0.444f, 0.8f);
		uvs[9]  = new Vector2(0.555f, 0.8f);
		uvs[4]  = new Vector2(0.444f, 1.0f);
		uvs[5]  = new Vector2(0.555f, 1.0f);
		
		// Front
		uvs[10] = uv1;
		uvs[11] = uv2;
		uvs[6]  = uv3;
		uvs[7]  = uv4;
		
		// Top
		uvs[12] = new Vector2(0.0f, 0.8f);
		uvs[14] = new Vector2(0.111f, 0.8f);
		uvs[15] = new Vector2(0.0f, 1.0f);
		uvs[13] = new Vector2(0.111f, 1.0f);                
		
		// Right
		uvs[16] = new Vector2(0.111f, 0.8f);
		uvs[18] = new Vector2(0.222f, 0.8f);
		uvs[19] = new Vector2(0.111f, 1.0f);
		uvs[17] = new Vector2(0.222f, 1.0f);    
		
		// Left
		uvs[20] = new Vector2(0.222f, 0.8f);
		uvs[22] = new Vector2(0.333f, 0.8f);
		uvs[23] = new Vector2(0.222f, 1.0f);
		uvs[21] = new Vector2(0.333f, 1.0f);    
		
		mesh.uv = uvs;
	}
	// Use this for initialization
	void Start () {
		ApplyTextureMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
