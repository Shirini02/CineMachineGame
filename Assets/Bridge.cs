using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public float bridgeDestroytime;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine("DestroyBridges");
    }
    IEnumerator DestroyBridges()
    {
        yield return new WaitForSeconds(bridgeDestroytime);
        Destroy(gameObject);
    }
}
