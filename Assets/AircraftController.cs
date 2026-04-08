using UnityEngine;

public class AircraftController : MonoBehaviour
{
    public float speed = 0f;
    public float maxSpeed = 20f;
    public float acceleration = 10f;
    public float turnSpeed = 50f;
    public float liftForce = 5f;
    void Update()
    {
        // ileri hızlanma
        if (Input.GetKey(KeyCode.W))
        {
            speed += acceleration * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            speed -= acceleration * Time.deltaTime;
        }

        speed = Mathf.Clamp(speed, 0, maxSpeed);

        // sadece hareket ediyorsa dön
        if (speed > 1f)
        {
            float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
            transform.Rotate(0, turn, 0);
        }
        // hızlanınca hafif yükselme
        if (speed > 10f)
        {
        transform.Translate(0, liftForce * Time.deltaTime, 0);
        }

        // ileri hareket
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}