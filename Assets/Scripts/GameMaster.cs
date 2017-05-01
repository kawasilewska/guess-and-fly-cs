using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

#region Variables

	public static string gameName = "Zgadnij_i_lec";

	public static float speed = 10;
	public static int minBlowStrength = 85;
	public static int maxBlowStrength = 150;
	public static string dateOfParameters;

	public static int level;
	public static int points1;
	public static int points2;
	public static int points3;
	public static int totalPoints;
	public static float time;
	public static float btime;

	public static bool isUIActive = false;
	public static bool gameoverstate = false;

	public static GameObject[] level1 = null;
	public static GameObject[] level2 = null;
	public static GameObject[] level3 = null;

	public static GameObject[] ui = null;
	public static GameObject[] questions = null;

#endregion

	public static void DestroyPlayer (Player player) {
		Destroy (player.gameObject);
	}
}