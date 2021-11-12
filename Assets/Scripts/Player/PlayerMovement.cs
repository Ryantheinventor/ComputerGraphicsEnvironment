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
        //target picking (only avalible when mouse is not over UI)
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject() && !GameManager.gamePaused)
        {

            Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, pickingLayers))
            {
                if (hInfo.collider.gameObject.CompareTag("Floor")) 
                {
                    //target is always set to have the same Y pos as the player (for easy movement)
                    curTarget = new Vector3(hInfo.point.x, transform.position.y, hInfo.point.z);

                    GameObject newArrows = Instantiate(ClickArrows);
                    newArrows.transform.position = hInfo.point;
                    SetNewTargetLook(curTarget);
                }
            }
        }
       
        transform.forward = Vector3.Lerp(transform.forward, targetForward, Time.deltaTime * rotateSpeed);

    }

    public void SetNewTargetLook(Vector3 target) 
    {
        targetForward = (target - rb.position).normalized;
        ikController.SetLookTarget(target);
    }


    private void FixedUpdate()
    {
        //move the player to the target poss
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

        //update the animator
        playerAnimator.SetFloat("Speed", curSpeed);
        moveDirection = transform.InverseTransformVector(rb.position - lastPos).normalized * curSpeed;

        playerAnimator.SetFloat("RelativeX", moveDirection.x);
        playerAnimator.SetFloat("RelativeY", moveDirection.z);

        lastPos = rb.position;

    }
}

