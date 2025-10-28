using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PortalTrigger : MonoBehaviour
{
    public GameObject popupPanel; // 팝업 패널
    public Button yesButton;
    public Button noButton;

    private void Start()
    {
        popupPanel.SetActive(false); // 처음엔 숨김

        // 버튼 연결
        yesButton.onClick.AddListener(OnYes);
        noButton.onClick.AddListener(OnNo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            popupPanel.SetActive(true); // 팝업 띄우기
            Time.timeScale = 0f; // 게임 일시정지
        }
    }

    private void OnYes()
    {
        Time.timeScale = 1f;
        popupPanel.SetActive(false);
        SceneManager.LoadScene("TappyPlaneScene"); // 이동할 씬 이름
    }

    private void OnNo()
    {
        Time.timeScale = 1f;
        popupPanel.SetActive(false);
    }
}