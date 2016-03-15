using UnityEngine;
using System.Collections;

public class goldenBox : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().addScore(10);
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().goldBoxOnMap = false;
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().addSpecial(20f);
            Destroy(this.gameObject);
        }
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
