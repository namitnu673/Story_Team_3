using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestController : MonoBehaviour
{
    [SerializeField] Transform transPlayer;
    [SerializeField] float distanceMin;
    [SerializeField] string nameSceneTarget;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        SceneManager.LoadScene(1);
    //    }
    //}

    private void OnMouseDown()
    {
        if(Vector3.Distance(transform.position, transPlayer.position) < distanceMin)
        {
            SceneManager.LoadScene(nameSceneTarget);
        }
    }
}
