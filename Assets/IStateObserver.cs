using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateObserver
{
    void Notify(State state);
}
