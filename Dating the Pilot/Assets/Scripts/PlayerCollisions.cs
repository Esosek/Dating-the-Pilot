using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    public ParticleSystem explosion;
    public GameObject GFX;

    private void OnCollisionEnter(Collision collision)
    {
        // crash
        Debug.Log("You crashed into " + collision.gameObject.name);

        StartCoroutine(Crash());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Runway"))
        {
            // game win
            Debug.Log("Runway reached!");

            AudioManager.instance.Play("Landing");
            GameManager.instance.GameWon();
        }
    }

    IEnumerator Crash()
    {
        Debug.Log("Explosion fired");
        AudioManager.instance.Play("Crash");
        GetComponent<Collider>().enabled = false;
        GetComponent<PlaneMovement>().enabled = false;
        GetComponentInChildren<Camera>().gameObject.transform.SetParent(transform.parent);
        Instantiate(explosion, transform.position, Quaternion.identity);
        GFX.SetActive(false);

        yield return new WaitForSeconds(2f);

        GameManager.instance.GameLost();
    }
}
