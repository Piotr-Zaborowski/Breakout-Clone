using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    public int hits=1;
    public int points = 100;
    public Vector3 rotator;
    public Material hitMaterial;

    Material orgMaterial;
    new Renderer renderer;
    
    void Start()
    {
        transform.Rotate(rotator*(transform.position.x+transform.position.y));
        renderer = GetComponent<Renderer>();
        orgMaterial = renderer.sharedMaterial;
    }

    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.Rotate(rotator);
    }

    private void OnCollisionEnter(Collision collision)
    {
        hits--;
        if(hits<=0)
        {
            GameManager.Instance.Score += points;
            Destroy(gameObject);
        }
        renderer.sharedMaterial = hitMaterial;
        Invoke("Restorematerial", 0.05f);
         
    }
    void Restorematerial()
    {
        renderer.sharedMaterial = orgMaterial;
    }

}
