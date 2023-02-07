using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class Composer : MonoBehaviour
{
    public AudioClip[] notes;
    public Transform noteButtonsParent, compositionParent;

    public Button noteButtonPrefab;
    public Button recordedButtonPrefab;

    private List<AudioClip> composition = new List<AudioClip>();

    private void Awake()
    {
        for (int i = 0; i < notes.Length; i++)
        {
            Button instantiatedButton = Instantiate(noteButtonPrefab, noteButtonsParent);
            instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = notes[i].name;

            // Magic!
            AudioClip note = notes[i];

            instantiatedButton.onClick.AddListener(() => PlayNote(note));
        }
    }

    private void PlayNote(AudioClip clip)
    {
        GetComponent<AudioSource>().PlayOneShot(clip);

        composition.Add(clip);

        RebuildCompositionButtons();
    }

    private void RebuildCompositionButtons()
    {
        Button[] existingButtons = compositionParent.GetComponentsInChildren<Button>();

        for (int i = 0; i < existingButtons.Length; i++)
        {
            Destroy(existingButtons[i].gameObject);
        }

        for (int i = 0; i < composition.Count; i++)
        {
            Button instantiatedButton = Instantiate(recordedButtonPrefab, compositionParent);
            instantiatedButton.GetComponentInChildren<TextMeshProUGUI>().text = composition[i].name;

            // Magic!
            int index = i;

            instantiatedButton.onClick.AddListener(() => DeleteNote(index));
        }
    }

    private void DeleteNote(int index)
    {
        composition.RemoveAt(index);

        RebuildCompositionButtons();
    }
}
