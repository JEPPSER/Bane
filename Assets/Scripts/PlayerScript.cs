using UnityEngine;

public class PlayerScript : MonoBehaviour {

    private string[] keys = { "w", "a", "s", "d" };
    private bool[] directions = { false, false, false, false };
    private float x = 0;
    private float y = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //if(!isLocalPlayer)
       // {
       //     return;
        //}

        for(int i=0; i < keys.Length; i++)
        {
            directions[i] = Input.GetKey(keys[i]);
        }
        move(directions); 
	}

    private void move(bool[] directions)
    {
        if (directions[0])
        {
            y -= 2;
        }
        if (directions[1])
        {
            x -= 2;
        }
        if (directions[2])
        {
            y += 2;
        }
        if (directions[3])
        {
            x += 2;
        }
        transform.SetPositionAndRotation(new Vector3(x, y), new Quaternion(0, 0, 0, 0));
    }
}
