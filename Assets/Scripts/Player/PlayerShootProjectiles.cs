using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootProjectiles : MonoBehaviour
{
    //private Vector3 shootDir;

    //public void Setup(Vector3 shootDir){
    //    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //    float moveSpeed = 2f;
    //    rb.AddForce(shootDir * moveSpeed, ForceMode2D.Impulse);
    //}

    private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;
    
    [SerializeField] private float speed = 5f;
    
    
    private void Start(){
        
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }

    private IEnumerator Launch(){
        var orientation = Camera.main.ScreenToWorldPoint (new Vector3 (Input.mousePosition.x, Input.mousePosition.y, this.transform.position.z));
        orientation = orientation - this.transform.position;
        orientation.Normalize();
        rb.AddForce(orientation * speed);
        yield return null;
    }

    private void OnBecameInvisible(){
        Destroy(this.gameObject);
        //Debug.Log("Projectile Destroyed");
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("Collided");
        if(collider.tag == "Wall"){
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        Target target = collider.GetComponent<Target>();
        if(target){
            //Debug.Log("Destroyed");
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            collider.GetComponent<EnemyScript>().DamageTaken(34);
        }
    }
}
