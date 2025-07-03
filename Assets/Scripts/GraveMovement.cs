using UnityEngine;

public class GraveMovement : MonoBehaviour
{
    public float speed; // make private tmrw

    private int direction; //-1 = left, 1 = right

    private float maxZAng;
    private float minZAng;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
        minZAng = -40;
        maxZAng = 30;
    }

    // Update is called once per frame
    void Update()
    {
        // move the ghost
        float newAng = speed * Time.deltaTime * direction;

        if ((FixAngle(transform.localEulerAngles.z) > maxZAng && direction == 1) || (FixAngle(transform.localEulerAngles.z) < minZAng && direction == -1))
        {
            direction *= -1;
        }
        else
        {
            transform.Rotate(0, 0, newAng, Space.Self);
        }
    }

    //funciton to turn angles negative
    private float FixAngle(float angle)
    {
        if (angle > 180f)
        {
            return angle - 360f;
        }
        return angle;
    }
}
