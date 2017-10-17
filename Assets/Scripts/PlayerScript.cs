using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private float x = 0;
    private float y = 0;
    private float sensitivity = 3f;
    private int[] res;

    [SerializeField]
    Behaviour[] components;

    // Update is called once per frame
    void FixedUpdate () {
        move();
        rotate();
	}

    private void Start()
    {
        // Getting the resolution of the window.
        res = new int[2];
        res[0] = Screen.width;
        res[1] = Screen.height;
    }

    private void move()
    {
        if(Input.GetKey("a") && Input.GetKey("d"))
        {
            // No movement
        }
        else if(Input.GetKey("w") && Input.GetKey("s"))
        {
            // No movement
        }
        else if(Input.GetKey("w") && Input.GetKey("a"))
        {
            x -= Mathf.Atan(1);
            y += Mathf.Atan(1);
        }
        else if (Input.GetKey("w") && Input.GetKey("d"))
        {
            x += Mathf.Atan(1);
            y += Mathf.Atan(1);
        }
        else if (Input.GetKey("s") && Input.GetKey("a"))
        {
            x -= Mathf.Atan(1);
            y -= Mathf.Atan(1);
        }
        else if (Input.GetKey("s") && Input.GetKey("d"))
        {
            x += Mathf.Atan(1);
            y -= Mathf.Atan(1);
        }
        else if (Input.GetKey("w"))
        {
            y += 1;
        }
        else if (Input.GetKey("a"))
        {
            x -= 1;
        }
        else if (Input.GetKey("s"))
        {
            y -= 1;
        }
        else if (Input.GetKey("d"))
        {
            x += 1;
        }

        transform.position = new Vector3(x, y);
    }

    private void rotate()
    {
        Vector3 mouse_pos = Input.mousePosition; // Mouse position in the window.
        Vector3 object_pos = new Vector3((float) res[0], (float) res[1]); // Middle of the window
        mouse_pos.x = mouse_pos.x - object_pos.x / 2;
        mouse_pos.y = mouse_pos.y - object_pos.y / 2;
        float angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg; // Calculate angle

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle)); // Rotate player
        components[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); // Rotate camera
    }
}
