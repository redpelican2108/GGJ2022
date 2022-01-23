using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    [SerializeField] private int time;
    private BoxCollider2D _collider;
    private float timer;
    public GameObject jewel;

    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
    }
    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(time);
        Instantiate(jewel, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void StartCount()
    {
        _collider.isTrigger = false;
        StartCoroutine(CountDown());
    }
    


}
