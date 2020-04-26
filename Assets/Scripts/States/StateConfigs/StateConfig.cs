using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateConfig : ScriptableObject
{

    protected float movementSpeed;

    protected abstract StateConfig CreateInstance();
    
}
