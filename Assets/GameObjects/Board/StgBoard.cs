using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StgBoard : MonoBehaviour
{
    //Cached components
    Grid grid = null;

    // Start is called before the first frame update
    void Start()
    {
        initCachedGameComponents();
    }

    // Update is called once per frame
    void Update()
    {
        //Do nothing
    }

    private void initCachedGameComponents()
    {
        grid = gameObject.GetComponent<Grid>();
    }
}
