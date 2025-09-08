using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCamera : MonoBehaviour
{
    public Transform targetObject; // 目标物体，将通过滚轮来调整其Z值  
    
    private float deltaZ = 0.0f; // Z值的改变量
    public float fric; // 摩擦力提供的加速度
    private float acc; // 滚轮提供的加速度
    private float currentZ;

    private static float MAX_Z = -1.0f; // 目标物体可以移动到的最大Z值  
    private static float MIN_Z = -15.0f; // 目标物体可以移动到的最小Z值
    private static float MAX_DELTAZ = 0.35f; // 速度上限
    public float ABS_ACC = 0.036f;

    private void Start()
    {
        //fric = 0.024f;
    }

    void Update()
    {
        //deltaZ = 0;
        //Input.GetAxis("Mouse ScrollWheel");
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            acc = ABS_ACC;
            if (deltaZ < 0)
                acc += fric;
            else
                acc -= fric;

            deltaZ += acc;
            deltaZ = Mathf.Clamp(deltaZ, -1 * MAX_DELTAZ, MAX_DELTAZ);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            acc = ABS_ACC * -1;
            if (deltaZ > 0)
                acc -= fric;
            else
                acc += fric;

            deltaZ += acc;
            deltaZ = Mathf.Clamp(deltaZ, -1 * MAX_DELTAZ, MAX_DELTAZ);
        }
        else
        {
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
