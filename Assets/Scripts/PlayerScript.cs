using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private float x = 0;
    private float y = 0;
    private int[] res;
    private string lastXDir = "";
    private string lastYDir = "";

    public float moveSpeed;

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

    // TODO: Try to clean this up somehow. Don't sacrifice the
    // movement for good code.
    private void move()
    {
        if(Input.GetKey("a") && Input.GetKey("d")) // Both left and right pressed.
        {
            if(lastXDir == "a")
            {
                x += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            }
            else if(lastXDir == "d")
            {
                x -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            }
        }
        else if(Input.GetKey("w") && Input.GetKey("s")) // Both up and down pressed.
        {
            if (lastYDir == "w")
            {
                y -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            }
            else if (lastYDir == "s")
            {
                y += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            }
        }
        else if(Input.GetKey("w") && Input.GetKey("a")) // Both up and left pressed.
        {
            x -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            y += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            lastYDir = "w";
            lastXDir = "a";
        }
        else if (Input.GetKey("w") && Input.GetKey("d")) // Both up and right pressed.
        {
            x += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            y += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            lastXDir = "d";
            lastYDir = "w";
        }
        else if (Input.GetKey("s") && Input.GetKey("a")) // Both down and left pressed.
        {
            x -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            y -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            lastXDir = "a";
            lastYDir = "s";
        }
        else if (Input.GetKey("s") && Input.GetKey("d")) // Both down and right pressed.
        {
            x += Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            y -= Mathf.Atan(1) * Time.deltaTime * moveSpeed;
            lastXDir = "d";
            lastYDir = "s";
        }
        else if (Input.GetKey("w")) // Only up pressed.
        {
            y += 1 * Time.deltaTime * moveSpeed;
            lastYDir = "w";
        }
        else if (Input.GetKey("a")) // Only left pressed.
        {
            x -= 1 * Time.deltaTime * moveSpeed;
            lastXDir = "a";
        }
        else if (Input.GetKey("s")) // Only down pressed.
        {
            y -= 1 * Time.deltaTime * moveSpeed;
            lastYDir = "s";
        }
        else if (Input.GetKey("d")) // Only right pressed.
        {
            x += 1 * Time.deltaTime * moveSpeed;
            lastXDir = "d";
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
