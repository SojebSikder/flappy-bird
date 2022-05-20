using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DragonScript : MonoBehaviour {
	 
	private Rigidbody2D myRigidBody;
	private Animator myAnimator;
	private float jumpForce;
	public bool isAlive;

    void Start () {
        isAlive = true;

		myRigidBody = gameObject.GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator> ();

		jumpForce = 10f;
		myRigidBody.gravityScale = 5f;

	}
		

	// Update is called once per frame
	void Update () {
		if (isAlive) {
			if (Input.GetMouseButton (0)) {
                // resume when player ready
                Time.timeScale = 1f;
                Flap ();
			} 
			CheckIfDragonVisibleOnScreen ();
		} 
	}


	void Flap(){
		myRigidBody.velocity = 
			new Vector2 (0,jumpForce);
		
		myAnimator.SetTrigger ("Flap");

	}


	void OnCollisionEnter2D(Collision2D target) {
		if (target.gameObject.tag == "Obstacles") {
			isAlive = false;
			Time.timeScale = 0f;
            // game over
            LoadMenu();

        }
	}

	void CheckIfDragonVisibleOnScreen() {
		if (Mathf.Abs(gameObject.transform.position.y) > 5.3f) {
			isAlive = false;
			Time.timeScale = 0f;
            // game over
            LoadMenu();
        }
	}

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}















