using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos, yPos;

    public float playerSpeed, rotateVelocity;
    public float      speed = .05f;
    public float      leftWall, rightWall, topWall, bottomWall;

    public float health =1f;
    public Image healthBar;

    public GameObject projectile;
    public KeyCode fireKey;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= playerSpeed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += playerSpeed;
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if(xPos > leftWall){
                xPos -= playerSpeed;
            }
        }
        if (Input.GetKey(KeyCode.RightArrow)){
            if(xPos < rightWall){
                xPos += playerSpeed;
            }
        }
        // to allow rotating paddle for different angles
        if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)){
            this.transform.Rotate(new Vector3 (0 ,0, rotateVelocity ));
            //Debug.Log("rotating");
            if(this.transform.rotation == Quaternion.Euler(0,0,180)){
                this.transform.Rotate(Vector3.zero);
            }
        }
        if(Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)|| Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow)){
            this.transform.Rotate(new Vector3 (0, 0, -1 * rotateVelocity));
            if(this.transform.rotation == Quaternion.Euler(0,0,-180)){
                this.transform.Rotate(Vector3.zero);
            }
        }
        if(Input.GetKeyDown(fireKey)){
            //instantiate bullet prefab
            Instantiate(projectile, new Vector2(this.transform.position.x, this.transform.position.y + .5f), Quaternion.identity);

        }
        transform.localPosition = new Vector3(xPos, transform.position.y, 0);
    }

    private void OnTriggerenter2D(Collision2D other){
        if(other.gameObject.tag =="enemyPrjectile"){
            Destroy(other.gameObject);
            health -= 0.1f;
            healthBar.fillAmount = health;
        }
        
    }
}

