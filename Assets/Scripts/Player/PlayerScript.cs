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
        canMove = true;
    }

    private void Update() {
        HandleMovement();
        HandleDash();
        HandleFire();
    }



    #region Movement
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
        
        if(canMove){
            Vector3 moveDir = new Vector3(moveX, moveY,0).normalized;
            lastMoveDir.x = moveDir.x; // used for dashing
            lastMoveDir.y = moveDir.y;
            this.transform.position += moveDir * speed * Time.deltaTime;
        }
        else{

        }
        
        // TO DO:
        // add ray casting to test for hitboxes (collision with walls and other objects?)
    }
    #endregion
    private void HandleDash(){
        if(Input.GetKeyDown(KeyCode.Space)){
            
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

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag =="EnemyProjectile"){
            Debug.Log("Player was hit");
            Destroy(other.gameObject);
            health -= 0.1f;
            healthBar.fillAmount = health;
        }
        
    }




    // SKILLS
    //private bool CanUseDash(){
    //    return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dash);
    //}
    //private bool CanUseDodge(){
    //    return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dodge);
    //}

    

}

