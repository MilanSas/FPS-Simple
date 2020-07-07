using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private GameObject _hitmarkerPrefab;
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void ResetScore()
    {
        score = 0;
    }

    public void SetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
    }

    public float CalculateScore(float distance, bool HitTarget)
    {
        score = 0;

        if (HitTarget)
        {
            score += 100;
        }

        score += 100 - distance;

        return score;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 hitLocation;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.Log(contact.point);
            Instantiate(_hitmarkerPrefab, contact.point + new Vector3(0, 0, -1f) , Quaternion.identity);
            Destroy(collision.collider.transform.gameObject);
            hitLocation = contact.point;
        }
        float distance = Vector3.Distance(collision.contacts[0].point, transform.position);
        Debug.Log("distance" + distance);
        CalculateScore(distance, true);
    }
}
