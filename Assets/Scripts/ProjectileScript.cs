using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }

    
    private IEnumerator Launch() {
        //yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        var orientation = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        orientation = orientation - this.transform.position;
        orientation.Normalize();
        rb.AddForce(orientation * speed);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag=="enemy"){
            return;
        }
        if(other.gameObject.tag =="Player"){
            Debug.Log("we hit the player");
            //Destroy(this.gameObject);
        }
        if(other.gameObject.tag =="wall"){
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other){
        
        if(other.gameObject.tag == "Enemy"){
            // award points
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        if(other.gameObject.tag =="wall"){
            Destroy(this.gameObject);
        }
    }
}
