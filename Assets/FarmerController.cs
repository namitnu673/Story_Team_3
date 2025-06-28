using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FarmerController : MonoBehaviour
{
    [SerializeField] List<string> textShows;
    [SerializeField] GameObject goText;
    [SerializeField] TextMeshProUGUI txtShow;
    //[SerializeField] Button btnClick;
    //[SerializeField] Transform player;
    //[SerializeField] float rotationSpeed = 5f;

    private int index = 0;
    private Animator animator;
    //private Quaternion initialRotation;
    //private bool isFacingPlayer = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        //initialRotation = transform.rotation; // Lưu góc quay ban đầu
    }

    private void Start()
    {
        //btnClick.onClick.AddListener(() =>
        //{
        //    index = (index + 1) % textShows.Count;
        //    txtShow.text = textShows[index];
        //});
        //animator.SetBool("Stop", false);
        goText.SetActive(false);
    }

    //private void Update()
    //{
    //    if (isFacingPlayer && player != null)
    //    {
    //        Vector3 direction = (player.position - transform.position).normalized;
    //        direction.y = 0f; // Không xoay theo trục Y để tránh nghiêng
    //        Quaternion lookRotation = Quaternion.LookRotation(direction);
    //        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    //    }
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //animator.SetBool("Stop", true);
            goText.SetActive(true);
            txtShow.text = textShows[index];

            //player = other.transform;
            //isFacingPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            //animator.SetBool("Stop", false);
            goText.SetActive(false);

            index = (index + 1) % textShows.Count;
            //isFacingPlayer = false;
            //player = null;

            //// Quay về hướng ban đầu
            //StartCoroutine(RotateBackToInitial());
        }
    }

    //private IEnumerator RotateBackToInitial()
    //{
    //    while (Quaternion.Angle(transform.rotation, initialRotation) > 0.1f)
    //    {
    //        transform.rotation = Quaternion.Slerp(transform.rotation, initialRotation, Time.deltaTime * rotationSpeed);
    //        yield return null;
    //    }
    //    transform.rotation = initialRotation;
    //}
}
