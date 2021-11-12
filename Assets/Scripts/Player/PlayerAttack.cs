using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAttack : MonoBehaviour
{
    public int curWeapon = 0;

    public List<Weapon> weapons = new List<Weapon>();

    public LayerMask pickingLayers;

    public Mana manaTracker;

    private Camera theCam;

    public PlayerMovement pm;

    private void Start()
    {
        theCam = theCam = Camera.main;
        manaTracker = GetComponent<Mana>();
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !GameManager.gamePaused)
        {
            
            Ray ray = theCam.ScreenPointToRay(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            if (Physics.Raycast(ray.origin, ray.direction, out RaycastHit hInfo, 100, pickingLayers))
            {
                Vector3 curTargetPos = new Vector3(hInfo.point.x, transform.position.y, hInfo.point.z);
                if (weapons.Count - 1 >= curWeapon)
                {
                    if (weapons[curWeapon].manaNeeded <= manaTracker.CurMana) 
                    {
                        if (weapons[curWeapon].Attack(curTargetPos, transform.position)) 
                        {
                            manaTracker.CurMana -= weapons[curWeapon].manaNeeded;
                        }
                    }
                }
            }
        }
    }

    ///<summary>
    ///hi
    ///</summary>
    public void SetWeapon(int id) 
    {
        curWeapon = id;
    }


}

//base class for any type of attack the player can use
public class Weapon : MonoBehaviour 
{
    public float manaNeeded = 10;
    /// <summary>
    /// Perform necessary actions for an attack with this Weapon
    /// </summary>
    public virtual bool Attack(Vector3 target, Vector3 playerPos) 
    {
        return false;
    }
}