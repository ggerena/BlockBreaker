using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position-paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			// hace que la bola quede siempre relativa al paddle
			this.transform.position = paddle.transform.position + paddleToBallVector;
			
			// lanza la bola al hacer click con el mouse
			if(Input.GetMouseButtonDown(0)){
				print ("click");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f,10f);
			}
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f,0.2f));
		print (tweak);
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
		}
	}
	
}
