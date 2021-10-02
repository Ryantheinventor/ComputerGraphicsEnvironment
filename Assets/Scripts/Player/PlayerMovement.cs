using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask pickingLayers;
    public float speed = 3;
    public float moveDistThreshold = 0.1f;
    private Camera theCam;
    private Vector3 curTarget;
    private Rigidbody rb;

    private void Start()
    {
        curTarget = transform.position;
        theCam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) 
        {

            Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, pickingLayers)) 
            {
                curTarget = new Vector3(hInfo.point.x, transform.position.y, hInfo.point.z);
                Debug.Log("NewTarget:" + curTarget);
                transform.forward = (curTarget - rb.position).normalized;
            }
        }
    }


    private void FixedUpdate()
    {
        if (Vector3.Distance(curTarget, transform.position) > moveDistThreshold)
        {
            rb.position += (curTarget - rb.position).normalized * Time.fixedDeltaTime * speed;
        }
        else 
        {
            transform.position = curTarget;
        }
    }






}
