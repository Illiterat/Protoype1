using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullaReverseWhip : MonoBehaviour
{
    public GameObject hazard;

    public void Launch(GameObject[] tiles)
    {
        foreach (GameObject t in tiles)
        {
            GameObject hazardClone = Instantiate(hazard, t.transform.position, t.transform.rotation);
            Destroy(hazardClone,1);
        }
    }
}
