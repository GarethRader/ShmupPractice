using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    public void Kill(){
        Destroy(this.gameObject);
    }
}
