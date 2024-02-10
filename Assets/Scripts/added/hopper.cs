using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hopper : MonoBehaviour
{
    float moveSpeed = 2f;
    public float delay = 1f;
    float timeBeforeClose = 1f;

    bool right = false;
    bool left = false;
    Vector3 startTransform;



    private void Start()
    {
        startTransform = transform.position;
    }

    void FixedUpdate()
    {

        if (right == true)
        {
            MoveRightForOneSecond();
        }
        else if (left == true)
        {
            MoveLeftForOneSecond();
        }

    }
    public void openHopper()
    {
        StartCoroutine(mainDelay(delay));

    }
    public void MoveRightForOneSecond()
    {
        transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
    }
    public void MoveLeftForOneSecond()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
    }

    IEnumerator mainDelay(float wait)
    {
        yield return new WaitForSeconds(wait);
        right = true;
        StartCoroutine(openHopper(timeBeforeClose));

    }


    IEnumerator openHopper(float wait)
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(waitHopper(wait));

    }

    IEnumerator waitHopper(float wait)
    {
        right = false;
        yield return new WaitForSeconds(wait);
        StartCoroutine(closeHopper(wait));

    }

    IEnumerator closeHopper(float wait)
    {
        left = true;
        yield return new WaitForSeconds(0.5f);
        left = false;
        transform.position = startTransform;

    }

}
