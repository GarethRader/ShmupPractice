using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    [SerializeField] private GameObject[] topRooms;
    [SerializeField] private GameObject[] bottomRooms;
    [SerializeField] private GameObject[] rightRooms;
    [SerializeField] private GameObject[] leftRooms;
    public int numTopRooms{protected set; get;}
    public int numBottomRooms{protected set;  get;}
    public int numRightRooms{protected set; get;}
    public int numLeftRooms{protected set; get;}

    //public List<GameObject> rooms;

    public GameObject closedRoom;
    //public List<GameObject> rooms;

    //[SerializeField] float waitTime;
    //private bool spawnedBoss;
    //public GameObject boss;

    //private void Update(){
    //    if(waitTime<=0 && !spawnedBoss){
    //        for(int i = 0; i< rooms.Count; i++){
    //            if(i==rooms.Count-1){
    //                Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
    //                spawnedBoss = true;
    //            }
    //        }
    //    }else{
    //        waitTime -= Time.deltaTime;
    //    }
    //}
    private void Awake(){
        numTopRooms = topRooms.Length;
        numBottomRooms = bottomRooms.Length;
        numRightRooms = rightRooms.Length;
        numLeftRooms = leftRooms.Length;
    }
    public GameObject GetTopRoomAtIndex(int index){
        return topRooms[index];
    }
    public GameObject GetBottomRoomAtIndex(int index){
        return bottomRooms[index];
    }
    public GameObject GetRightRoomAtIndex(int index){
        return rightRooms[index];
    }
    public GameObject GetLeftRoomAtIndex(int index){
        return leftRooms[index];
    }

}
