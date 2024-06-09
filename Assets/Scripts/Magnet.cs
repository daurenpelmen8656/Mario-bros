using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float magnetDuration = 10f; // ������������ �������� �������

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.ActivateMagnet(magnetDuration); // ���������� ������ � ������
                Destroy(gameObject); // ���������� ������ ������� ����� ���������
            }
        }
    }
}
