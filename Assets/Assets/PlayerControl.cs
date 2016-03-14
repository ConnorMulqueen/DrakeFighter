using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    private float speed = 4f;
    private float hp = 100f;
    private Rigidbody2D playerRB;
    GameObject projectile;
    private bool disablePlayer = false;
    private float disablePlayerInitialFrame;
    private float canProjectile = 0;
    private float canJump = 0;
    private AudioSource[] aSources;
    private float specialMeter = 100f;
    private bool hotlinePowerUp = false;
    private float hotlinePowerUpLength = 7f;
    private float hotlinePowerUpInitialTime;
    private bool punching = false;
    private bool facingRight = true;

    void Start () {
        playerRB = this.GetComponent<Rigidbody2D>();
        aSources = this.GetComponents<AudioSource>();
        projectile = Resources.Load("Prefabs/dot") as GameObject;
    }
	
	void Update () {
        if (disablePlayer) {
            if (Time.frameCount - disablePlayerInitialFrame == 55) {
                disablePlayer = false;
            }
        }
        if(!disablePlayer) {
            Movement();
            Abilities();
            if(!facingRight) {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy") {
            if(hotlinePowerUp && hotlinePowerUpInitialTime + hotlinePowerUpLength > Time.time) {
                Destroy(col.gameObject);
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().addScore();
            }
            else {
                aSources[2].Play();
                hp -= 10f;
                Debug.Log("health: " + hp);
                playerRB.AddForce(Vector2.up * speed * 3400 * Time.deltaTime);
                if (hp == 0) {
                    aSources[3].Play();
                    GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Game>().EndGame();
                }
            }
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
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            facingRight = false;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
            this.transform.Translate(Vector2.down * speed * Time.deltaTime);
            facingRight = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.Translate(Vector2.right * speed * Time.deltaTime);
            facingRight = true;
        }
    }
    void Abilities() {
        if (Input.GetKey(KeyCode.C) && Time.frameCount > canProjectile) {
            Projectile();
        }
        if(Input.GetKey(KeyCode.Space) && !punching) {
            Punch();
        }
        if (Input.GetKey(KeyCode.X) && specialMeter == 100) {
            Hotline();
        }
    }
    void Projectile() {
        GameObject proj = Instantiate(projectile) as GameObject;
        if (facingRight) {
            proj.transform.position = playerRB.GetComponent<Rigidbody2D>().position + new Vector2(2, 0);
            proj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * speed * 9989 / 4 * Time.deltaTime);
        }
        else {
            proj.transform.position = playerRB.GetComponent<Rigidbody2D>().position + new Vector2(-2, 0);
            proj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * speed * 9989 / 4 * Time.deltaTime);
        }


        //TODO: Animation

       // disablePlayer = true;
        //disablePlayerInitialFrame = Time.frameCount;
        aSources[0].Play();
        Object.Destroy(proj, 1.7f);
        canProjectile = Time.frameCount + 40;
    }
    void Punch() {
        //stub
    }
    void Hotline() {
        //TODO: Animation (This animation has to be done right.)
        aSources[1].Play();
        specialMeter = 0f;
        hotlinePowerUp = true;
        hotlinePowerUpInitialTime = Time.time;
    }
    public void addSpecial() {
        if (specialMeter != 100f) {
            specialMeter += 10f;
        }
        Debug.Log("added special!");
    }
    public float getHealth() {
        return hp;
    }
    public float getSpecial() {
        return specialMeter;
    }
}
