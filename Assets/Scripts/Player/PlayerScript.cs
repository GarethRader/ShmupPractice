using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    
    
    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioClip fireSound;
    private AudioSource fireSoundSource;

    private void Start(){
        fireSoundSource = GetComponent<AudioSource>();
        fireSoundSource.clip = fireSound;
    }
    private void Update() {
        HandleFire();
    }



    private void HandleFire(){
        // this allows the player game object to rotate/aim according to mouse position
        // front of player sprite will always be facing towards the mouse cursor
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg -90;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        float speed = this.transform.parent.gameObject.GetComponent<PlayerObjectScript>().speed;

        this.transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed);

        if(Input.GetMouseButtonDown(0)){
            fireSoundSource.Play();
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


