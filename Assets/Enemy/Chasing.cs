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

	// Use this for initialization
	void Start () {
		speed = 1f;
		health = 100.0f;
		maxHealth = 100.0f;
		healText = transform.Find("EnemyCanvas").Find("HealthBarText").GetComponent<Text>();
		healBar = transform.Find("EnemyCanvas").Find("MaxHealthBar").Find("HealthBar").GetComponent<Image>();
		rbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(target, Vector3.up);
		transform.position += transform.forward * speed * Time.deltaTime;
		healText.text = health.ToString();
		healBar.fillAmount = health / maxHealth;
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





