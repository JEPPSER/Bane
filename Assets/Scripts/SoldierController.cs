using UnityEngine;

public class SoldierController : MonoBehaviour {

    private float angle = 0f;
    private string[] keys = {"w", "a", "s", "d"}; // Movement keys
    private int[] res = {Screen.width, Screen.height}; // Window resolution

    public float moveSpeed = 5f;

    [SerializeField]
    Behaviour[] components;

    // Update is called once per frame
    void FixedUpdate () {
        move();  
        rotate();
	}

    private void Start()
    {

    }

    // Soldier movement on the x and y axis.
    private void move()
    {
        float x = 0f;
        float y = 0f;

        // Get the number of pressed direction keys.
        int downCount = 0;
        for (int i = 0; i < 4; i++)
        {
            if (Input.GetKey(keys[i]))
            {
                downCount++;
            }
        }

        // If 2 or more direction keys are pressed, decrease moveSpeed to 4.
        if(downCount > 1)
        {
            moveSpeed = 4;
        }

        // Get the key inputs and move the soldier.
        for (int i = 0; i < keys.GetLength(0); i++)
        {
            if (Input.GetKey(keys[i]))
            {
                y = Time.deltaTime * moveSpeed * Mathf.Sin((angle + 90 - i * 90) * Mathf.Deg2Rad);
                x = -Time.deltaTime * moveSpeed * Mathf.Cos((angle + 90 - i * 90) * Mathf.Deg2Rad);
                transform.Translate(new Vector3(x, y, 0f));
            }
        }

        moveSpeed = 5;
    }

    // Soldier rotation.
    private void rotate()
    {
        Vector3 mouse_pos = Input.mousePosition; // Mouse position in the window.
        Vector3 object_pos = new Vector3((float)res[0], (float)res[1]); // Middle of the window
        mouse_pos.x = mouse_pos.x - object_pos.x / 2;
        mouse_pos.y = mouse_pos.y - object_pos.y / 2;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg; // Calculate angle

        // Rotate the soldier.
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        components[0].transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
    }
}
