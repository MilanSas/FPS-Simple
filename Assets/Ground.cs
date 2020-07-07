using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField]
    private GameObject _hitmarkerPrefab;
    [SerializeField]
    private Target _target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 hitLocation;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.point);
            Instantiate(_hitmarkerPrefab, contact.point, Quaternion.identity);
            Destroy(collision.collider.transform.gameObject);
            hitLocation = contact.point;
        }
        float distance = Vector3.Distance(collision.contacts[0].point, _target.transform.position);
        Debug.Log("distance Floor" + distance);
        _target.CalculateScore(distance, false);

    }
}
