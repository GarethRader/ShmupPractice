using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private Transform pfHealthBar;
    
    private HealthSystem healthSystem;
    [SerializeField] private GameObject enemyProjectile;
    private Transform player;
    [SerializeField] private Firepoint firepoint;
    private UnityEngine.AI.NavMeshPath path;
    private Rigidbody2D rb;
    private bool playerInSight;
    
    // Start is called before the first frame update
    private void Start()
    {   
        healthSystem = new HealthSystem(100);
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(this.transform.position.x , (float)(this.transform.position.y + 0.5)), Quaternion.identity, this.transform);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        playerInSight = canSeePlayer();

        float delay = Random.Range(2f, 5f);
        float rate = Random.Range(2f, 4f);
        // methodName, time, and repeat rate
        InvokeRepeating("Fire", 1f, 1f);
    }
    private void Update(){
        Chase();
        HandleOrientation();
    }
    private bool canSeePlayer(){
        Vector2 dir = player.transform.position - this.firepoint.transform.position;
        RaycastHit2D canSee = Physics2D.Raycast(this.firepoint.transform.position, dir);
        //Debug.Log(player.transform.position);
        //Debug.DrawRay(this.firepoint.transform.position, dir*20, Color.green);
        if(canSee.collider != null){
            
            if(canSee.collider.tag == "Player") {
                
                Debug.Log("Can see player" + canSee.collider.tag);
                return true;            
            }
        }
        Debug.Log("Cannot see player" + canSee.collider.tag);
        return false;
    }
    
    

    public void Fire()
    {   
        Vector3 position = this.firepoint.gameObject.transform.position;
        Instantiate(enemyProjectile, position, Quaternion.identity);
    }
    private bool FindTarget(){
        float targetRange = 10f;
        if(Vector3.Distance(transform.position, player.transform.position) < targetRange){
            return true;
        }
        return false;
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
    private void Chase(){
        var minDist = 2;
        var maxDist = 5;
        var speed = 2f;
        
        if(Vector2.Distance(this.transform.position,player.position) >= minDist){
            Vector3 moveDir = player.position - this.transform.position;
            moveDir.z = 0f;
            moveDir = moveDir.normalized;
            rb.velocity = moveDir * speed;
            //transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime);
            if(Vector2.Distance(this.transform.position, player.position) <= maxDist){
                // shoot or return true
            }
        }
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
