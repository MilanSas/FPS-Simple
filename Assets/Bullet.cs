using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float _speed = 100;
    [SerializeField]
    public float gravity = 9.8f;
    Vector3 _Velocity;
    bool hit;
    // Start is called before the first frame update
    void Start()
    {
        _Velocity = Vector3.forward * _speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        hit = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!hit)
        {
            
            
            transform.Translate(_Velocity * Time.deltaTime);
            _Velocity += Vector3.down * gravity * Time.deltaTime;

        }
       
    }
}
