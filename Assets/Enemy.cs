using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    private BoxCollider2D box2d;
    private Rigidbody2D rig2d;
    private int hp = 30;
    private float speed = 4f;
    private bool movementLeft = false;
    

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Projectile") {
            hp -= 15;
            Destroy(col.gameObject);
        }
        if(col.tag == "Map" || col.tag == "Enemy") {
            movementLeft = !movementLeft;
        }
        if (hp == 0) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>().addSpecial();
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().addScore();
            Destroy(this.gameObject);
        }
    }
    void Start() {
        if (transform.position == new Vector3(0,6,0)) {
            movementLeft = true;
        }
    }
    void Update() {
        if(movementLeft) {
            MovementLeft();
        }
        else {
            MovementRight();
        }
    }
    void MovementRight() {
        //TODO: Make this movement actually good somehow
        //transform.Translate(GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>().transform.position * speed * Time.deltaTime);
        this.transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    void MovementLeft() {
        this.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
