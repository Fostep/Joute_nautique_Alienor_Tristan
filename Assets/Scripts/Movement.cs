using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour

{
    public Vector3 targetOffSet = Vector3.forward * 10f; // "distance à parcourir"
    public float speed = 1f; // Vitesse
    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Then, pick our destination point offset from our current location.
        Vector3 targetPosition = transform.position - targetOffSet; // position cible à atteindre

        while(transform.position != targetPosition) // Tant que nous ne sommes pas arrivés
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime); // Déplacer
            yield return null; // Continuer
        }

        transform.position = targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
