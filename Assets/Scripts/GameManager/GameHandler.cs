using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public Transform PlayerTransform;
    public CameraFollow cameraFollow;
    // can add other transforms to set camera on another target via cameraFollow.SetGetCameraFollowPositionFunc(() => target.position);

    private void Start(){
        cameraFollow.Setup(() => PlayerTransform.position);
        cameraFollow.SetGetCameraFollowPositionFunc( () => PlayerTransform.position);
    }

    private void Update(){

    }


}
