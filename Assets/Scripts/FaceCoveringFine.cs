using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCoveringFine : MonoBehaviour
{
    public int fineammount = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(Items.instance.faceCovering)
            {
                GameManager.instance.currentGold -= fineammount;
            }
        }
    }
}
