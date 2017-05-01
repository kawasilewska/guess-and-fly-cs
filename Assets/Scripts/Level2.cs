using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Level2 : MonoBehaviour {

#region Variables
	
	public Transform cloudPrefab = null;
	public GameObject textLevel = null;
	public GameObject textPointsDigit = null;
	public GameObject textTimeDigit = null;
	
	private GameObject planeSprite = null;
	private Vector3 cloudPosition;
	
	private int timeLeft;

#endregion
	
	void Awake () {
		GameMaster.level = 2;
		GameMaster.points2 = 0;
		GameMaster.time = 60.0f;
		
		GameMaster.isUIActive = true;
		
		planeSprite = GameObject.Find("PlaneSprite");
	}

	void Start () {
		GameMaster.level2 = GameObject.FindGameObjectsWithTag ("Level 2");
		GameMaster.ui = GameObject.FindGameObjectsWithTag ("UI");

		Text textL = textLevel.GetComponent<Text> ();
		textL.text += GameMaster.level.ToString ();
	}

	void Update () {
		if (Time.timeScale == 1 && GameMaster.isUIActive) {
			GameMaster.time -= Time.deltaTime;
			timeLeft = (int) GameMaster.time;
			
			Text textP = textPointsDigit.GetComponent<Text> ();
			Text textT = textTimeDigit.GetComponent<Text> ();
			
			textP.text = GameMaster.points2.ToString ();
			textT.text = timeLeft.ToString ();
			
			if (GameObject.FindGameObjectWithTag ("Cloud") == null) {
				cloudPosition = new Vector3 (planeSprite.transform.position.x + Random.Range(21.0f, 25.0f), Random.Range(-3.5f, 4f), 0.0f);
				Transform clone = (Transform) Instantiate (cloudPrefab, cloudPosition, cloudPrefab.rotation);
				Destroy (clone.gameObject, 15.0f);
			}
		}
		
		if (timeLeft <= 0) {
			if (GameMaster.points2 < 3) {
				FadeInOut.LoadLevel("GameOver2", 1, 1, Color.black);
				//Application.LoadLevel("GameOver2");
			} else {
				FadeInOut.LoadLevel("Level2Score", 1, 1, Color.black);
				//Application.LoadLevel("Level2Score");
			}
		}
		
	}
}
