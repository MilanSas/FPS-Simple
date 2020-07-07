using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
public class GunAgent : Agent
{
    [SerializeField]
    private Bullet _bulletPrefab;
    [SerializeField]
    private Target _target;
    [SerializeField]
    //private Ground plane;
    //[SerializeField]
    bool shot = false;
    [SerializeField]
    private float _fireRate = 1f;
    private float _nextFire = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        if (!shot)
        {
            RequestDecision();
        }
        //Rewards  
        if (_target.score != 0)
        {
            Debug.Log("Score " + _target.score);
            AddReward(_target.score);
            Done();
        }
    }

    public override void CollectObservations()
    {
        AddVectorObs((((_target.transform.position.z - 50) / 50) * 2) - 1);
        AddVectorObs((((_target.transform.position.y - 25) / 25) * 2) - 1);
    }


    public override void AgentAction(float[] vectorAction)
    {
        float rotation = (vectorAction[0] + 1) / 2 * -80;
        float power = (vectorAction[1] + 1) / 2 * 30;

        if (Time.time > _nextFire)
        {
            Shoot(rotation, power);
        }


    }


    public void Shoot(float rotation, float power)
    {
        _nextFire = Time.time + _fireRate;
        transform.rotation = Quaternion.Euler(rotation, 0, 0);
        
        var bullet = Instantiate(_bulletPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), this.transform.rotation);
        bullet._speed = power;
        shot = true;
    }
    public override void AgentReset()
    {
        _target.SetPosition(new Vector3(0, Random.Range(25f, 50.0f), Random.Range(50f, 100.0f)));
        _target.ResetScore();
        shot = false;
    }

    public override float[] Heuristic()
    {
        var action = new float[2];
       
        if (Input.GetKey(KeyCode.Space))
        {
            action[0] = (0);//Random.value * 2 -1);
            action[1] = (0);//Random.value * 2 -1);
        }

        return action;
    }
}
