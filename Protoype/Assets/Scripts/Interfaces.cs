using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface describing a function for activating a pattern.
public interface PatternInterface
{
    float firespeed{ get; set;}
    void Begin();
}


public interface AttackInterface
{
    float firespeed {get; set;}
    void Use();
}

