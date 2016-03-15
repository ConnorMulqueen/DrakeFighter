using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreGameOver : MonoBehaviour {
    Text text;

    void Start() {
        text = GetComponent<Text>();
    }
    void Update() {
        text.text = "" + Game.score;
    }
}
