using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exampleScript : MonoBehaviour
{
    // declare necessary things
    public GameObject cube_prefab; // public for editor DRAG&DROP functionality, can be seen in inspector
    GameObject cube_GO; // f. ex gameobjects you need
    public float spin_rate; // public property is shown in the editor, check the inspector! easy to change there.
    // TRY: You can change public properties like spin_rate AT RUNTIME to test them! However this will not change the save on its own.
    bool spinning;

    // Start is called before the first frame update
    // theres also Awake() that is called before Start
    void Start()
    {
        Debug.Log("this is how to print in editor log");
        var currentpos = transform.localPosition; // gameObject, transform etc to access properties of the GameObject that THIS SCRIPT IS ATTACHED TO
        // set starting values (you can do this above but its cleaner to do here if you have a lot of other things to declare)
        spin_rate = .1f;
        spinning = false;

        // this is how you set components in objects if you need to access just a specific thing:
        // example: set renderer to a variable and set its materials color to red
        // this object also doesnt exist so this should give an error in the debug log
        MeshRenderer cube_renderer = cube_GO.GetComponent<MeshRenderer>();
        cube_renderer.material.color = Color.red;
    }

    // Update is called once per frame
    // can be used as the main loop or observers as well
    void Update()
    {
        if (cube_GO && spinning)
        {
            // so accessing the rotate function from the cube_GO gameobjects transform component here
            cube_GO.transform.Rotate(new Vector3(spin_rate, -spin_rate, spin_rate / 2));
        }
    }

    // function that is accessed from the UI button
    public void spin_cube()
    {
        if (cube_GO)
        {
            Debug.Log(cube_GO.transform.rotation.ToString());   
            spinning = !spinning; // boolean for the udpate loop
        }   
        else
        {
            // instantiate a gameobject from prefab "Glorious_cube" AND set it to a variable for access ("cube_GO")
            cube_GO = Instantiate(cube_prefab);
        }
    }
}
