using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool isAutoPlay = false;

	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isAutoPlay) {
			MoveWithMouse();
		} else {
			AutoPlay();
		}

		if (Input.GetKeyDown(KeyCode.A)) {
			isAutoPlay = !isAutoPlay;
		}
	}

	void AutoPlay(){
		Vector3 ballPos = ball.transform.position;
		Vector3 temp = new Vector3 (Mathf.Clamp(ballPos.x, 1f, 15f), transform.position.y, 0f);
		this.transform.position = temp;
	}

	void MoveWithMouse(){
		Vector3 temp = new Vector3 (0.5f, this.transform.position.y, 0f);
		float curX = Mathf.Clamp(Input.mousePosition.x / Screen.width * 16, 1f, 15f);
		temp.x = curX;
		this.transform.position = temp;
	}


}
