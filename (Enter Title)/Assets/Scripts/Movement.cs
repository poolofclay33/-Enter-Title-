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
    public RotatePickup _pickupRef;

    public GameObject _pickUp;

    public Material _pink;

    public bool _gravity = false;

    public float _force;

    public GameObject _jumpBlockCam;

    void Start()
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
            if(_gravity == false)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMulti - 1) * Time.deltaTime;
            }
            else if(_gravity == true && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (3 - 1) * Time.deltaTime;
            }
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            if(_gravity == false)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJump - 1) * Time.deltaTime;
            }
            else 
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (3 - 1) * Time.deltaTime;
            }
        }
    }

    public ExplosionTest _reference;
    public Finish _finishRef;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            CameraShaker.Instance.ShakeOnce(1f, 1f, .2f, 1.5f);
            Debug.Log("SHAKE");

            _reference.Explode();

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
            GetComponent<Jump>().enabled = false;

            //_cam.GetComponent<Camera>().enabled = false;

            _reference.Explode();

            StartCoroutine("EndTutorial");
        }

        if (other.gameObject.tag == "Pickup")
        {
            _pickUp.GetComponent<Renderer>().enabled = false;
            GetComponent<Animator>().Play("ChangeMatsOrb");
            //LerpColors._lerpRef.LerpMats();
        }

        if(other.gameObject.name == "ChangeMatTrigger")
        {
            GetComponent<MeshRenderer>().material = _pink;
        }

        if(other.gameObject.tag == "Gravity")
        {
            _cam.GetComponent<Animator>().Play("GravitySwitchCam");
            Physics.gravity *= -1;
            _gravity = true;
        }

        if (other.gameObject.tag == "JumpPad")
        {
            GetComponent<Rigidbody>().velocity = Vector3.up * 25f;
            _cam.GetComponent<Animator>().Play("TurnUp");
        }

        if (other.gameObject.tag == "TurnCamDown")
        {
            Debug.Log("HEREERE");
            _cam.GetComponent<Animator>().Play("TurnDown");
        }

        if(other.gameObject.name == "ZoomOutCam1")
        {
            Debug.Log("1");
            //_cam.GetComponent<Camera>().fieldOfView = 75;
            //_cam.GetComponent<Animator>().Play("ZoomOut");
            _cam.GetComponent<Camera>().enabled = false;
            _jumpBlockCam.GetComponent<Camera>().enabled = true;
            _jumpBlockCam.GetComponent<Animator>().Play("Pan");
        }

        if(other.gameObject.name == "ResetCam")
        {
            _jumpBlockCam.GetComponent<Camera>().enabled = false;
            _cam.GetComponent<Camera>().enabled = true;
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);

        if(_gravity == true)
        {
            Physics.gravity *= -1;
        }

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    IEnumerator EndTutorial()
    {
        yield return new WaitForSeconds(4f);

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if(sceneName != "Tutorial" && _pickupRef._collected == true)
        {
            _canvas.GetComponent<Animator>().Play("FinishedLevel(Orb)");
        }

        else if(sceneName != "Tutorial" && _pickupRef._collected == false)
        {
            _canvas.GetComponent<Animator>().Play("FinishedLevel");
        }

        else
        {
            _canvas.GetComponent<Animator>().Play("EndTutorial");
        }
    }
}
