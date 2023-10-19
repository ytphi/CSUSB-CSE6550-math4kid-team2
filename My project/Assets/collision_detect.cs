using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision_detect : MonoBehaviour
{
    public GameObject collision_obj;
    public Transform parentCanvas;
    public void OnTriggerEnter2D(Collider2D Fruit)
    {
        Debug.Log("hit detected");
        GameObject e = Instantiate(collision_obj) as GameObject;
        e.transform.SetParent(parentCanvas, false);
        e.transform.position= this.transform.position;
        Destroy(Fruit.gameObject);
        this.gameObject.SetActive(false);
    }
}
