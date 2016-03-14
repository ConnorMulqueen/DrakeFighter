using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	void Update () {
        text.text = "Score: " + GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().getScore();
    }
}
