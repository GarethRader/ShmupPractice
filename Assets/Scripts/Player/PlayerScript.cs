using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    private PlayerSkills playerSkills;
    private float speed{
        get {return speed;}
        set{speed = value;} // May need to use protected set depending on implemenation of classes
    }

    private float health{
        get {return health;}
        set{health = value;} // May need to use protected set depending on implemenation of classes
    }
    public Image healthBar;

    public GameObject projectile;

    // Start is called before the first frame update
    private void Awake(){
        playerSkills = new PlayerSkills();
    }

    // Update is called once per frame
    private void Update() {
        HandleMovement();
        
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
        this.transform.position += moveDir * speed * Time.deltaTime;

        // this allows the player game object to rotate according to mouse position
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

    private bool CanUseDash(){
        return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dash);
    }
    private bool CanUseDodge(){
        return PlayerSkills.IsSkillUnlocked(PlayerSkills.SkillType.Dodge);
    }

    

}

