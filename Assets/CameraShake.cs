
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 defaultCameraPosition = new Vector3(0, 0, -10);

    private float tick;
    [SerializeField]
    private float shakeTime;
    [SerializeField]
    private float circleSize;
    [SerializeField]
    private float shakeSpeed;

   static bool shake;

    public delegate void TestDelegate();
    public TestDelegate testDelegate;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            StartShaking();
        }

        if (shake)
        {
            Shake();
        }

    }
    public void Shake()
    {
        transform.position = Vector3.Lerp(transform.position, (Vector3)Random.insideUnitCircle.normalized * circleSize, shakeSpeed);
        if ((tick += Time.deltaTime) >= shakeTime)
        {
            tick -= shakeTime;
            ResetShake();
        }
    }

    private void ResetShake()
    {
        shake = false;
        transform.position = defaultCameraPosition;
    }
    public static void StartShaking()
    {
        shake = true;
    }
}
