using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface describing a function for activating a pattern.
public interface PatternInterface
{
    float fireSpeed{ get; set;}
    void Begin();
}


public interface AttackInterface
{
    float fireSpeed {get; set;}

    void Launch();
}

