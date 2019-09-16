
using UnityEngine;

[System.Serializable]
public class MovementConfig
{
    #region Fields

    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private LayerMask lm;
    [SerializeField] private float gravityStrength;

    #endregion

    #region Properties

    public Rigidbody2D Rb
    {
        get { return rb; }
        set { rb = value; }
    }
    public LayerMask Lm
    {
        get { return lm; }
    }
    public float GravityStrength
    {
        get { return gravityStrength; }
    }

    #endregion

}