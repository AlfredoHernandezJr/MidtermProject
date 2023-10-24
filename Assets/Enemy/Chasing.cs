using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chasing : MonoBehaviour {

	public Transform target;
	public float speed;

	private float health;
	private float maxHealth;
	public GameObject explostion, canva;
	private Rigidbody rbody;

	private Text healText;
	private Image healBar;

    public float moveSpeed = 5.0f;
    public float detectionDistance = 10.0f; 
    public Transform player;
    public float stareDistance = 5.0f; 
    private float distanceMoved = 0.0f;
    private bool isChasing = false;
    private Vector3 initialPosition;


   
    void Start () {
		speed = 1f;
		health = 100.0f;
		maxHealth = 100.0f;
		healText = transform.Find("EnemyCanvas").Find("HealthBarText").GetComponent<Text>();
		healBar = transform.Find("EnemyCanvas").Find("MaxHealthBar").Find("HealthBar").GetComponent<Image>();
		rbody = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }
	
	
	void Update () {
		
		healText.text = health.ToString();
		healBar.fillAmount = health / maxHealth;
        float playerDistance = Vector3.Distance(transform.position, player.position);

        if (playerDistance <= stareDistance)
        {
            Stare();
            if (playerDistance <= 13.0f)
            {
                isChasing = true;
            }
            else
            {
                isChasing = false;
                transform.position = initialPosition;
            }
        }
        else
        {
            isChasing = false;
            Patrol();
        }
        if (isChasing)
        {
            chase();
        }
    }

    private void Patrol()
    {
        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        distanceMoved += moveSpeed * Time.deltaTime;

       
        if (distanceMoved >= 3.0f)
        {
            transform.Rotate(Vector3.up, 180.0f);
            distanceMoved = 0.0f;
        }
    }

    private void Stare()
    {
        transform.LookAt(target, Vector3.up);

    }


    void chase()
    {
        transform.LookAt(target, Vector3.up);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col) {
		//Debug.Log(col.gameObject.tag);
		if(col.gameObject.tag == "Bullet") {
			health -= 10;
			if(health < 1) {
                if (Application.loadedLevelName == "sceneSlowEnemies")
                    canva.GetComponent<canvasScriptSlowEnemies>().badguyDown();
				else if (Application.loadedLevelName == "sceneAIEnemies")
                    canva.GetComponent<canvasScriptAI>().badguyDown();
                Destroy(this);
				Instantiate(explostion, transform.position, transform.rotation);
				Destroy(gameObject);
			}
		}
        if (col.gameObject.tag == "Obstacle")
        {
            if (rbody.velocity.magnitude < .25)
            {
                rbody.AddForce(Vector3.up * Mathf.Sqrt(3 * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            }
            Vector3 forwardForce = transform.forward * speed;
            rbody.velocity += forwardForce;
        }
    }
}





