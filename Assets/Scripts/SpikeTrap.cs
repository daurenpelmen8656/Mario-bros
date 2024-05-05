using UnityEngine;
using UnityEngine.UI;

public class SpikeTrap : MonoBehaviour
{
    private static float HP = 100f; // ������� ���������� ����������� ��� ���� SpikeTrap
    private float damageRate = 15f; // ���� � ������� �������
    public Image Bar;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HP -= damageRate * Time.deltaTime; // ��������� ����� �������� �� ���� �������
            Bar.fillAmount = HP / 100;

            // �������� ����� ��������, ���� HP ������ ��� ����� 0, �� ���-�� ������ (��������, ������������ �������)
            if (HP <= 0)
            {
                gameObject.SetActive(false); // ������������ �������
            }
        }
    }
}
