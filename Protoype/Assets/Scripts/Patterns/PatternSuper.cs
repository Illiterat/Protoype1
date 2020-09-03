using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is a superclass, for those interested.
    It's here to be used creating subclasses to be the patterns we use,
    the subclasses will inherit features from the subclass.
*/


public class PatternSuper : MonoBehaviour
{
    public float fireSpeed;
    public float waitTime;
    public int phase;
    public List<GameObject> emitters = new List<GameObject>();
    public List<GameObject> tiles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual IEnumerator Begin(GameObject emitter)
    {
        //Testing to see if I can overide this functionality in the subclasses
        Debug.Log("This shouldn't display");
        yield return new WaitForSeconds(0.01f);
    }
}
