using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 dragStartPosition;

    [Range(0.008f,0.09f)]
    public float rotationSpeed = 0.064f; // 旋转速度，根据需求调整

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 鼠标左键按下时
        {
            //RaycastHit hit;
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(ray, out hit))
            //{
            //    if (hit.collider.gameObject == gameObject) // 碰撞到当前游戏物体
            //    {
                    isDragging = true;
                    dragStartPosition = Input.mousePosition;
            //    }
            //}
        }
        else if (Input.GetMouseButtonUp(0)) // 鼠标左键释放时
        {
            isDragging = false;
        }

        if (isDragging)
        {
            Vector3 currentMousePosition = Input.mousePosition;
            Vector3 dragDelta = currentMousePosition - dragStartPosition;
            

            float rotationX = dragDelta.y * rotationSpeed;
            float rotationY = -dragDelta.x * rotationSpeed;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);

            dragStartPosition = currentMousePosition;
        }
    }
}
