using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {
	
	public void LoadScene (int level) {
		FadeInOut.LoadLevel(level, 1, 1, Color.black);
		//Application.LoadLevel(level);
	}
}
