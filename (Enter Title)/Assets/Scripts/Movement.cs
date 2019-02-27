using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public int speed;
    public float fallMulti = 2.5f;
    public float lowJump = 2f;

    public GameObject _cam;
    public GameObject _deathCam;

    Rigidbody rb;

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
            _reference.Explode();

            //_cam.GetComponent<FollowPlayer>().enabled = false;
            _cam.GetComponent<Camera>().enabled = false;

            _deathCam.GetComponent<Camera>().enabled = true;

            _deathCam.GetComponent<Animator>().Play("PanOut");

            StartCoroutine("Reload");

            GetComponent<Movement>().enabled = false;

            GetComponent<Rigidbody>().isKinematic = true;
        }

        if(other.gameObject.tag == "Slow")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if (other.gameObject.tag == "Fast")
        {
            if (Time.timeScale == 1.0f)
                Time.timeScale = 0.5f;
            else
                Time.timeScale = 1.0f;
            // Adjust fixed delta time according to timescale
            // The fixed delta time will now be 0.02 frames per real-time second
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if(other.gameObject.tag == "Finish")
        {
            _finishRef.FinishEx();
        }
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(3f);

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
