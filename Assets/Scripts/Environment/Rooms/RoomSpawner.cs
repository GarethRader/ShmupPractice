using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{   
    [SerializeField] private int openingDirection;
    private RoomTemplate templates;
    private int rand;
    private bool spawned;
    void Start(){
        rand = 0;
        spawned = false;
        this.templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        if(!this.templates){
            Debug.Log("Templates not found");
        }
        Invoke("Spawn",2f);
    }
    
    

    private void SelfDestruct(){
        Destroy(this.gameObject);
    }
    private void Spawn(){

        if(!spawned){
            //Instantiate(templates.TestRoom, this.transform.position, templates.TestRoom.transform.rotation);
            if(openingDirection == 1){
                //Spawn room with TOP door
                rand = Random.Range(0, templates.numTopRooms);
                Instantiate(templates.GetTopRoomAtIndex(rand), this.transform.position, templates.GetTopRoomAtIndex(rand).transform.rotation);
            } else if(openingDirection == 2){
                //Spawn room with Bottom door
                rand = Random.Range(0, templates.numBottomRooms);
                Instantiate(templates.GetBottomRoomAtIndex(rand), this.transform.position, templates.GetBottomRoomAtIndex(rand).transform.rotation);
            } else if(openingDirection == 3){
                //Spawn room with Right door
                rand = Random.Range(0, templates.numRightRooms);
                Instantiate(templates.GetRightRoomAtIndex(rand), this.transform.position, templates.GetRightRoomAtIndex(rand).transform.rotation);
            } else if(openingDirection == 4){
                //Spawn room with Left door
                rand = Random.Range(0, templates.numLeftRooms);
                Instantiate(templates.GetLeftRoomAtIndex(rand), this.transform.position, templates.GetLeftRoomAtIndex(rand).transform.rotation);
            }
            spawned = true;
            this.SelfDestruct();
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false){
                //spawn walls blocking off any openings
                Debug.Log("Closed Room spawned ");
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        } 
        spawned = true;
    }


    
} 
