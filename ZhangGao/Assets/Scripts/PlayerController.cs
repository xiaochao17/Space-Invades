using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject missilePrefab;
    [SerializeField] GameObject playerExplosion;
    [SerializeField] float missileSpeed = 1f;
    [SerializeField] float moveSpeed = 0.08f;

    // These two values can be fethed from background object
    public float leftBound = -6.1f;
    public float rightBound = 6.1f;

    // maintain the live status which will be monitored by PlayerSpawner
    public bool isLive = true;

    AudioSource audiodata;
    GameObject missle;

    void Start()
    {
        audiodata = GetComponent<AudioSource>();
    }

    void Update()
	{
        MovePlayer();
        Fire();
	}

    void MovePlayer(){
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > leftBound)
        {
            transform.Translate(-moveSpeed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < rightBound)
        {
            transform.Translate(moveSpeed, 0f, 0f);
        }
    }

    void Fire()
    {
        // TODO: can be changed to a set of key code
        if (Input.GetKeyDown(KeyCode.Space) && missle == null)
        {
            missle = Instantiate(missilePrefab,
                                            gameObject.transform.position,
                                         Quaternion.identity) as GameObject;
            missle.GetComponent<Rigidbody2D>().velocity = new Vector2(0, missileSpeed);

            audiodata.Play(0);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.isLive = false;
        // TODO: Destroy with delay and add sound effect
        Destroy(gameObject);
        GameObject exploPic = Instantiate(playerExplosion, transform.position, Quaternion.identity);
        Destroy(exploPic, 1f);
    }


}