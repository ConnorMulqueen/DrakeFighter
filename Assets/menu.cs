using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
    private BoxCollider2D playButton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        playButton.onMouseDown()
	}
}
