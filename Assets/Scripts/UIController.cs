using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        int start = 610-140;
        for (int i = 0; i < 20; i++)
        {
            var instantiate = Instantiate(image);
            instantiate.transform.parent = this.gameObject.transform;
            instantiate.transform.localPosition=Vector3.zero;
            
            instantiate.transform.localPosition =new Vector3(0,start,0);
            start -= 140;
            Debug.Log(start);
        }
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
