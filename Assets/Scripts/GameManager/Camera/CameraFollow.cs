using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraFollow : MonoBehaviour
{
    
    private Func<Vector3> GetCameraFollowPositionFunc;
    public void Setup(Func<Vector3> GetCameraFollowPositionFunc){
        
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }
    
    
    public void SetGetCameraFollowPositionFunc(Func<Vector3> GetCameraFollowPositionFunc){
        this.GetCameraFollowPositionFunc = GetCameraFollowPositionFunc;
    }
    
    void Update()
    {
        HandleMovement();
        //HandleZoom();
    }
    private void HandleMovement(){
        Vector3 cameraFollowPosition = GetCameraFollowPositionFunc();
        cameraFollowPosition.z = transform.position.z;

        Vector3 cameraMoveDir = (cameraFollowPosition - transform.position).normalized;
        float distance = Vector3.Distance(cameraFollowPosition, this.transform.position);
        float cameraMoveSpeed = 1f;
        if(distance > 0){
            Vector3 newCameraPosition = this.transform.position + cameraMoveDir * distance * cameraMoveSpeed * Time.deltaTime;
             
            float distanceAfterMoving = Vector3.Distance(newCameraPosition, cameraFollowPosition);

            if(distanceAfterMoving > distance){
                // overshot target
                newCameraPosition = cameraFollowPosition;
            }

            transform.position = newCameraPosition;
        }
    }

    //private void HandleZoom(){
    //    float cameraZoom = GetCameraZoomFunc();
//
    //    float cameraZoomDifference = cameraZoom - myCamera.orthographicSize;
    //    float cameraZoomSpeed = 1f;
//
    //    myCamera.orthographicSize += cameraZoomSpeed * cameraZoomDifference * Time.deltaTime;
//
    //    if(cameraZoomDifference > 0){
    //        if(myCamera.orthographicSize > cameraZoom){
    //            myCamera.orthograhpicSize = cameraZoom;
    //        }
    //        
    //    }
    //    else{
    //        if(myCamera.orthographicSize < cameraZoom){
    //            myCamera.orthographicSize = cameraZoom;
    //        }
    //    }
    //}
}
