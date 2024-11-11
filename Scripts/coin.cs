using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{

    private GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Destroy(this.gameObject, 3f); 
    }

    // Update is called once per frame
    void Update()
    {}
    void OnMouseDown()
    {
        GameManager.EarnScore(1);
        Destroy(gameObject);
    }
    

    
}
