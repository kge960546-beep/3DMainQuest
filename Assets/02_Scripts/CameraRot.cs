using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] float roMin;
    [SerializeField] float roMax;
    [SerializeField] float speed = 0.3f;
    private float baseY;
    private void Start()
    {
        baseY = transform.eulerAngles.y;
    }
    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.0f);
        float y = Mathf.Lerp(roMin, roMax, t);

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            baseY + y,
            transform.eulerAngles.z);       
    }
}
