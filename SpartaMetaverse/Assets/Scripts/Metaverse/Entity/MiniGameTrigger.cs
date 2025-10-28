using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public GameObject popupPanel; // �˾� �г�
    public Button yesButton;
    public Button noButton;

    private void Start()
    {
        popupPanel.SetActive(false); // ó���� ����

        // ��ư ����
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            popupPanel.SetActive(true); // �˾� ����
            Time.timeScale = 0f; // ���� �Ͻ�����
        }
    }

    private void OnYes()
    {
        Time.timeScale = 1f;
        popupPanel.SetActive(false);
        SceneManager.LoadScene("TappyPlaneScene"); // �̵��� �� �̸�
    }

    private void OnNo()
    {
        Time.timeScale = 1f;
        popupPanel.SetActive(false);
    }
}