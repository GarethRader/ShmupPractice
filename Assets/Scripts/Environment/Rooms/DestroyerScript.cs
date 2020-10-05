using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other){
        Destroy(other.gameObject);
    }
    private void Start(){
        StartCoroutine(SelfDestruct());
    }

    private IEnumerator SelfDestruct(){
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

}
