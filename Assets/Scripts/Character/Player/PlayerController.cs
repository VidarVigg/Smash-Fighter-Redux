using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{

    #region Fields

    private PlayerMaster master = null;
    private PlayerConfig config = null;
    private PlayerData data = null;

    #endregion

    #region Constructors

    private PlayerController() { }
    public PlayerController(PlayerMaster master, PlayerConfig config, PlayerData data)
    {
        this.master = master;
        this.config = config;
        this.data = data;
    }

    #endregion
}
