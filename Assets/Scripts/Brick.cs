using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public GameObject smoke;

	private int timeHits;
	private LevelManager levelManager;
	private bool breakable;


	// Use this for initialization
	void Start () {
		breakable = this.tag == "Breakable";
		levelManager = GameObject.FindObjectOfType<LevelManager> ();

		if (breakable) {
			breakableCount++;
		}

		timeHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D conllision) {
		if (breakable) {
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.8f);
			HandleHits ();
		}
	}

	void HandleHits() {
		timeHits++;
		int maxHits = hitSprites.Length + 1;
		if (timeHits >= maxHits) {
			breakableCount--;

			GameObject puffSmoke = Instantiate (smoke, this.transform.position, Quaternion.identity) as GameObject;
			puffSmoke.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;

			levelManager.BrickDestroyed();
			//print (breakableCount);
			Destroy (gameObject);
		} else {
			LoadSprite();
		}
	}

	void LoadSprite() {
		int spriteIndex = timeHits - 1;
		this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
