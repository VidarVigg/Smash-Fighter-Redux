using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{


    #region Constructors



    #endregion

    #region Methods

    private void Update()
    {
        Move();
        Gravity();
        GroundCheck();
    }

    #endregion

}
