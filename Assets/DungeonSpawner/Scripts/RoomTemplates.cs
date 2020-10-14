using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour {

	public GameObject[] bottomRooms;
	public GameObject[] topRooms;
	public GameObject[] leftRooms;
	public GameObject[] rightRooms;

	public GameObject closedRoom;

	public List<GameObject> rooms;

	public float waitTime;
	private bool spawnedBoss;
	public GameObject boss;
	private PlayerObjectScript player;
	private AudioClip gameMusic;
    private AudioSource gameMusicSound;
	private AudioSource bossMusic;
	void Start(){
		gameMusicSound = GetComponent<AudioSource>();
        gameMusicSound.Play();
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerObjectScript>();
	}
	void Update(){

		if(waitTime <= 0 && spawnedBoss == false && player.GetPoints() >=20){
			for (int i = 0; i < rooms.Count; i++) {
				if(i == rooms.Count-1){
					Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
					spawnedBoss = true;
				}
			}
		} else {
			waitTime -= Time.deltaTime;
		}
	}
}
