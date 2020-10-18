using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DullaStab : MonoBehaviour
{
    public GameObject hazard;

    public void Launch(GameObject[] tiles)
    {
        foreach (GameObject t in tiles)
        {
            GameObject hazardClone = Instantiate(hazard, t.transform.position, t.transform.rotation);
            hazardClone.GetComponent<HitAreaScript>().enabled = true;
            Destroy(hazardClone,3);
        }
    }
}
