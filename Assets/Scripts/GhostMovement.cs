using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    public float speed; // make private tmrw

    private int direction; //-1 = down, 1 = up

    private float maxY;
    private float minY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 1;
        minY = 1.296152f;
        maxY = 3.4f;
    }

    // Update is called once per frame
    void Update()
    {
        // move the ghost
        Vector3 newPos = speed * Time.deltaTime * direction * Vector3.up + transform.position;

        if ((newPos.y > maxY && direction == 1) || (newPos.y < minY && direction == -1))
        {
            direction *= -1;
        }
        else
        {
            transform.position = newPos;
        }
    }
}
