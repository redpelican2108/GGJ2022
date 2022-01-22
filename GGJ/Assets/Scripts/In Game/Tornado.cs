using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private int time;
    private float timer;
    public GameObject jewel;
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(time);
        Instantiate(jewel, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void StartCount()
    {
        StartCoroutine(CountDown());
    }
    


}
