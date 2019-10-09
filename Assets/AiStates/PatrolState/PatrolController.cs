using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{

    #region Fields

    private PatrolState patrolState = null;

    private PatrolConfig patrolConfig = null;

    private PatrolData patrolData = null;

    #endregion

    #region Constructors

    private PatrolController() { }
    public PatrolController(PatrolState patrolState, PatrolConfig patrolConfig, PatrolData patrolData)
    {
        this.patrolState = patrolState;
        this.patrolConfig = patrolConfig;
        this.patrolData = patrolData;
    }

    #endregion

    #region Methods



    #endregion

}
