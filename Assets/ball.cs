using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ball : MonoBehaviour
{
    public Rigidbody2D rb;
    private bool isPressed = false;
    public float releaseTime = .15f;
    public Rigidbody2D hook;
    public float maxDragDistance = 3f;
    public GameObject nextball ;
    void Update()
    {

        if (isPressed)
        {
            Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(MousePos, hook.position) > maxDragDistance)
                rb.position = hook.position +( MousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = MousePos;
        }
    }

    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }
    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        StartCoroutine(Release());
    }


    IEnumerator Release()
    {

        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;

        yield return new WaitForSeconds(2f);

        if (nextball != null)
        {
            nextball.SetActive(true);
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
       
        
    }
} 