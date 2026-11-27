using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform PointA;
    public Transform PointB;

    public float speed;
    private bool AtoB;

    private Vector3 targetPosition;

    void Update()
    {
        // Choose which point to move toward
        // Once AtoB changes, the platform begins moving back the other way
        if (AtoB == true)
        {
            targetPosition = PointA.position;
        }
        else
        {
            targetPosition = PointB.position;
        }

        // Move toward the target position on the Y-axis
        Vector3 newPosition = transform.position;
        newPosition.y = Mathf.MoveTowards(transform.position.y, targetPosition.y, speed * Time.deltaTime);

        transform.position = newPosition;

        // Switch direction when closing in on the target
        if (Mathf.Abs(transform.position.y - targetPosition.y) < 0.1f)
        {
            AtoB = !AtoB; // if true, become false. If false, become true
        }
    }

    // Make the player a child of the platform so he sits still on it
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(transform);
        }
    }

    // The moment the player jumps off, he is no longer a child of the platform
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
