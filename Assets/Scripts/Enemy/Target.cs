using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private static List<Target> targetList;

    public static Target GetClosest(Vector3 position, float maxRange){
        Target closest = null;
        foreach(Target target in targetList){
            if(Vector2.Distance(position,target.GetPosition()) <= maxRange) {
                if(closest == null){
                    closest = target;
                }
                else{
                    if(Vector2.Distance(position, target.GetPosition()) < Vector2.Distance(position, closest.GetPosition())){
                        closest = target;
                    }
                }
            }
        }
        return closest;
    }

    private void Awake(){
        if(targetList == null) targetList = new List<Target>();
        targetList.Add(this);

    }

    
    public Vector3 GetPosition(){
        return this.transform.position;
    }
}
