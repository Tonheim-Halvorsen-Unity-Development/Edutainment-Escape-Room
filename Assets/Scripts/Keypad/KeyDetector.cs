using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KeyDetector : MonoBehaviour
{

    private TextMeshPro display;

    private KeyPadControll keyPadControll;

    [SerializeField] string displayTag;
    [SerializeField] string keypadTag;
    [SerializeField] string keypadButtonTag;

    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "EscapeRoom")
        {
            display = GameObject.FindGameObjectWithTag(displayTag).GetComponentInChildren<TextMeshPro>();

            keyPadControll = GameObject.FindGameObjectWithTag(keypadTag).GetComponent<KeyPadControll>();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keypadButtonTag))
        {
            var key = other.GetComponentInChildren<TextMeshPro>();
            if (key != null)
            {
                var KeyFeedback = other.gameObject.GetComponent<KeyFeedback>();

                KeyFeedback.keyHit = true;

                var accessGranted = false;
                bool onlyNumbers = int.TryParse(display.text, out int value);

                if (onlyNumbers == false)
                {
                    display.text = "";
                }

                //make sure max 4 numbers
                if(key.text == "Back")
                {
                    if (display.text.Length > 0)
                    {
                        display.text = display.text.Remove(display.text.Length - 1, 1);
                    }
                } 
                else if(key.text == "Confirm")
                {
                    if (display.text.Length > 0)
                    {
                        accessGranted = keyPadControll.CheckIfCorrect(Convert.ToInt32(display.text));
                        if (accessGranted)
                        {
                            display.text = "Correct";
                        }
                        else
                        {
                            display.text = "Retry";
                        }
                    }
                } 
                else
                {
                    if (display.text.Length < 4)
                    {
                        display.text += key.text;
                    }
                }
            }

        }
    }
}
