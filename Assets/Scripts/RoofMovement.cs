using UnityEngine;

public class RoofMovement : MonoBehaviour
{
    public float speed; // 5 works nicely for speed

    private int direction; // 0 = not moving, -1 = down, 1 = up
    private float minY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = 0;
        minY = -0.39f;
    }

    // Update is called once per frame
    void Update()
    {
        // get user input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Debug.Log("Up Key was pressed, move up");
            direction = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            Debug.Log("Down Key was pressed, move down");
            direction = -1;
        }
        else
        {
            direction = 0;
        }



        // move the roof
        Vector3 newPos = speed * Time.deltaTime * direction * Vector3.up + transform.position;

        //clamp this position
        if (newPos.y > minY)
        {
            transform.position = newPos;
        }
    }
}
