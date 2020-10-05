using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private Transform pfHealthBar;
    
    private HealthSystem healthSystem;
    [SerializeField] private GameObject enemyProjectile;
    [SerializeField] private Transform player;
    
    // Start is called before the first frame update
    void Start()
    {   
        healthSystem = new HealthSystem(100);
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(this.transform.position.x , (float)(this.transform.position.y + 0.5)), Quaternion.identity, this.transform);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);


        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        // methodName, time, and repeat rate
        InvokeRepeating("Fire", delay, rate);
    }

    // Update is called once per frame
    void Fire()
    {   
        var orientation = FindTarget();
        Debug.Log("finding player: " + FindTarget());
        if(orientation){
            Debug.Log("Player found, targeting player");
            Instantiate(enemyProjectile, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
        }
    }
    private bool FindTarget(){
        float targetRange = 10f;
        if(Vector3.Distance(transform.position, player.transform.position) < targetRange){
            return true;
        }
        return false;
    }

    public void DamageTaken(int damageAmount){
        healthSystem.Damage(damageAmount);
        if(isDead()) Destroy(this.gameObject);
    }

    private bool isDead(){
        if(healthSystem.GetHealthPercentage() == 0){
            return true;
        }
        return false;
    }
}
