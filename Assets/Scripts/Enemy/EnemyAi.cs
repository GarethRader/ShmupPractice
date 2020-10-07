using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    private EnemyScript enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<EnemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
