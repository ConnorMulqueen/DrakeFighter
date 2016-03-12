using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private float speed = 4f;
    private int hp = 100;
    private Rigidbody2D playerRB;
    GameObject projectile;
    private bool disablePlayer = false;
    private float disablePlayerInitialFrame;
    private float canProjectile = 0;
    private float canJump = 0;
    private AudioSource[] aSources;
    private int specialMeter = 0;

    // Use this for initialization
    void Start () {
        playerRB = this.GetComponent<Rigidbody2D>();
        aSources = this.GetComponents<AudioSource>();
        projectile = Resources.Load("Prefabs/dot") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (disablePlayer) {
            if (Time.frameCount - disablePlayerInitialFrame == 55) {
                disablePlayer = false;
            }
        }
        if(!disablePlayer) {
            Movement();
            Abilities();
        }
	}
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy") {
            hp -= 10;
            Debug.Log("health: " + hp);
        }
    }
    void Movement() {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
            if(Time.frameCount > canJump) {
                playerRB.AddForce(Vector2.up * speed * 3400 * Time.deltaTime);
                canJump = Time.frameCount + 70;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    void Abilities() {
        if (Input.GetKey(KeyCode.C) && Time.frameCount > canProjectile) {
            Projectile();
        }
        if (Input.GetKey(KeyCode.X) && specialMeter == 100) {
            Hotline();
        }
    }
    void Projectile() {
        GameObject proj = Instantiate(projectile) as GameObject;
        proj.transform.position = playerRB.GetComponent<Rigidbody2D>().position + new Vector2(2, 0);
        proj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 9989 / 4 * Time.deltaTime);

        //TODO: Animation

        disablePlayer = true;
        disablePlayerInitialFrame = Time.frameCount;
        aSources[0].Play();
        Object.Destroy(proj, 1.7f);
        canProjectile = Time.frameCount + 40;
    }
    void Hotline() {
        //TODO: Animation (This animation has to be done right.)
        aSources[1].Play();
    }
    public void addSpecial() {
        if (specialMeter != 100) {
            specialMeter += 10;
        }
        Debug.Log("added special!");
    }
}
