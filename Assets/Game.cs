using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    private float score;
    public GameObject enemy;

	void Start () {
        score = 0;
	}
    void Update() {
        
        if(Time.frameCount % Random.Range(100,105) == 0) { //Figure out something that makes the game progressively harder...
            GameObject box = Instantiate(enemy, new Vector2(0, Random.Range(6, 8)), Quaternion.identity) as GameObject;
        }
    }
    public void addScore() {
        score += 1;
    }
    public float getScore() {
        return score;
    }
    public void EndGame() {
        //stub
    }
}
