using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

	public bool autoPlay = false;
	public float minX = 0.64f;
	public float maxX = 15.3f;
	
	private Ball ball;
	
	void Start(){
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Use this for initialization
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	
	void AutoPlay(){
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, minX,maxX);
		this.transform.position = paddlePos;	
	}
	
	// Update is called once per frame
	void MoveWithMouse () {
		Vector3 paddlePos = new Vector3(0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, minX, maxX);
		this.transform.position = paddlePos;
	}
}
