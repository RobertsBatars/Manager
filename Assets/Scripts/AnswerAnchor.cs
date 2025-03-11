using UnityEngine;

public class AnswerAnchor : MonoBehaviour
{
    public string answerID;
    public Color anchorColor = Color.green;

    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = anchorColor;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = Color.yellow;
            AnswerConnector player = collision.gameObject.GetComponent<AnswerConnector>();
            player.answerAnchor = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            spriteRenderer.color = anchorColor;
            AnswerConnector player = collision.gameObject.GetComponent<AnswerConnector>();
            if (!player.grabbed)
            {
                player.answerAnchor = null;
            }
        }
    }
}
