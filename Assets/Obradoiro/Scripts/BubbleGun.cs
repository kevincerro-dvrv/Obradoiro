using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BubbleGun : MonoBehaviour
{
    public GameObject bubblePrefab;
    public Transform firePoint;
    private bool fire = false;
    private Vector3 windVelocity;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBubbles());

        windVelocity = Random.insideUnitCircle;
        windVelocity.z = windVelocity.y;
        windVelocity.y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire(bool mustFire)
    {
        if (mustFire) {
            SpawnBubble();
        }

        fire = mustFire;
    }

    private IEnumerator FireBubbles()
    {
        while (true) {
            if (fire) {
                SpawnBubble();
            }
            
            yield return new WaitForSeconds(0.2f);
        }
    }

    private void SpawnBubble()
    {
        GameObject bubble = Instantiate(bubblePrefab, firePoint.position, Quaternion.identity);
        bubble.GetComponent<Bubble>().SetVelocity(windVelocity);
    }
}
