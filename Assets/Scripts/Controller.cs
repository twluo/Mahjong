using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	public enum Suit { Pin, Bamboo, Man, Wind, Dragon };
	public enum Pin { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Bamboo { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Man { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Wind { east, south, west, north };
	public enum Dragon { red, green, white };

	private static Random rng = new Random(); 

	public static void Shuffle<T>(List<T> list)  
	{  
		int n = list.Count;  
		while (n > 1) {  
			n--;  
			int k = Random.Range (0,list.Count);  
			T value = list[k];  
			list[k] = list[n];  
			list[n] = value;  
		}  
	}

	public class Tile {
		Suit suit;
		Pin pin;
		Bamboo bamboo;
		Man man;
		Dragon dragon;
		Wind wind;

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
	}

	public List<Tile> pool = new List<Tile>();

	void initializePool() {
		foreach (Suit s in System.Enum.GetValues (typeof(Suit))) {
			switch(s) {
			case Suit.Pin:
				foreach (Pin p in System.Enum.GetValues (typeof(Pin))) {
					pool.Add (new Tile(s, p: p));
					pool.Add (new Tile(s, p: p));
					pool.Add (new Tile(s, p: p));
					pool.Add (new Tile(s, p: p));
				}
				break;
			case Suit.Bamboo:
				foreach (Bamboo b in System.Enum.GetValues (typeof(Bamboo))) {
					pool.Add (new Tile(s, b: b));
					pool.Add (new Tile(s, b: b));
					pool.Add (new Tile(s, b: b));
					pool.Add (new Tile(s, b: b));
				}
				break;
			case Suit.Man:
				foreach (Man m in System.Enum.GetValues (typeof(Man))) {
					pool.Add (new Tile(s, m: m));
					pool.Add (new Tile(s, m: m));
					pool.Add (new Tile(s, m: m));
					pool.Add (new Tile(s, m: m));
				}
				break;
			case Suit.Wind:
				foreach (Wind w in System.Enum.GetValues (typeof(Wind))) {
					pool.Add (new Tile(s, w: w));
					pool.Add (new Tile(s, w: w));
					pool.Add (new Tile(s, w: w));
					pool.Add (new Tile(s, w: w));
				}
				break;
			case Suit.Dragon:
				foreach (Dragon d in System.Enum.GetValues (typeof(Dragon))) {
					pool.Add (new Tile(s, d: d));
					pool.Add (new Tile(s, d: d));
					pool.Add (new Tile(s, d: d));
					pool.Add (new Tile(s, d: d));
				}
				break;
			}
		}
	}
	// Use this for initialization
	void Start () {
		initializePool();
		foreach (Tile t in pool) {
			t.printTile ();
		}
		Shuffle (pool);
		print (pool.Count);
		for (int i = 0; i < pool.Count; i++) {
			pool.RemoveAt(i);
			print (pool.Count);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
