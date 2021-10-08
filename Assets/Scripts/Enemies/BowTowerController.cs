using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TurretHeadTageting))]
public class BowTowerController : TowerController
{
    public GameObject arrowFab;
    public GameObject arrowSpawnPoint;
    public float timeBetweenShots = 5;
    public float timeToAim;

    public Animator animationController;

    private float curShotWaitTime = 0;
    private float curAimTime = 0;
    private bool aiming = false;

    private GameObject target;
    private TurretHeadTageting headTageting;




    private void Start()
    {
        
        headTageting = GetComponent<TurretHeadTageting>();
        target = headTageting.target.gameObject;
    }

    private void Update()
    {
        animationController.SetBool("Aiming", aiming);

        if (aiming)
        {
            curAimTime += Time.deltaTime;
            if (curAimTime >= timeToAim)
            {
                //shoot here 
                GameObject newArrow = Instantiate(arrowFab);
                newArrow.transform.position = arrowSpawnPoint.transform.position;
                newArrow.transform.forward = headTageting.targetDirection;
                Projectile p = newArrow.GetComponent<Projectile>();
                p.velocity = headTageting.targetDirection.normalized * p.speed;

                curAimTime = 0;
                aiming = false;
            }
        }
        else 
        {
            curShotWaitTime += Time.deltaTime;
            if (curShotWaitTime >= timeBetweenShots) 
            {
                aiming = true;
                curShotWaitTime = 0;
            }
        }
    }

    private void OnDestroy()
    {
        if(EnemyWaves.activeEnemies.Contains(this))
            EnemyWaves.activeEnemies.Remove(this);
    }


}
