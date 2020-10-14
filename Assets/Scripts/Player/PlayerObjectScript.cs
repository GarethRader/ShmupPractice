using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 lastMoveDir;
    [SerializeField] private Transform pfHealthBar;
    private HealthSystem healthSystem;
    [SerializeField] private PlayerScript player;
    [SerializeField] private Rigidbody2D rb;
    private bool isDead = false;
    public float speed{ get; set; }
    private float health{ get; set;}
    public static int enemyKillCount = 0;
    
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        healthSystem = new HealthSystem(100);
        
       
        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(this.transform.position.x, (float)(this.transform.position.y + 0.5)), Quaternion.identity, this.transform);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        speed = 5f;
        lastMoveDir.z = 0f;
    }

    public void AddPoints(){
        enemyKillCount++;
    }
    public int GetPoints(){
        return enemyKillCount;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleDash();
    }



    private void HandleMovement(){
        float moveX = 0f;
        float moveY = 0f;

        if(Input.GetKey(KeyCode.W)){
            moveY = 1f;
        }
        if(Input.GetKey(KeyCode.S)){
            moveY = -1f;
        }
        if(Input.GetKey(KeyCode.A)){
            moveX = -1f;
        }
        if(Input.GetKey(KeyCode.D)){
            moveX = 1f;
        }
        
        Vector3 moveDir = new Vector3(moveX, moveY).normalized;
        rb.velocity = moveDir * speed;
        //lastMoveDir.x = moveDir.x; // used for dashing
        //lastMoveDir.y = moveDir.y;
        //this.transform.position += moveDir * speed * Time.deltaTime;
    }
    
    
    
    private void HandleDash(){
        if(Input.GetKeyDown(KeyCode.Space)){
            float dashDistance = 2f; // might add as class variable
            Vector2 dash = new Vector2(lastMoveDir.x, lastMoveDir.y);
            rb.velocity += dash * dashDistance;
        }
    }

    public void DamageTaken(int amount){
        this.healthSystem.Damage(amount);
        //if(checkIsDead())
    }
    private bool checkIsDead(){
        if(healthSystem.GetHealthPercentage() <= 0){
            isDead = true;
            Destroy(this.gameObject);
            return true; // if true play dead/lose screen
        }
        return false;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Wall"){

        }
    }
}
