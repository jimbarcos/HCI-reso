using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class BiodegradableTrashCan : MonoBehaviour
{
    public int points = 0;
    [SerializeField] private TMP_Text textPoints;
    [SerializeField] private TMP_Text SelectedItem;
    public GameObject TextPoints;

    AudioManager audioManager;

    public void Awake()
    {
        PlayerPrefs.DeleteKey("Points");
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        points = PlayerPrefs.GetInt("Points");
        PlayerPrefs.DeleteKey("Points");
        // Check if the object entering the trash can has the "Draggable" tag
        if (other.CompareTag("Biodegradable"))
        {
            // Destroy the object
            Destroy(other.gameObject);
            Debug.Log("Trash Destroyed: " + other.gameObject.name);
            points += 20;

            if (TextPoints)
            {
                ShowFloatingTextCorrect();
            }
            audioManager.PlayCorrectTrash(audioManager.CorrectSource);
       
        }
        else
        {
            // Destroy the object
            Destroy(other.gameObject);
            Debug.Log("Trash Destroyed: " + other.gameObject.name);
            if (points >= 10)
            {
                points -= 10;
            }

            if (TextPoints)
            {
                ShowFloatingTextWrong();
            }
            audioManager.PlayWrongTrash(audioManager.WrongSource);
        }
        Debug.Log("Points: " + points);
        PlayerPrefs.SetInt("Points", points);
        textPoints.text = "Points: " + points;
        SelectedItem.text = "Selected Item: None";
    }

    void ShowFloatingTextCorrect()
    {
        var go = Instantiate(TextPoints, transform.position + new Vector3(0, 3.0f, 0), Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = "+20";
        go.GetComponent<TextMesh>().color = Color.white;
    }

    void ShowFloatingTextWrong()
    {
        var go = Instantiate(TextPoints, transform.position + new Vector3(0, 3.0f, 0), Quaternion.identity, transform);
        go.GetComponent<TextMesh>().text = "-10";
        go.GetComponent<TextMesh>().color = Color.white;
    }

}
