using UnityEngine;

[System.Serializable]
public class MovementData
{
    #region Fields

    [SerializeField] 
    private float horizontalDirection;

    [SerializeField] 
    private float verticalVelocity;

    [SerializeField] 
    private float jumpForce;

    [SerializeField] 
    private float movementSpeed;

    [SerializeField]
    private float gravityStrength;

    [SerializeField]
    private MovementStates playerState;

    #endregion

    #region Properties

    public float HorizontalDirection
    {
        get { return horizontalDirection; }
        set { horizontalDirection = value; }
    }

    public float VerticalVelocity
    {
        get { return verticalVelocity; }
        set { verticalVelocity = value; }
    }

    public float JumpForce
    {
        get { return jumpForce; }
    }

    public float MovementSpeed
    {
        get { return movementSpeed; }
    }

    public float GravityStrength
    { get { return gravityStrength; } }

    public MovementStates PlayerState
    {
        get { return playerState; }
        set { playerState = value; }
    }

    #endregion

}