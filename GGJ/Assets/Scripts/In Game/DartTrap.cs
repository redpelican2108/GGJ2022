using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartTrap : MonoBehaviour
{
    public GameObject dart;
    private bool inRange = false;
    [SerializeField] private float fireRate = 2.0f;
    private float time = 0f;
    private Transform target;
    // Update is called once per frame
    void Update()
    {
        if(inRange && time <= 0f)
        {
            Shoot();
            time += fireRate;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }

    public void Target(Transform player)
    {
        inRange = true;
        target = player;
    }

    public void Stop()
    {
        inRange = false;
        target = null;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(dart, transform.position, Quaternion.identity);
        bullet.GetComponent<Dart>().target = target.position;
    }
}
