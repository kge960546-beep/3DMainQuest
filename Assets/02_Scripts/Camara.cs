using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camara : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;
    
    [SerializeField] float mouseSpeed;
    [SerializeField] float yRototion = 0f;
    [SerializeField] float xRototion = 0f;
    [SerializeField] float mourseMin;
    [SerializeField] float mourseMax;
   
    void Update()
    {
        if (GameManager.Instance.State != GameState.Playing) return;
        transform.position = target.position + offset;

        xRototion += Input.GetAxis("Mouse X");
        yRototion += Input.GetAxis("Mouse Y");

        yRototion = Mathf.Clamp(yRototion, mourseMin, mourseMax);
        this.transform.localEulerAngles = new Vector3(-yRototion, xRototion, 0);
    }
}
