﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Controller : MonoBehaviour {

	public enum Suit { Pin, Bamboo, Man, Wind, Dragon };
	public enum Pin { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Bamboo { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Man { one = 1, two, three, four, five, six, seven, eight, nine };
	public enum Wind { east, south, west, north };
	public enum Dragon { red, green, white };
	
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
			ShufflePool();
		}

		private Random rng = new Random(); 
		
		private void ShufflePool()  
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
		public List<Tile> draw(int num) {
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

		List<Tile> hand;
		Tile drawnTile;
		List<List<Tile>> melded;

		public Hand() {
			hand = pool.draw (13);
		}

		public void draw() {
			drawnTile = pool.draw (1)[0];
		}

		public Tile discard(int loc) {
			if (loc < 13) {
				Tile discard;
				discard = hand [loc];
				hand.RemoveAt (loc);
				hand.Add (drawnTile);
				return discard;
			} else {
				return drawnTile;
			}
		}

		public void printHand() {
			string handName = "";
			foreach (Tile t in hand) {
				handName = handName + " " + t.getTileName ();
			}
			handName = handName + " " + drawnTile.getTileName ();
			print (handName);
		}
	}

	public class Player {
		Hand hand;
		List<Tile> discard;

		public Player() {
			hand = new Hand();
			discard = new List<Tile>();
		}

	}
	//TODO: SET UP HAND AND LINK TO VIEW.

	// Use this for initialization
	void Start () {
		pool.printPool ();
		List<Tile> hand = pool.draw(13);
		string poolName = "";
		foreach (Tile t in hand) {
			poolName = poolName + " " + t.getTileName ();
		}
		print (poolName);
		pool.printPool ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
