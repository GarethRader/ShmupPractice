using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectScript : MonoBehaviour
{
    // Start is called before the first frame update

    private bool canMove;
    private Vector3 lastMoveDir;
    [SerializeField] private Transform pfHealthBar;
    private HealthSystem healthSystem;
    [SerializeField] private PlayerScript player;
    [SerializeField] private Rigidbody2D rb;
    private bool isDead = false;
    public float speed{ get; set; }
    private float health{ get; set;}
    void Start()
    {
        //rb = this.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        healthSystem = new HealthSystem(100);

        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(this.transform.position.x, (float)(this.transform.position.y + 0.5)), Quaternion.identity, this.transform);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);

        speed = 5f;
        lastMoveDir.z = 0f;
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

        TryMove(moveDir, speed * Time.deltaTime); // can use to play different animations
        //lastMoveDir.x = moveDir.x; // used for dashing
        //lastMoveDir.y = moveDir.y;
        //this.transform.position += moveDir * speed * Time.deltaTime;
    }
    private bool CanMove(Vector3 dir, float distance){
        return Physics2D.Raycast(transform.position, dir, distance).collider == null;
    }
    
    private bool TryMove(Vector3 baseMoveDir, float distance){
        Vector3 moveDir = baseMoveDir;
        bool canMove = CanMove(moveDir, speed * Time.deltaTime);
        if(!canMove){
            // can't move diagonally
            moveDir = new Vector3(baseMoveDir.x, 0f).normalized;
            canMove = moveDir.x != 0f && CanMove(moveDir, speed * Time.deltaTime);
            if(!canMove){
                // can't move horizontally
                moveDir = new Vector3(0f, baseMoveDir.y).normalized;
                canMove = moveDir.y != 0f && CanMove(moveDir, speed * Time.deltaTime);
            }
        }
        if(canMove){
            lastMoveDir = moveDir;
            transform.position += moveDir * distance;
            //rb.AddForce(new Vector2(moveDir.x*100f, moveDir.y*100f));
            return true;
        }
        else{
            return false;
        }
    }
    private void HandleDash(){
        if(Input.GetKeyDown(KeyCode.Space)){
            float dashDistance = 2f; // might add as class variable
            TryMove(lastMoveDir, dashDistance); // can also use to add dash animation
        }
    }

    public void DamageTaken(int amount){
        this.healthSystem.Damage(amount);
        checkIsDead();
    }
    private bool checkIsDead(){
        if(healthSystem.GetHealthPercentage() <= 0){
            isDead = true;
            Destroy(this.gameObject);
            return true;
        }
        return false;
    }
}
