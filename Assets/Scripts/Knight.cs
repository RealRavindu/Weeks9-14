using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    SpriteRenderer sr;
    Animator animator;
    public float speed = 2;
    public bool canRun = true;
    public List<AudioClip> footstepSoundList = new List<AudioClip>();
    public AudioSource audiosource;
    public Coroutine jumping;
    public float t;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float direction = Input.GetAxis("Horizontal");
        sr.flipX = direction < 0;
        animator.SetFloat("movement", Mathf.Abs(direction));

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("attack");
            canRun = false;
        }

        if (canRun)
        {
            transform.position += transform.right * direction * speed * Time.deltaTime;
        }

        if (Input.GetKeyDown("Spacebar") & canRun)
        {
            animator.SetTrigger("Jump");
            jumping = StartCoroutine(Jump());
            
        }

    }

    public void AttackHasFinished()
    {
        Debug.Log("Attack animation has finished");
        canRun = true;
    }

    public void FootHasLanded()
    {
        Debug.Log("Footstep!");
        audiosource.clip = footstepSoundList[(int)Random.Range(0, 10)];
        audiosource.Play();
    }

    public IEnumerator Jump()
    {


        yield return null;
    }
}
