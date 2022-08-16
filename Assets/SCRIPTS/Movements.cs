using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DragonBones;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movements : MonoBehaviour
{
    public AudioSource obtainedOrb;

    public float speed;
    public Vector2 moveDirection;
    public Rigidbody2D rb;
    public GameObject AbsorbButton;
    private UnityArmatureComponent player;

    public GameObject pauseMenuUI;
    public GameObject resumeGame;
    public GameObject ObtainedOrbUI;
    public GameObject CubeUI1;
    public GameObject CubeUI2;
    public GameObject CubeUI3;
    public GameObject CompletedUI;
    public GameObject ValComplete;
    public GameObject Damage;
    public GameObject Title;


    public GameObject GuiElements;
    public GameObject GameOverUI;



    [SerializeField] Image lifeFill;
    float life = 1f;

    [SerializeField] Image orbFill;
    float orb = 1f;


    // Start is called before the first frame update
    void Start()
    {
        obtainedOrb = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        player = GetComponent<UnityArmatureComponent>();
        Title.SetActive(true);
    }
    void Update()
    {
        ProcessInputs();

        if (pauseMenuUI.active == true)
        {
            Time.timeScale = 0f;
        }
        if (pauseMenuUI.active == false && ObtainedOrbUI.active == false && CubeUI1.active == false && CubeUI2.active == false && CubeUI3.active == false)
        {
            Time.timeScale = 1f;

            if (Input.GetKeyDown(KeyCode.A))
            {
                player.animation.Play("RUNNING_LEFT");
            }

            else if (Input.GetKeyUp(KeyCode.D) && Input.GetKey("a"))
            {
                player.animation.Play("RUNNING_LEFT");
            }

            else if (Input.GetKeyUp(KeyCode.A) && Input.GetKey("d"))
            {
                player.animation.Play("RUNNING_RIGHT");
            }

            else if (Input.GetKeyDown(KeyCode.D))
            {
                player.animation.Play("RUNNING_RIGHT");
            }


            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (player.animation.lastAnimationName == "RUNNING_LEFT")
                {
                    player.animation.Play("RUNNING_LEFT");
                }
                else if (player.animation.lastAnimationName == "RUNNING_RIGHT")
                {
                    player.animation.Play("RUNNING_RIGHT");
                }
                else
                {
                    player.animation.Play("RUNNING_RIGHT");
                }

            }

            else if (Input.GetKeyDown(KeyCode.W))
            {
                if (player.animation.lastAnimationName == "RUNNING_LEFT")
                {
                    player.animation.Play("RUNNING_LEFT");
                }
                else if (player.animation.lastAnimationName == "RUNNING_RIGHT")
                {
                    player.animation.Play("RUNNING_RIGHT");
                }
                else
                {
                    player.animation.Play("RUNNING_RIGHT");
                }
            }

            if (!Input.anyKey)
            {
                player.animation.Stop("RUNNING_LEFT");
                player.animation.Stop("RUNNING_RIGHT");

            }
        }


    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag.Equals("enemiesx1"))
        {
            Debug.Log("HIT");

            
            RemoveLife();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        Damage.SetActive(false);
    }

    public void RemoveLife ()
	{
        CubeUI1.SetActive(false);
        CubeUI2.SetActive(false);
        CubeUI3.SetActive(false);
        Damage.SetActive(true);

        //code to remove hearts goes here
        if (life > 0.2f) 
        {
			life -= 0.2f;
			lifeFill.fillAmount = life;
		}

		if (life <= 0.2f) 
        {
			/*isGameover = true;*/
			rb.AddTorque (50f);
			rb.AddRelativeForce (Vector2.up * 6f);
			rb.constraints = RigidbodyConstraints2D.None;
			rb.GetComponent <BoxCollider2D> ().enabled = false;
			Invoke ("Restart", 3f);

            GuiElements.SetActive(false);
            GameOverUI.SetActive(true);
        }  
    }
    public void RemoveOrb()
    {
        if (ObtainedOrbUI.active == true)
        {
            //code to add orb goes here
            if (orb > 0.1f)
            {
                obtainedOrb.Play();
                orb -= 0.1f;
                orbFill.fillAmount = orb;
            }

        }
        
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
            if (ObtainedOrbUI.active == false && CubeUI1.active == false && CubeUI2.active == false && CubeUI3.active == false)
            {
                rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
            }
            if (ObtainedOrbUI.active == true || CubeUI1.active == true || CubeUI2.active == true || CubeUI3.active == true)
            {
                rb.velocity = new Vector2(0, 0);
                player.animation.Stop("RUNNING_LEFT");
                player.animation.Stop("RUNNING_RIGHT");
            }
            
            if (!player.animation.isPlaying)
            {
                player.animation.Play("IDLE", -1);
            }
    }

        // For GUI ELEMENTS
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Title.SetActive(false);
        if (!collider.tag.Equals("exit"))
        {
            AbsorbButton.SetActive(true);
        }

        else
        {
            if (ValComplete.active == true)
            {
                CompletedUI.SetActive(true);
                GuiElements.SetActive(false);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        
        AbsorbButton.SetActive(false);
    }

}