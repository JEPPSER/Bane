using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private string[] keys = { "w", "a", "s", "d" };
    private bool[] directions = { false, false, false, false };
    private float x = 0;
    private float y = 0;
    private float sensitivity = 5f;
    private float angle = 0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        for(int i=0; i < keys.Length; i++)
        {
            directions[i] = Input.GetKey(keys[i]);
        }

        move(directions);
        rotate();
	}

    private void move(bool[] directions)
    {
        if (directions[0])
        {
            y += 1;
        }
        if (directions[1])
        {
            x -= 1;
        }
        if (directions[2])
        {
            y -= 1;
        }
        if (directions[3])
        {
            x += 1;
        }
        transform.position = new Vector3(x, y);
    }

    private void rotate()
    {
        float xRot = Input.GetAxis("Mouse X");
        angle += xRot;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
