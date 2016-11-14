using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnCollisionEnter2D(Collision2D conllision) {
		//print ("Collidion");
	}

	void OnTriggerEnter2D(Collider2D collider){
		//print ("Trigger");
		Brick.breakableCount = 0;
		levelManager.LoadLevel ("Loose_Screen");
	}
}
