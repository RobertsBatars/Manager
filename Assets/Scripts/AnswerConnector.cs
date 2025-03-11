using UnityEngine;
using UnityEngine.UIElements;

public class AnswerConnector : MonoBehaviour
{
    [SerializeField] private GameObject connectorPrefab;
    [HideInInspector] public AnswerAnchor answerAnchor;
    [HideInInspector] public bool grabbed = false;
    [HideInInspector] public TargetAnchor target;

    private GameObject connector;
    private LineRenderer line;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (answerAnchor != null && !grabbed)
            {
                grabbed = true;
            }
            else if (answerAnchor != null && grabbed)
            {
                grabbed = false;
                if (target == null)
                {
                    Destroy(connector);
                    connector = null;
                    answerAnchor = null;
                }
                else
                {
                    if (target.connector != null)
                    {
                        Destroy(target.connector);
                    }
                    target.isCorrect = target.correctAnswerID == answerAnchor.answerID;
                    target.connector = connector;
                    line.SetPosition(1, target.transform.position);
                    line.SetPosition(0, answerAnchor.transform.position);
                    connector = null;
                    answerAnchor = null;
                }
            }
            else if (target != null && answerAnchor == null && target.connector != null)
            {
                Destroy(target.connector);
                target.connector = null;
                target.isCorrect = false;
            }
        }

        if (grabbed && answerAnchor != null && connector == null)
        {
            connector = Instantiate(connectorPrefab, transform.position, Quaternion.identity);
            line = connector.GetComponent<LineRenderer>();
            line.SetPosition(0, transform.position);
            line.SetPosition(1, answerAnchor.transform.position);
            line.startColor = answerAnchor.anchorColor;
            line.endColor = answerAnchor.anchorColor;
        }
        else if (grabbed && answerAnchor != null && connector != null)
        {
            line.SetPosition(0, transform.position);
            line.SetPosition(1, answerAnchor.transform.position);
        }
    }
}
