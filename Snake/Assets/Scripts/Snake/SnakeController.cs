	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	[RequireComponent (typeof (GravityBody))]
	public class SnakeController : MonoBehaviour {
		
		public float walkSpeed = 6;
		public int initSize;
		public float rotationSpeed;
		Vector3 moveAmount;
		Vector3 smoothMoveVelocity;
		Rigidbody head;
		Vector3 moveDir = new Vector3(0,0, 1);
		//bool temp=true;
		public GameObject body;
		//public int initSize;
		public float minDis=.25f;
		List<Rigidbody> bodyParts= new List<Rigidbody>();
		Rigidbody currBP;
		Rigidbody prevBP;

		int size=1;


		void Start () {
			head =GetComponent<Rigidbody> ();
			bodyParts.Add (head);
			size = 1;


			for(int i=0;i<initSize;i++)
			{
				addBodyPart ();
			}
		}

		void Update() {

			// Calculate movement:
			float inputX = Input.GetAxisRaw("Horizontal");//-1,1
			//float inputY = Input.GetAxisRaw("Vertical");
			float dir;
			float angle;

			if(inputX !=0)
				bodyParts[0].transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * inputX);


			Vector3 targetMoveAmount = moveDir * walkSpeed;
			moveAmount = targetMoveAmount; //Vector3.SmoothDamp(moveAmount,targetMoveAmount,ref smoothMoveVelocity,.15f);

			
			// Jump
			/*if (Input.GetButtonDown("Jump")) {
				if (grounded) {
					rigidbody.AddForce(transform.up * jumpForce);
				}
			}*/

			// Grounded check
			/*Ray ray = new Ray(transform.position, -transform.up);
			RaycastHit hit;*/

			/*if (Physics.Raycast(ray, out hit, 1 + .1f, groundedMask)) {
				grounded = true;
			}
			else {
				grounded = false;
			}*/
		}

		void FixedUpdate() {
			move ();
			// Apply movement to rigidbody
			Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
			head.MovePosition (head.transform.position + localMove);
		}
		void move()
		{	
			float dis;
		Vector3 pos;
			for(int i=1;i<size;i++)
			{
				currBP = bodyParts [i];
				prevBP = bodyParts [i - 1];

				dis = Vector3.Distance (prevBP.transform.position, currBP.transform.position);
				Vector3 newPos = prevBP.transform.position;

				//newPos.y = bodyParts [0].transform.position.y;

				float T = Time.deltaTime * dis / minDis * walkSpeed;
				if (T > 0.5f)
					T = 0.5f;
				
				currBP.transform.position = Vector3.Slerp (currBP.position, newPos, T);
				currBP.transform.rotation = Quaternion.Slerp (currBP.rotation, prevBP.rotation, T);
			}
		}
		void OnCollisionEnter (Collision other)
		{
			if (other.gameObject.CompareTag ("Pick Up"))
			{
				Destroy (other.gameObject);
				addBodyPart ();
			}
		}

		void addBodyPart()
		{
			Rigidbody newPart;
			Vector3 pos = bodyParts [bodyParts.Count - 1].transform.position;
			newPart = Instantiate (body,pos, bodyParts[bodyParts.Count-1].transform.rotation).GetComponent<Rigidbody>();
			newPart.transform.localScale = Vector3.one * Random.Range( 1, 2);
			
			bodyParts.Add (newPart);
			size++;
			
		}
		
	}
