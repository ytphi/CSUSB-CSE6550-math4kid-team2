using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testingForce : MonoBehaviour
{
    public Transform Dog,parentCanvas; // The point from which the object is thrown
    public GameObject Fruite; // The object to be thrown
    public float throwForce1 = 20.0f; // The force to throw the object
    public float throwForce2 = 5.0f;
    // The force to throw the object
    public Sprite image;
                                     //private bool canThrow = true;



    public void ThrowObject()
    {


        // Create a new instance of the object to throw
        Vector3 newPos = new Vector3(-190.0f, -70.0f, 0);
        Debug.Log(Dog.position);
        GameObject FruiteClone = Instantiate(Fruite, newPos, Quaternion.identity);
       FruiteClone.transform.SetParent(parentCanvas, false);

        Debug.Log(FruiteClone.name);
        Debug.Log(FruiteClone.transform.position);
        // Calculate the throw direction
        Vector3 throwDirection = Dog.right * throwForce1;
        throwDirection += Dog.up * throwForce2;

        // Apply the force to the thrown object
        Rigidbody2D rb = FruiteClone.GetComponent<Rigidbody2D>();
        rb.AddForce(throwDirection, ForceMode2D.Impulse);
       

        // Set a timer to allow throwing again
        //StartCoroutine(ResetThrowCooldown());
    }

    IEnumerator ResetThrowCooldown()
    {
        yield return new WaitForSeconds(10.0f); // Adjust the cooldown time as needed
        //canThrow = true;



    }
}
