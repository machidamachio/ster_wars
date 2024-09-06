using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTrench : MonoBehaviour
{
    public GameObject obj;
    Vector3 V;
    // Start is called before the first frame update
    void Start()
    {
        V=new Vector3(-10.8f, 2.18f, -362f);
        Instantiate(obj.gameObject,V,this.transform.rotation);
        V=new Vector3(-10.8f, -2.18f, -362f);
        Instantiate(obj.gameObject,V,this.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeTrenchCourse()
    {
        V=new Vector3(-10.8f, 2.18f, -362f);
        Instantiate(obj.gameObject,V,this.transform.rotation);
    }
        

}
