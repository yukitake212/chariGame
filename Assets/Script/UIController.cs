using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI meterText;
    [SerializeField] TextMeshProUGUI gameoverText;
    [SerializeField] TextMeshProUGUI gameoverMetertext;

    private int meter = 0;
    private float time = 0.0f;
    private PlayerController playerController;

    public static UIController instance;

    void Awake()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        meterText.text = "0 m";

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 0.1f)
        {
            if (!playerController.isGameover)
            {
                meter += 1;
            }
            
            time = 0.0f;
        }
        meterText.text = meter + " m";
    }

    public void Gameover()
    {
        gameoverText.gameObject.SetActive(true);
        gameoverMetertext.gameObject.SetActive(true);
        gameoverMetertext.text = "Your final distance is... " + meter + " m";
        Invoke("Restart", 2.0f);
    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
