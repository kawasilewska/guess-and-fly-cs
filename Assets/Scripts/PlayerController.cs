using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

#region Variables

	//public float speed;

	private float moveVertical;
	
#endregion

	void FixedUpdate () {
		// normalizacja wartosci dmuchu od 0 do 1
		// p_param_OUT wartość spoczynkowa 75
		// minimalna wartosc dmuchu 85
		// maksymalna wartosc dmuchu 150
		// roznica 150-85=65
		// do zmiany przez terapeute w razie postepow

		int roznica = GameMaster.maxBlowStrength - GameMaster.minBlowStrength;

		int P = SerialController.p_param_OUT - GameMaster.minBlowStrength;
		float p = (float) P/roznica;
		if (p >= 0 && p <= 1) {
			moveVertical = p;
			GameMaster.btime += Time.fixedDeltaTime;
		} else if (p > 1){
			moveVertical = 1;
			GameMaster.btime += Time.fixedDeltaTime;
		} else if (p < 0) {
			moveVertical = 0;
		}
		Vector3 movement = new Vector3 (0.2f, moveVertical, 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement * GameMaster.speed;

		// Obsługa klawiatury
		// float moveVertical = Input.GetAxis("Vertical");
	}
}