﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	private void Start(){
		Destroy(this.gameObject,1f);
	}
	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
		
	}


}
