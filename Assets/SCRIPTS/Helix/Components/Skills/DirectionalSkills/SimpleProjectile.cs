using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleProjectile : MonoBehaviour
{

    public ProjectileEvents onCollision;

    private float speed;
    private Vector3 direction;
    private Vector3 start;
    private float decayRange;

    // Use this for initialization
    void Start()
    {
		
    }

    void Awake()
    {
        
    }

    public void Initialize(float speed, Vector3 startPoint, Vector3 direction, float decayRange)
    {
        this.transform.rotation = Quaternion.LookRotation(direction);
        this.transform.position = startPoint;
        this.speed = speed;
        this.start = startPoint;
        this.direction = direction;
        this.decayRange = decayRange;
    }
	
    // Update is called once per frame
    void Update()
    {
        transform.position += direction.normalized * speed;
        if (Vector3.Distance(transform.position, start) > decayRange && decayRange != 0)
        {            
            GameObject.Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider collider)
    {
        if (onCollision != null)
        {  
            onCollision(new ProjectileEventArgs(this.gameObject, collider.gameObject));
        }
    }
}

public delegate void ProjectileEvents(ProjectileEventArgs args);

public class ProjectileEventArgs
{
    public GameObject target { get; set; }

    public GameObject sender { get; set; }

    public ProjectileEventArgs(GameObject sender, GameObject target)
    {
        this.target = target;
        this.sender = sender;
    }
}
