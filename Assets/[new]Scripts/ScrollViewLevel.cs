using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScrollViewLevel : MonoBehaviour
{
    private float deltaZ = 0.0f; // Z值的改变量
    public float fric; // 摩擦力提供的加速度
    private float currentZ;

    private static float MAX_Z = -1.0f; // 目标物体可以移动到的最大Z值  
    private static float MIN_Z = -25.0f; // 目标物体可以移动到的最小Z值
    private static float MAX_DELTAZ = 0.24f; // 速度上限
    private float tmp = 0;
    private bool isScrolling;
    private Transform targetObject; // 脚本挂载的目标物体，将通过滚轮来调整其Z值  

    private void Start()
    {
        targetObject = transform;
        isScrolling = false;
    }

    void Update()
    {
        //deltaZ = 0;
        //Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            tmp = targetObject.position.z;
            deltaZ = MAX_DELTAZ;
            isScrolling = true;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            tmp = targetObject.position.z;
            deltaZ = -MAX_DELTAZ;
            isScrolling = true;
        }
        else
        {
            if (isScrolling)
            {
                isScrolling = false;
                float deltaTmp = targetObject.position.z - tmp;
                Debug.Log(deltaTmp);
                deltaZ = deltaTmp;
                tmp = targetObject.position.z;
            }
            if (deltaZ > 0)
            {
                deltaZ -= fric;
                deltaZ = Mathf.Clamp(deltaZ, 0, MAX_DELTAZ);
            }
            else if (deltaZ < 0)
            {
                deltaZ += fric;
                deltaZ = Mathf.Clamp(deltaZ, -1 * MAX_DELTAZ, 0);
            }
        }

        
        currentZ = targetObject.position.z + deltaZ;
        currentZ = Mathf.Clamp(currentZ, MIN_Z, MAX_Z);
        // 更新目标物体的位置  
        targetObject.position = new Vector3(targetObject.position.x, targetObject.position.y, currentZ);
    }
}
