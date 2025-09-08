using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragCamera : MonoBehaviour
{
    //脚本绑定在camera上生效，右键拖拽2d视角
    public float dragging_rate;

    private static float LEFT_BOARDER = -6f;
    private static float RIGHT_BOARDER = 6f;
    private static float UPPER_BOARDER = 3f;
    private static float DOWN_BOARDER = -0.8f;

    private bool is_Dragging;
    private Vector2 start_position;

    private void Start()
    {
        is_Dragging = false;
        dragging_rate = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) //鼠标右键按下
        {
            is_Dragging = true;
            start_position = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            is_Dragging = false;
        }

        if (is_Dragging)
        {
            Vector2 current_position = Input.mousePosition;
            Vector2 drag_delta = start_position - current_position;

            float final_x = drag_delta.x * dragging_rate + transform.position.x;
            float final_y = drag_delta.y * dragging_rate + transform.position.y;
            rescalePosition(ref final_x, ref final_y); //防止越界

            transform.position = new Vector3(final_x, final_y, transform.position.z);

            start_position = current_position;
        }
    }

    private void rescalePosition(ref float x, ref float y)
    {
        if (x > RIGHT_BOARDER)
            x = RIGHT_BOARDER;
        else if (x < LEFT_BOARDER)
            x = LEFT_BOARDER;
        if (y > UPPER_BOARDER)
            y = UPPER_BOARDER;
        else if (y < DOWN_BOARDER)
            y = DOWN_BOARDER;
    }
}
