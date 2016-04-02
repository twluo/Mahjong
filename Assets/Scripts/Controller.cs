﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	public GameObject tile;
	public enum Suit { Pin, Bamboo, Man, Wind, Dragon };
	public enum Pin { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Bamboo { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Man { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Wind { east, south, west, north };
	public enum Dragon { red, green, white };


	private static int compareSuit(Suit x, Suit y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static int comparePin(Pin x, Pin y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static int compareBamboo(Bamboo x, Bamboo y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static int compareMan(Man x, Man y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static int compareWind(Wind x, Wind y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static int compareDragon(Dragon x, Dragon y) {
		if (x < y)
			return -1;
		else if (x > y)
			return 1;
		else
			return 0;
	}
	private static void ShufflePool(List<Tile> pool)  
	{  
		int n = pool.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range (0,pool.Count);  
			Tile value = pool[k];  
			pool[k] = pool[n];  
			pool[n] = value;  
		}  
	}

	public class Tile {
		Suit suit;
		Pin pin;
		Bamboo bamboo;
		Man man;
		Dragon dragon;
		Wind wind;

		public Suit getSuit() {
			return suit;
		}

		public Pin getPin() {
			return pin;
		}

		public Bamboo getBamboo() {
			return bamboo;
		}

		public Man getMan() {
			return man;
		}

		public Dragon getDragon() {
			return dragon;
		}

		public Wind getWind() {
			return wind;
		}

		public Tile(Suit s, Pin p = Pin.one, Bamboo b = Bamboo.one, Man m = Man.one, Wind w = Wind.east, Dragon d = Dragon.red) {
			suit = s; 
			switch(suit) {
				case Suit.Pin:
					pin = p;
					break;
				case Suit.Bamboo:
					bamboo = b;
					break;
				case Suit.Man:
					man = m;
					break;
				case Suit.Wind:
					wind = w;
					break;
				case Suit.Dragon:
					dragon = d;
					break;
			}
		}

		public void printTile() {
			switch(suit) {
				case Suit.Pin:
					print ((int)pin + "p");
					break;
				case Suit.Bamboo:
					print ((int)bamboo + "b");
					break;
				case Suit.Man:
					print ((int)man + "m");
					break;
				case Suit.Wind:
					print (wind);
					break;
				case Suit.Dragon:
					print (dragon);
					break;
			}
		}

		public string getTileName() {
			switch (suit) {
				case Suit.Pin:
					return ((int)pin + "p");
				case Suit.Bamboo:
					return ((int)bamboo + "b");
				case Suit.Man:
					return ((int)man + "m");
				case Suit.Wind:
					return (wind.ToString());
				case Suit.Dragon:
					return (dragon.ToString ());
				default:
					return "";
			}
		}
	}

	public class Pool {

		List<Tile> pool;

		public Pool()	{
			initializePool();
			ShufflePool(pool);
		}

		public List<Tile> getPool() {
			return pool;
		}

		public void printPool() {
			string poolName = "";
			foreach (Tile t in pool) {
				poolName = poolName + " " + t.getTileName ();
			}
			print (poolName);
		}

		public List<Tile> drawTile(int num) {
			List<Tile> drawn = pool.GetRange (0, num);
			pool.RemoveRange (0, num);
			return drawn;
		}

		void initializePool() {
			pool = new List<Tile>();
			foreach (Suit s in System.Enum.GetValues (typeof(Suit))) {
				switch (s) {
				case Suit.Pin:
					foreach (Pin p in System.Enum.GetValues (typeof(Pin))) {
						pool.Add (new Tile (s, p: p));
						pool.Add (new Tile (s, p: p));
						pool.Add (new Tile (s, p: p));
						pool.Add (new Tile (s, p: p));
					}
					break;
				case Suit.Bamboo:
					foreach (Bamboo b in System.Enum.GetValues (typeof(Bamboo))) {
						pool.Add (new Tile (s, b: b));
						pool.Add (new Tile (s, b: b));
						pool.Add (new Tile (s, b: b));
						pool.Add (new Tile (s, b: b));
					}
					break;
				case Suit.Man:
					foreach (Man m in System.Enum.GetValues (typeof(Man))) {
						pool.Add (new Tile (s, m: m));
						pool.Add (new Tile (s, m: m));
						pool.Add (new Tile (s, m: m));
						pool.Add (new Tile (s, m: m));
					}
					break;
				case Suit.Wind:
					foreach (Wind w in System.Enum.GetValues (typeof(Wind))) {
						pool.Add (new Tile (s, w: w));
						pool.Add (new Tile (s, w: w));
						pool.Add (new Tile (s, w: w));
						pool.Add (new Tile (s, w: w));
					}
					break;
				case Suit.Dragon:
					foreach (Dragon d in System.Enum.GetValues (typeof(Dragon))) {
						pool.Add (new Tile (s, d: d));
						pool.Add (new Tile (s, d: d));
						pool.Add (new Tile (s, d: d));
						pool.Add (new Tile (s, d: d));
					}
					break;
				}
			}
		}
	}
	
	static Pool pool = new Pool();

	public class Hand {
		GameObject handContainer;
		
		List<Tile> hand;
		List<GameObject> handObjects;
		Tile drawnTile;
		List<List<Tile>> melded;
		GameObject tile;

		public Hand(GameObject p) {
			//TODO Change to find by tag and figure out optimal way to pass it down
			tile = (GameObject) Resources.Load ("tile");
			hand = pool.drawTile (13);
			handContainer = new GameObject();
			handContainer.name = "Hand";
			handContainer.transform.SetParent (p.transform);
			Vector3 size = tile.transform.localScale;
			Vector3 initialPos = new Vector3(0,size.y/2,0);
			Quaternion rotation = tile.transform.localRotation;
			for (int i = 0; i < 13; i++) {
				Vector3 spawnLocation = initialPos + new Vector3(i * size.x, 0, 0); 
				GameObject childTile = (GameObject) Object.Instantiate (tile, spawnLocation, rotation);
				childTile.transform.SetParent (handContainer.transform);
				childTile.transform.name = (""+i);
				childTile.SendMessage ("setTile", hand[i].getTileName ());
			}
		}

		public void draw() {
			drawnTile = pool.drawTile (1)[0];
			Transform lastTile = handContainer.transform.GetChild (handContainer.transform.childCount - 1);
			Vector3 spawnLocation = lastTile.position + new Vector3 (2 * tile.transform.localScale.x, 0, 0);
			GameObject childTile = (GameObject) Object.Instantiate (tile, spawnLocation, tile.transform.localRotation);
			childTile.transform.SetParent (handContainer.transform);
			childTile.transform.name = ("13");
			childTile.SendMessage ("setTile", drawnTile.getTileName ());
		}

		public Tile discard(int loc) {
			if (loc < 13) {
				Tile discard;
				discard = hand [loc];
				hand.RemoveAt (loc);
				hand.Add (drawnTile);
				drawnTile = null;
				GameObject d = handContainer.transform.GetChild (handContainer.transform.childCount - 1).gameObject;
				d.transform.SetParent (null);
				Destroy(d);
				discard.printTile ();
				this.sortHand ();
				this.updateHand ();
				this.printHand ();
				return discard;
			} else {
				GameObject d = handContainer.transform.GetChild (handContainer.transform.childCount - 1).gameObject;
				d.transform.SetParent (null);
				Destroy(d);
				return drawnTile;
			}
		}

		public void printHand() {
			string handName = "";
			foreach (Tile t in hand) {
				handName = handName + " " + t.getTileName ();
			}
			if (drawnTile != null)
				handName = handName + " " + drawnTile.getTileName ();
			print (handName);
		}

		public void sortHand() {
			hand.Sort (delegate(Tile x, Tile y) {
				if (x.getSuit () == y.getSuit ()) {
					switch (x.getSuit ()) {
						case Suit.Pin:
							return comparePin(x.getPin (),y.getPin ());
						case Suit.Bamboo:
							return compareBamboo(x.getBamboo (), y.getBamboo ());
						case Suit.Man:
							return compareMan(x.getMan (), y.getMan ());
						case Suit.Wind:
							return compareWind(x.getWind (), y.getWind ());
						case Suit.Dragon:
							return compareDragon(x.getDragon (), y.getDragon ());
					}
				}
				return compareSuit(x.getSuit (), y.getSuit ());
			});
		}

		public void updateHand() {
			print ("UPDATING");
			int i = 0;
			foreach (Transform child in handContainer.transform) {
				print (hand[i].getTileName ());
				child.SendMessage ("setTile", hand [i].getTileName ());
				i++;
			}
		}
	}

	public class Discard {
		List<Tile> discard;
		GameObject discardContainer;

		public Discard(GameObject p) {
			discard = new List<Tile>();
			discardContainer = new GameObject();
			discardContainer.name = "Discard";
			discardContainer.transform.SetParent (p.transform);
		}

		public void addDiscard(Tile t) {
			discard.Add (t);
			GameObject test = new GameObject ();
			test.name = t.getTileName ();
			test.transform.SetParent (discardContainer.transform);
		}

		public void printDiscard() {
			string discardName = "";
			foreach (Tile t in discard) {
				discardName = discardName + " " + t.getTileName ();
			}
			print (discardName);
		}
	}

	public class Player {
		Hand hand;
		Discard discard;
		int playerNum;
		GameObject parent;

		public Player(int num, GameObject p) {
			//hand = new Hand();
			parent = p;
			GameObject player = new GameObject();
			playerNum = num;
			player.name = "Player " + playerNum;
			player.transform.SetParent(parent.transform);
			discard = new Discard(player);
			hand = new Hand (player);
			hand.sortHand ();
			hand.updateHand ();
		}
		public void Draw() {
			hand.draw ();
		}

		public void Discard(int num) {
			Tile d = hand.discard (num);
			discard.addDiscard (d);
			hand.updateHand ();
		}

	}
	//TODO: SET UP HAND AND LINK TO VIEW.
	
	int stage = 0;
	Player p1;
	// Use this for initialization
	void Start () {
		GameObject controller = GameObject.Find ("Controller");
		p1 = new Player (1, controller);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			print("SPACE");
			if (stage == 0) {
				p1.Draw ();
				stage = 1;
			}
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			
			if (stage == 1) {
				p1.Discard (1);
				stage = 0;
			}
		}
	}
}
