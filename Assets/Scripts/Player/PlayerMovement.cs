using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask pickingLayers;
    public float speed = 3;
    public float moveDistThreshold = 0.1f;
    public float rotateSpeed = 10;
    private Camera theCam;
    private Vector3 curTarget;
    private Rigidbody rb;
    public Animator playerAnimator;
    private float curSpeed = 0;
    private Vector3 targetForward;
    private Vector3 lastPos;
    private Vector3 moveDirection;
    public GameObject ClickArrows;
    private PlayerIK ikController;
    private void Start()
    {
        ikController = GetComponentInChildren<PlayerIK>();
        targetForward = transform.forward;
        curTarget = transform.position;
        theCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        lastPos = rb.position;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {

            Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, pickingLayers))
            {
                curTarget = new Vector3(hInfo.point.x, transform.position.y, hInfo.point.z);
                targetForward = (curTarget - rb.position).normalized;
                GameObject newArrows = Instantiate(ClickArrows);
                newArrows.transform.position = hInfo.point;
                ikController.SetLookTarget(curTarget);
            }
        }
       
        transform.forward = Vector3.Lerp(transform.forward, targetForward, Time.deltaTime * rotateSpeed);

    }


    private void FixedUpdate()
    {
        if (Vector3.Distance(curTarget, transform.position) > moveDistThreshold)
        {
            rb.position += (curTarget - rb.position).normalized * Time.fixedDeltaTime * speed;
            curSpeed = Vector3.Distance(rb.position, lastPos) / Time.fixedDeltaTime;
            
        }
        else 
        {
            curSpeed = Mathf.Lerp(curSpeed, 0, Time.fixedDeltaTime * 10);
            transform.position = curTarget;
        }
        playerAnimator.SetFloat("Speed", curSpeed);
        moveDirection = transform.InverseTransformVector(rb.position - lastPos).normalized * curSpeed;

        playerAnimator.SetFloat("RelativeX", moveDirection.x);
        playerAnimator.SetFloat("RelativeY", moveDirection.z);

        lastPos = rb.position;

    }
}
