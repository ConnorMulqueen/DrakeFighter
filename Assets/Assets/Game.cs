using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
    private float score;
    public GameObject enemy;

	void Start () {
        score = 0;
	}
    void Update() {
        if(Time.frameCount % 40 == 0) {
            Vector2 position = new Vector2(Random.Range(-10.0F, 10.0F), Random.Range(-10.0F, 10.0F));
            GameObject box = Instantiate(enemy, position, Quaternion.identity) as GameObject;
        }
    }
    public void addScore() {
        score += 10;
    }
    public float getScore() {
        return score;
    }
    public void EndGame() {
        //stub
    }
}
