using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private int[] res;
    private string lastXDir = "";
    private string lastYDir = "";
    private float angle = 0f;

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
        float x = 0f;
        float y = 0f;

        if (Input.GetKey("a") && Input.GetKey("d")) // Both left and right pressed.
        {
            if(lastXDir == "a")
            {
                y += Time.deltaTime * moveSpeed * Mathf.Sin(angle * Mathf.Deg2Rad) * 0.5f;
                x -= Time.deltaTime * moveSpeed * Mathf.Cos(angle * Mathf.Deg2Rad) * 0.5f;
            }
            else if(lastXDir == "d")
            {
                y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 180) * Mathf.Deg2Rad) * 0.5f;
                x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 180) * Mathf.Deg2Rad) * 0.5f;
            }
        }
        else if(Input.GetKey("w") && Input.GetKey("s")) // Both up and down pressed.
        {
            if (lastYDir == "w")
            {
                y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 90) * Mathf.Deg2Rad) * 0.5f;
                x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 90) * Mathf.Deg2Rad) * 0.5f;
            }
            else if (lastYDir == "s")
            {
                y += Time.deltaTime * moveSpeed * Mathf.Sin((angle - 90) * Mathf.Deg2Rad) * 0.5f;
                x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle - 90) * Mathf.Deg2Rad) * 0.5f;
            }
        }
        else if(Input.GetKey("w") && Input.GetKey("a")) // Both up and left pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 45) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 45) * Mathf.Deg2Rad);
            lastYDir = "w";
            lastXDir = "a";
        }
        else if (Input.GetKey("w") && Input.GetKey("d")) // Both up and right pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 135) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 135) * Mathf.Deg2Rad);
            lastXDir = "d";
            lastYDir = "w";
        }
        else if (Input.GetKey("s") && Input.GetKey("a")) // Both down and left pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle - 45) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle - 45) * Mathf.Deg2Rad);
            lastXDir = "a";
            lastYDir = "s";
        }
        else if (Input.GetKey("s") && Input.GetKey("d")) // Both down and right pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle - 135) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle - 135) * Mathf.Deg2Rad);
            lastXDir = "d";
            lastYDir = "s";
        }
        else if (Input.GetKey("w")) // Only up pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 90) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 90) * Mathf.Deg2Rad);
            lastYDir = "w";
        }
        else if (Input.GetKey("a")) // Only left pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin(angle * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos(angle * Mathf.Deg2Rad);
            lastXDir = "a";
        }
        else if (Input.GetKey("s")) // Only down pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle - 90) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle - 90) * Mathf.Deg2Rad);
            lastYDir = "s";
        }
        else if (Input.GetKey("d")) // Only right pressed.
        {
            y += Time.deltaTime * moveSpeed * Mathf.Sin((angle + 180) * Mathf.Deg2Rad);
            x -= Time.deltaTime * moveSpeed * Mathf.Cos((angle + 180) * Mathf.Deg2Rad);
            lastXDir = "d";
        }
        transform.Translate(new Vector3(x, y, 0f));
    }

    private void rotate()
    {
        Vector3 mouse_pos = Input.mousePosition; // Mouse position in the window.
        Vector3 object_pos = new Vector3((float)res[0], (float)res[1]); // Middle of the window
        mouse_pos.x = mouse_pos.x - object_pos.x / 2;
        mouse_pos.y = mouse_pos.y - object_pos.y / 2;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg; // Calculate angle

        // Rotate the player graphics.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        components[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
