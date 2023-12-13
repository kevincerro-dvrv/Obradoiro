using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector3 velocity;
    private float ttl;

    private Vector3 startScale;
    private Vector3 finalScale;
    private float t = 0;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        id = Random.Range(1, 999999999);

        ttl = Random.Range(5f, 10f);

        startScale = transform.localScale;
        finalScale = startScale * Random.Range(2f, 5f);

        Destroy(gameObject, ttl);
    }

    // Update is called once per frame
    void Update()
    {
        // Move bubble
        Move();

        // Scale bubble
        t += Time.deltaTime / ttl;
        transform.localScale = Vector3.Lerp(startScale, finalScale, t);
    }

    private void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition += velocity * Time.deltaTime;
        transform.position = newPosition;
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity * Random.Range(0.95f, 1.05f) + (Vector3) Random.insideUnitCircle * 0.2f;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Bubble")) {
            if (this.id < other.gameObject.GetComponent<Bubble>().id) {
                Destroy(other.gameObject);
                startScale *= 1.5f;
                finalScale *= 1.5f;
            }
        } else if (!other.gameObject.CompareTag("BubbleGun")) {
            Destroy(gameObject);
        }
    }
}
