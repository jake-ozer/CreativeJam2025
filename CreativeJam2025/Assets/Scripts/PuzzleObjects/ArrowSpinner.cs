using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpinner : MonoBehaviour
{
    public List<Transform> pedestalTransforms;
    private Transform curTargetTransform;
    private Transform cachedFromTransform;
    private int transIndex;
    [SerializeField] private AudioClip stoneMoveClip;
    [SerializeField] private int correctAnswerIndex;
    public bool canSpin = true;

    public float speed = 0.01f;
    float timeCount = 0.0f;

    private void Start()
    {
        //by default, point to the transform without 'Pedestal' component
        cachedFromTransform = this.transform;
        foreach (Transform t in pedestalTransforms)
        {
            if (t.GetComponent<Pedestal>() == null)
            {
                curTargetTransform = t;
                transIndex = pedestalTransforms.IndexOf(t);
            }
        }
    }

    private void Update()
    {
        Vector3 direction = curTargetTransform.position - cachedFromTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(cachedFromTransform.rotation, targetRotation, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;
    }

    public void SwitchPedestal()
    {
        if (canSpin)
        {
            GetComponent<AudioSource>().PlayOneShot(stoneMoveClip);
            cachedFromTransform = this.transform;
            transIndex = (transIndex < pedestalTransforms.Count - 1) ? transIndex + 1 : 0;
            curTargetTransform = pedestalTransforms[transIndex];
        }  
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if its a fireball, spin the arrow
        if (collision.gameObject.GetComponent<FireballProjectile>() != null)
        {
            //Debug.Log("switching pedestal");
            SwitchPedestal();
        }
    }

    public bool IsCorrectAnswer()
    {
        return transIndex == correctAnswerIndex;
    }
}
