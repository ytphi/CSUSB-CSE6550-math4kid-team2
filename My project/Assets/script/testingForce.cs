using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testingForce : MonoBehaviour
{
    public Transform Dog, parentCanvas, Dog1; // The point from which the object is thrown
    public GameObject Fruite; // The object to be thrown
    public float throwForce1 = 20.0f; // The force to throw the object
    public float throwForce2 = 5.0f;
    // The force to throw the object
    

    //private bool canThrow = true;

   
   

    public void ThrowObject()
    {


        // Create a new instance of the object to throw
        Vector3 newPos = new Vector3((Dog.position.x - 1920) / 1, (Dog.position.y - 1080) / 1, 0);
        Debug.Log("fruit position:");
        Debug.Log(Dog.position);
        Debug.Log("Dog position:");
        Debug.Log(Dog1.position);
        GameObject FruiteClone = Instantiate(Fruite, newPos, Quaternion.identity);
        FruiteClone.transform.SetParent(parentCanvas, false);

        Debug.Log(FruiteClone.name);
        Debug.Log("clone position:");
        Debug.Log(FruiteClone.transform.position);
        // Calculate the direction from the monster to the target
        Vector2 direction = (Dog1.position - Dog.position).normalized;
        Rigidbody2D rb = FruiteClone.GetComponent<Rigidbody2D>();
        // Apply force to the monster in that direction
        rb.AddForce(Vector3.up * 300.0f, ForceMode2D.Impulse);
        rb.AddForce(direction * 2000.0f, ForceMode2D.Impulse);
        //StartCoroutine(ResetThrowCooldown());
    }

    IEnumerator ResetThrowCooldown()
    {
        yield return new WaitForSeconds(10.0f); // Adjust the cooldown time as needed
        //canThrow = true;



    }
}
