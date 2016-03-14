using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private BoxCollider2D box2d;
    private int hp = 30;
    private float speed = 4f;

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Projectile") {
            hp -= 15;
            Destroy(col.gameObject);
        }
        if (hp == 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().addSpecial();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().addScore();
            Destroy(this.gameObject);
        }
    }
    void Update() {
        Movement();
    }
    void Movement() {
        //TODO: Make this movement actually good somehow
       transform.Translate(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.position * speed * Time.deltaTime);
    }
}
