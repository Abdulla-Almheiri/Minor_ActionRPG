using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXTestScript : MonoBehaviour
{
    public GameObject PrefabToSpawn;
    public Transform Loc1, Loc2, Loc3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            var spawn1 =  Instantiate(PrefabToSpawn, Loc1);
            Destroy(spawn1, 3f);
            spawn1.transform.parent = null;

            var spawn2 = Instantiate(PrefabToSpawn, Loc2);
            Destroy(spawn2, 3f);
            spawn2.transform.parent = null;


            var spawn3 = Instantiate(PrefabToSpawn, Loc3);
            Destroy(spawn3, 3f);
            spawn3.transform.parent = null;

        }
    }
}
