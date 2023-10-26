using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.AppCenter.Unity.Analytics;

public class collision_detect : MonoBehaviour
{
    public Transform parentCanvas;
    public ParticleSystem collision_obj1;
    public ParticleSystem collision_obj2;
    public bool once = true;
    public Transform Gun;

    // Remove these two lines
    // bool em1 = collision_obj1.emission;
    // bool em2 = collision_obj2.emission;

    public void OnTriggerEnter2D(Collider2D Fruit)
    {
        Debug.Log("hit detected");

        if (Fruit.CompareTag("Fruit") && once)
        {
            // Access the emission module of the ParticleSystems and enable it
            var em1 = collision_obj1.emission;
            em1.enabled = true;
            collision_obj1.transform.position = this.transform.position;

            var em2 = collision_obj2.emission;
            em2.enabled = true;
            collision_obj2.transform.position = this.transform.position;

            collision_obj1.Play();
            collision_obj2.Play();

            StartCoroutine(PlayParticleSystemOnce());
        }

        Destroy(Fruit.gameObject);
        this.gameObject.SetActive(false);
    }

    IEnumerator PlayParticleSystemOnce()
    {
        yield return new WaitForSeconds(0.01f);

        collision_obj1.Pause();
        collision_obj2.Pause();

        // Access the emission module and disable it
        var em1 = collision_obj1.emission;
        em1.enabled = false;

        var em2 = collision_obj2.emission;
        em2.enabled = false;
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
