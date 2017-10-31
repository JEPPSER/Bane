using UnityEngine;

public class SoldierController : MonoBehaviour {

    private float angle = 0f;
    private string[] keys = {"w", "a", "s", "d"}; // Movement keys
    private string[] weaponStrings = { "PrimaryWeapon", "SecondaryWeapon" };
    private int[] res = {Screen.width, Screen.height}; // Window resolution
    private int currentWeapon = 0;

    private GameObject primaryWeapon;
    private Weapon primaryWeaponScript;

    private GameObject secondaryWeapon;
    private Weapon secondaryWeaponScript;

    private GameObject[] weapons = new GameObject[2];
    private Weapon[] weaponScripts = new Weapon[2];

    private Animator anim;

    public float moveSpeed = 5f;

    [SerializeField]
    Behaviour[] components;

    // Update is called once per frame
    void FixedUpdate () {
        move();  
        rotate();
        shoot();
        switchWeapon();
	}

    void Start()
    {
        anim = GetComponent<Animator>();
        weapons[0] = primaryWeapon;
        weapons[1] = secondaryWeapon;
        weaponScripts[0] = primaryWeaponScript;
        weaponScripts[1] = secondaryWeaponScript;
    }

    private void switchWeapon()
    {
        if (Input.GetKeyDown("q"))
        {
            currentWeapon = 1 - currentWeapon;
            anim.SetInteger("weapon", weaponScripts[currentWeapon].id);
        }
    }

    // Shoot gun
    private void shoot()
    {
        if (Input.GetMouseButtonDown(0) && primaryWeapon != null)
        {
            primaryWeaponScript.Shoot();
        }
    }

    private void addWeaponToInvetory(int index, Weapon weapon)
    {
        weapons[index] = weapon.gameObject;
        weapons[index].transform.position = this.transform.position;
        weapons[index].transform.SetParent(transform.Find(weaponStrings[index]));
        weaponScripts[index] = weapon;
        weapon.GetComponent<SpriteRenderer>().enabled = false;
    }

    // When use button is pressed.
    public void pickUpWeapon(Weapon weapon)
    {   
        if(weapons[currentWeapon] == null)
        {
            addWeaponToInvetory(currentWeapon, weapon);
            anim.SetInteger("weapon", weapon.id);
        }
        else if(weapons[1 - currentWeapon] == null)
        {
            addWeaponToInvetory(1 - currentWeapon, weapon);
        }
        else
        {
            weapons[currentWeapon].transform.SetParent(transform.parent);
            weaponScripts[currentWeapon].GetComponent<SpriteRenderer>().enabled = true;
            Physics2D.IgnoreCollision(weapons[currentWeapon].GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);

            addWeaponToInvetory(currentWeapon, weapon);
            anim.SetInteger("weapon", weapon.id);
        }        
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

        // Get direction key inputs and move soldier.
        if (Input.GetKey(keys[0]))
        {
            y += moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(keys[1]))
        {
            x -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(keys[2]))
        {
            y -= moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(keys[3]))
        {
            x += moveSpeed * Time.deltaTime;
        }

        if(x == 0 && y == 0)
        {
            anim.SetBool("isMoving", false);
        } else
        {
            anim.SetBool("isMoving", true);
        }

        transform.position = new Vector3(transform.position.x + x, transform.position.y + y, 0f);

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
