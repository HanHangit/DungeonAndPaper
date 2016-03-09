using UnityEngine;
using System.Collections;

public class ChestStuff : MonoBehaviour
{

    public GameObject[] Content;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            foreach (GameObject t in Content)
            {
                Instantiate(t, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
