﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject explosion;
    [SerializeField] private float speed = 3f;
    private Vector2 orientation;
    private Transform player;
    private void Start(){
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Launch");
    }
    
    private IEnumerator Launch(){
        Vector3 direction = FindTarget();
        if(direction != Vector3.zero){
            orientation = player.position - this.transform.position;
            orientation.Normalize();
            rb.AddForce(orientation * speed);
        }
        
        yield return null;
    }
    private Vector3 FindTarget(){
        float targetRange = 10f;
        if(Vector3.Distance(transform.position, player.transform.position) < targetRange){
            //Debug.Log("Player position: " + player.transform.position);
            return player.transform.position;
        }
        return Vector3.zero;
    }

    private void OnBecameInvisible(){
        Destroy(this.gameObject);
        //Debug.Log("Projectile Destroyed");
    }
    
    private void OnTriggerEnter2D(Collider2D collider){
        //Debug.Log("Collided");
        if(collider.tag == "Player"){
            //Debug.Log("Destroyed");
            Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            var player = collider.GetComponent<PlayerScript>().transform.parent;
            player.GetComponent<PlayerObjectScript>().DamageTaken(10);
            
        }
    }
}
