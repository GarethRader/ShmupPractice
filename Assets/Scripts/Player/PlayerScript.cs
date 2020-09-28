using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    
    private bool canMove;
    private Vector3 lastMoveDir;
    private float speed{
        get;
        set; 
    }
    private float health{
        get;
        set;
    }
    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject projectile;

   
    private void Awake(){
        health = 1f;
        speed = 10f;
        lastMoveDir.z = 0f;
    }

    private void Update() {
        HandleMovement();
        HandleDash();
        HandleFire();
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

    private void HandleFire(){
        // this allows the player game object to rotate/aim according to mouse position
        // front of player sprite will always be facing towards the mouse cursor
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);

        if(Input.GetMouseButtonDown(0)){
            Fire();
        }
    }

    

    private void Fire(){
        Instantiate(projectile, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
    }

    

    // SKILLS
    //private bool CanUseDash(){
    //    return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dash);
    //}
    //private bool CanUseDodge(){
    //    return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dodge);
    //}


}


