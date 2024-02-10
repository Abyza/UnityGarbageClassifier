using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hoppermanager : MonoBehaviour
{
    public List<GameObject> gameObjectsList;

    public GameObject circleItem;
    public Transform spawnPoint;

    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

    }

    public void openHopper(int slot)
    {
        Instantiate(circleItem, spawnPoint.position, Quaternion.identity);
        gameObjectsList[slot].GetComponent<hopper>().openHopper();
    }


}
