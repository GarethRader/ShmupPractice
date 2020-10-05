using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
   
   [SerializeField] private GameObject enemy;
   private static int enemyCount = 0;

   float randX, randY;

   Vector2 whereToSpawn;
   [SerializeField] private float spawnRate = 2f;
    float nextSpawn = 0f;
    private bool startSpawning = true;

    // Update is called once per frame
    void Update()
    {

        if(startSpawning==true && getCountEnemies()<=10){
            Debug.Log("Num enemies: " + enemyCount);
            SpawnEnemy();
        }
        
    }
    
    private int getCountEnemies(){
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemy");
        int count =0;
        foreach(GameObject entity in objs){
            count++;
        }
        enemyCount = count;
        return count;
    }

    private void SpawnEnemy(){
        if(Time.time > nextSpawn){
            nextSpawn = Time.time + spawnRate;
            randX = Random.Range(-5f, 5f);
            randY = Random.Range(-5f, 5f);
            whereToSpawn = new Vector2(randX, randY);
            Instantiate (enemy, whereToSpawn, Quaternion.identity);
            enemyCount++;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            Debug.Log("Collision detected");
            startSpawning = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            startSpawning = false;
        }
    }
}
