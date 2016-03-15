using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    static public float score;
    public GameObject enemy;
    public GameObject goldBox;
    public bool goldBoxOnMap = false;
    private int x;

	void Start () {
        score = 0;
	}
    void Update() {
        if(Time.frameCount % Random.Range(100,105) == 0) { //Figure out something that makes the game randomly progressively harder...
            GameObject box = Instantiate(enemy, new Vector2(0, Random.Range(6, 8)), Quaternion.identity) as GameObject;
        }
        if(Time.frameCount % 200 == 0 && goldBoxOnMap == false) {
            x = Random.Range(1, 4);
            Debug.Log(x);
            if (x == 1) {
                GameObject goldenBox = Instantiate(goldBox, new Vector2(-8,2), Quaternion.identity) as GameObject;
            }
            else if (x == 2) {
                GameObject goldenBox = Instantiate(goldBox, new Vector2(0, -2), Quaternion.identity) as GameObject;
            }
            else if (x ==3) {
                GameObject goldenBox = Instantiate(goldBox, new Vector2(8, 2), Quaternion.identity) as GameObject;
            }
            goldBoxOnMap = true;
            
        }
    }
    public void addScore(int x) {
        score += x;
    }
    public float getScore() {
        return score;
    }
    public void EndGame() {
        SceneManager.LoadScene("GameOver");
    }
}
