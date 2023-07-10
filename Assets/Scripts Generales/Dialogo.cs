using System.Collections;
using UnityEngine;
using TMPro;
using UnityEditor.Rendering;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private GameObject Temporal;
    [SerializeField] private GameObject PanelDialogo;
    [SerializeField] private TMP_Text TextoDialogo;
    [SerializeField, TextArea (4, 6)] private string[] LineasDialogo;

    private float TypingTime = 0.05f;

    private bool IsPlayerInRange;
    public bool didDialogueStart;
    private int LineIndex;

    void Update()
    {
        if (IsPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (TextoDialogo.text == LineasDialogo[LineIndex])
            {
                SiguienteDialogo();
            }
            else
            {
                StopAllCoroutines();
                TextoDialogo.text = LineasDialogo[LineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        PanelDialogo.SetActive(true);
        Temporal.SetActive(false);
        LineIndex = 0;
        Time.timeScale = 0f;
        StartCoroutine(ShowLine());
    }

    private void SiguienteDialogo()
    {
        LineIndex++;

        if (LineIndex < LineasDialogo.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            didDialogueStart = false;
            PanelDialogo.SetActive(false);
            Temporal.SetActive(true);
            Time.timeScale = 1f;
        }
    }


    private IEnumerator ShowLine()
    {
        TextoDialogo.text = string.Empty;

        foreach (char ch in LineasDialogo[LineIndex])
        {
            TextoDialogo.text += ch;
            yield return new WaitForSecondsRealtime(TypingTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerInRange = true;
            Temporal.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            IsPlayerInRange = false;
            Temporal.SetActive(false);
        }
    }
}
