using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MovementController
{

    #region Fields



    #endregion

    #region Methods

    private void Update()
    {
        base.Update();
        Move();
       //Gravity();
        //GroundCheck();
    }





    #endregion

}
