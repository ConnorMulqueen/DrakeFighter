using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    private float score;
	// Use this for initialization
	void Start () {
        score = 0;
	}

    // Update is called once per frame
    void Update() {

    }
    public void addScore() {
        score += 10;
    }
}
