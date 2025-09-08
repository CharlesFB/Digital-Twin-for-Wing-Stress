using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class AnimController : MonoBehaviour
{
    [Header("Camera")]
    public GameObject main_camera; //摄像头物体

    [Header("Model Control")]
    public GameObject mechine_rotate; //左键拖拽自由选择（旋转物体）
    public GameObject self_rotate; //定轴旋转（旋转父对象）
    public TMP_Text spin_text; //控制按钮上的文字

    [Header("Model Split")]
    public List<Transform> elements;
    public List<Vector3> target_pos;
    public List<Vector3> begin_pos;

    [Header("Air Model")]
    public MeshRenderer outsider;

    private Tween rotate_anim;
    private bool is_paused;
    private bool split_flag;

    private int isOn;

    private static string DO_SPIN = "自动旋转(开)";
    private static string STOP_SPIN = "自动旋转(关)";
    private static Vector3 DEFAULT_POSITION = new Vector3(0, 0, -15);

    public void rotationReset()
    {
        mechine_rotate.transform.DORotate(new Vector3(-90f,0f,0f), 0.4f);
    }

    public void rotationX()
    {
        mechine_rotate.transform.DORotate(new Vector3(0f, 0f, 0f), 0.4f);
    }

    public void rotationY()
    {
        mechine_rotate.transform.DORotate(new Vector3(0f, 90f, 0f), 0.4f);
    }

    public void rotationZ()
    {
        mechine_rotate.transform.DORotate(new Vector3(-90f, 0f, -90f), 0.4f);
    }

    public void selfRotate() //自己绕y轴旋转
    {
        is_paused ^= true;
        if (is_paused)
        {
            rotate_anim.Pause();
            spin_text.text = STOP_SPIN;
        }
        else
        {
            rotate_anim.Play();
            spin_text.text = DO_SPIN;
        }
    }

    public void cameraReset()
    {
        main_camera.transform.DOMove(DEFAULT_POSITION, 0.4f);
    }

    public void splitModel()
    {
        split_flag ^= true;
        for (int i = 0; i < elements.Capacity; i++)
        {
            if (split_flag)
                elements[i].DOLocalMove(target_pos[i], 0.4f);
            else
                elements[i].DOLocalMove(begin_pos[i], 0.4f);
        }
    }

    public void CheckModel()
    {
        isOn ^= 1;
        if (isOn == 1)
        {
            Material material = outsider.materials[0];
            material.DOFade(1, 0.2f);
        }
        else
        {
            Material material = outsider.materials[0];
            material.DOFade(0, 0.2f);
        }
    }

    private void Start()
    {
        rotate_anim = self_rotate.transform.DORotate(new Vector3(0, -360f, 0), 40f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1);
        rotate_anim.Pause();
        is_paused = true;
        spin_text.text = STOP_SPIN;

        // Model Split
        split_flag = false;

        // Air Model
        isOn = 1;
    }

    void Update()
    {
        
    }
}
