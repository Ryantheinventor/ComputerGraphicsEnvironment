using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    public int curWeapon = 0;

    public List<Weapon> weapons = new List<Weapon>();

    public LayerMask pickingLayers;


    private Camera theCam;

    private void Start()
    {
        theCam = theCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {

            Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, pickingLayers))
            {
                Vector3 curTargetPos = new Vector3(hInfo.point.x, transform.position.y, hInfo.point.z);
                if (weapons.Count - 1 >= curWeapon)
                { 
                    weapons[curWeapon].Attack(curTargetPos, transform.position);
                }
            }
        }
    }

    public void SetWeapon(int id) 
    {
        curWeapon = id;
    }


}

public class Weapon : MonoBehaviour 
{
    public virtual void Attack(Vector3 target, Vector3 playerPos) 
    {   

    }
}