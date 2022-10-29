using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameGameplay : MonoBehaviour
{
    [SerializeField]
    float Timertime;

    [SerializeField]
    TMP_Text Text;

    float ElapsedTime;

    public System.Func<EdgeCollider2D> Collider2D { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        ElapsedTime = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        ElapsedTime += Time.deltaTime;

        TextPrint();

        Timer();

        Direction();



    }

    void TextPrint()
    {
        if ((9 - Mathf.Ceil(ElapsedTime)) > 4)
        {
            Text.text = "��������� ���� � ������ ��� " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " ������.";
        }
        else if ((Timertime + 1 - Mathf.Ceil(ElapsedTime)) <= 4 && (Timertime + 1 - Mathf.Ceil(ElapsedTime)) > 1)
        {
            Text.text = "��������� ���� � ������ ��� " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " �������.";
        }
        else
        {
            Text.text = "��������� ���� � ������ ��� " + (Timertime + 1 - Mathf.Ceil(ElapsedTime)) + " �������.";
        }
    }

    void Timer()
    {
        if (ElapsedTime >= Timertime)
        {
            ElapsedTime = 0;
            GameObject a = GameObject.FindWithTag("MiniGame1");
            //��� ��������� ������� �������
            Destroy(a);

        }
    }

    void Direction()
    {
        if (transform.position.x < 0.05f && transform.position.x > -0.05f)
        {
            transform.Translate(Random.Range(-0.1f, 0.1f), 0f, 0f);
        }

        if (transform.position.y < 0.05f && transform.position.y > -0.05f)
        {
            transform.Translate(0f, Random.Range(-0.1f, 0.1f), 0f);
        }

        float x1 = 0, y1 = 0;
        float x2 = transform.position.x, y2 = transform.position.y;
        float A = Mathf.Atan2(y1 - y2, x1 - x2) / Mathf.PI * 180;

        transform.Translate(Mathf.Sin(A) * Time.deltaTime, Mathf.Cos(A) * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject a = GameObject.FindWithTag("MiniGame1");
        //��� �� ��������� ������� �������
        Destroy(a);
    }
}