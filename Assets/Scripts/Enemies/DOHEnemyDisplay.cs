using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOHEnemyDisplay : MonoBehaviour
{
    public GameObject healthPointFab;
    private List<GameObject> healthPoints = new List<GameObject>();
    private DestroyOnHealth destroyOnHealth;

    private void Start()
    {
        destroyOnHealth = GetComponent<DestroyOnHealth>();
        destroyOnHealth.OnHealthChange.AddListener(UpdateHealthBar);
        for (int i = 0; i < destroyOnHealth.Health; i++) 
        {
            GameObject newPoint = Instantiate(healthPointFab, transform);
            newPoint.transform.eulerAngles = new Vector3(0,i * 15,0);
            healthPoints.Add(newPoint);
        }
    }

    public void UpdateHealthBar(float health) 
    {
        while (health < healthPoints.Count) 
        {
            GameObject cur = healthPoints[healthPoints.Count - 1];
            healthPoints.Remove(cur);
            Destroy(cur);
        }
    }
}
