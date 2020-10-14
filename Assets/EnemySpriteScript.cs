using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpriteScript : MonoBehaviour
{    void Update()
    {
        HandleOrientation();
    }

    private void HandleOrientation(){
        // this allows the player game object to rotate/aim according to mouse position
        // front of player sprite will always be facing towards the mouse cursor
        
            var playerObj = GameObject.FindGameObjectWithTag("Player");
            Vector2 direction = playerObj.transform.position - this.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            float speed = 2f;

            this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);
        
    }

    
}
