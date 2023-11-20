using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AppCenter.Unity.Analytics;
using UnityEngine.SceneManagement;

public class collision_detect : MonoBehaviour
{
    public Transform parentCanvas;
    public ParticleSystem collision_obj1;
    public ParticleSystem collision_obj2;
    public bool once = true;
    public Transform Gun;
    public Camera mainCamera;
    public AudioSource collisionSound;

    // Remove these two lines
    // bool em1 = collision_obj1.emission;
    // bool em2 = collision_obj2.emission;

    public void OnTriggerEnter2D(Collider2D Object_coll)
    {
        Debug.Log("hit detected");

        if (Object_coll.CompareTag("Fruit") && once)
        {
            // Access the emission module of the ParticleSystems and enable it
           
            
            
            Debug.Log( transform.position);
            //Debug.Log(canvasRect.TransformPoint(canvasPosition));
            // Enable emission and play the particle system
            var em1 = collision_obj1.emission;
            em1.enabled = true;
            collision_obj1.transform.position = this.transform.position;

            var em2 = collision_obj2.emission;
            em2.enabled = true;
            collision_obj2.transform.position = this.transform.position;
           // collision_obj1.Play();
            //collision_obj2.Play();
            
            if (collisionSound != null)
            {
                collisionSound.Play();
            }

            //StartCoroutine(PlayParticleSystemOnce());
            Destroy(Object_coll.gameObject);
            this.gameObject.SetActive(false);
        }
        else if (Object_coll.CompareTag("Dog") && once)
        {
            SceneManager.LoadScene("scene4_tryagain_update");
        }

         
    }

    Vector2 ScreenToCanvasPosition(Vector3 screenPosition)
    {
        RectTransform canvasRect = GetComponent<RectTransform>();
        Vector2 canvasSize = canvasRect.sizeDelta;

        // Normalize screen coordinates to the range [0, 1]
        float normalizedX = screenPosition.x / Screen.width;
        float normalizedY = screenPosition.y / Screen.height;

        // Map normalized coordinates to canvas coordinates
        float canvasX = normalizedX * canvasSize.x;
        float canvasY = normalizedY * canvasSize.y;

        return new Vector2(canvasX, canvasY);
    }

    public void ShootGunPosition()
    {
        Vector3 position = Gun.position;
        StartCoroutine(PositionChange(position));
    }
    public IEnumerator PositionChange(Vector3 pos)
    {
         Vector3 newpos=new Vector3(pos.x+20, pos.y, pos.z);
         Gun.position = newpos;
         yield return new WaitForSeconds(0.04f);
        Gun.position = pos;
        
    }
   
}
