using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using EZCameraShake;

public class Movement : MonoBehaviour
{
    public int speed;
    public float fallMulti = 2.5f;
    public float lowJump = 2f;

    public GameObject _cam;
    public GameObject _deathCam;
    public GameObject _finishCam;

    Rigidbody rb;

    public TutorialCanvas _canvas;

    public ParticleSystem _pickupParticle;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //movement 
        transform.Translate(Time.deltaTime * speed, 0, 0);

        Vector3 pos = transform.position;

        pos.z = Mathf.Clamp(transform.position.z, -1, 1);

        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if(transform.position.z == 1)
            {
                //
            } 
            else 
            {
                transform.Translate(0f, 0f, 1f);
                Mathf.RoundToInt(transform.position.z);

                //float _moveLeft = Input.GetAxisRaw("Horizontal");
                //float _moveRight = Input.GetAxisRaw("Vertical");

                //Vector3 movement = new Vector3(_moveLeft, 0.0f, _moveRight);

                //rb.AddForce(movement * speed);
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (transform.position.z == -1)
            {
                //
            }
            else
            {
                transform.Translate(0f, 0f, -1f);
            }
        }

        //jump
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
        }
    }

    public ExplosionTest _reference;
    public Finish _finishRef;



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

            _reference.Explode();

           // _shakeInstance.StartFadeOut(3f);

            //_cam.GetComponent<FollowPlayer>().enabled = false;
           //_cam.GetComponent<Camera>().enabled = false;

           // _deathCam.GetComponent<Camera>().enabled = true;

            _deathCam.GetComponent<Animator>().Play("PanOut");

            StartCoroutine("Reload");

            GetComponent<Movement>().enabled = false;

            GetComponent<Rigidbody>().isKinematic = true;
        }

        if(other.gameObject.tag == "Slow")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.3f;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            _canvas.FadeAD();
        }

        if (other.gameObject.tag == "Fast")
        {
            Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if (other.gameObject.tag == "Jump")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.3f;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            _canvas.FadeJump();
        }

        if (other.gameObject.tag == "Finish")
        {
            //_cam.GetComponent<FollowPlayer>().enabled = false;

            //_cam.GetComponent<Animator>().Play("FinishLevel");

            _cam.GetComponent<Camera>().enabled = false;
            _finishCam.GetComponent<Camera>().enabled = true;

            _finishCam.GetComponent<Animator>().Play("FinishLevel");

            _finishRef.FinishEx();

            //if (Time.timeScale == 1.0f)
            //    Time.timeScale = 0.3f;
            //else
            //    Time.timeScale = 1.0f;
            //Time.fixedDeltaTime = 0.02f * Time.timeScale;

            GetComponent<Movement>().enabled = false;

            //_cam.GetComponent<Camera>().enabled = false;

            _reference.Explode();

            StartCoroutine("EndTutorial");
        }

        if (other.gameObject.tag == "Pickup")
        {
            _pickupParticle.Play();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(4f);

        _canvas.GetComponent<Animator>().Play("EndTutorial");
    }
}
