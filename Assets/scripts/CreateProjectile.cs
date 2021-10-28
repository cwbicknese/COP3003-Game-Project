using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateProjectile : MonoBehaviour
{

    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Created Projectile");
        //Instantiate(projectile, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Debug.Log("Created Projectile");
            projectile.SetActive(true);
            GameObject bullet = Instantiate(projectile, new Vector3(1f, .5f, 0), Quaternion.identity);
            bullet.transform.Translate(Vector3.forward * 15f * Time.deltaTime);
        }
    }
}
