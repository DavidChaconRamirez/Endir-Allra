using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform pfDashEffect;
        public GameObject dash;
	public float moveSpeed;
	public Rigidbody2D rb;
	public float dashForce=30;
        private float moveX,moveY;
	
	private Vector2 MoveDirection;
	
	private Vector2 mousePos;
	
	//public Camera cam;
	
	//variables dash
	public float cooldownTime;
	private float nextDashTime;
	private Animator anim;
	bool isCooldown = false;

    // Update is called once per frame
    void Start() {
    	anim = GetComponent<Animator>();
    }
    void Update()
    {	
		ProcessInputs();
	
    }
	void FixedUpdate()
	{
		Move();
	}
	
	void ProcessInputs()
	{
		moveX = Input.GetAxisRaw("Horizontal");
		moveY = Input.GetAxisRaw("Vertical");
		
		//mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
		
		MoveDirection = new Vector2(moveX, moveY);
		
		if (MoveDirection != Vector2.zero)
		{
			anim.SetFloat("movX", moveX);
			anim.SetFloat("movY", moveY);
			anim.SetBool("walking", true);
		}else{
			anim.SetBool("walking", false);
		}
		
		
		
	}
	
	void Move()
	{	
		if (isCooldown)
		{
				isCooldown = false;
		}
		
		if(Input.GetButton("Jump") && Time.time > nextDashTime){
				nextDashTime = Time.time + cooldownTime;
				StartCoroutine("PrimerInvoke1");
				rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed) * dashForce;
                                if (moveX == 1 || moveX == -1 || moveY == 1 || moveY == -1)
				{
					HandleDash();
				}
				
				isCooldown = true;
		}else{
			anim.SetBool("Dash", false);	
			rb.velocity = new Vector2(MoveDirection.x * moveSpeed, MoveDirection.y * moveSpeed);
		}

		
		
		
		/*Vector2 lookDir = mousePos - rb.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg - 90f;
		rb.rotation = angle;*/
	}
	
	void HandleDash()
	{
		Vector3 beforeDashPosition = transform.position;
		Transform dashEffectTransform = Instantiate(pfDashEffect, beforeDashPosition, Quaternion.identity);
		dashEffectTransform.eulerAngles = new Vector3(0,0, UtilsClass.GetAngleFromVectorFloat(MoveDirection));
		float dashEffectWidth = 0.05f;
		dashEffectTransform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
	}
	IEnumerator PrimerInvoke1 ()
    {

        dash.SetActive(false);
	yield return new WaitForSeconds(2);
	dash.SetActive(true);
    }
}

