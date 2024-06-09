using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.playOnAwake = false; // ��������� �������������� ���������������
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ��������������, ��� � ������ ��� "Player"
        {
            audioSource.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioSource.Stop();
        }
    }
}
