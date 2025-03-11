using UnityEngine;

public class TargetAnchor : MonoBehaviour
{
    [SerializeField] private Color anchorColor = Color.yellow;

    public string correctAnswerID;
    [HideInInspector] public bool isCorrect = false;
    [HideInInspector] public GameObject connector;
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = anchorColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AnswerConnector player = collision.gameObject.GetComponent<AnswerConnector>();
            player.target = this;
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AnswerConnector player = collision.gameObject.GetComponent<AnswerConnector>();
            player.target = null;
            gameObject.GetComponent<SpriteRenderer>().color = anchorColor;
        }
    }
}
