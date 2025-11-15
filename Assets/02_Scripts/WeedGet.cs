using System.Collections;
using UnityEngine;

public class WeedGet : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    private bool isPlayer = false;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.playOnAwake = false;
        audio.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {           
            GameManager.Instance.ShowWeedUI();
            isPlayer = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HideWeedUI();
            isPlayer = false;
        }
    }
    private void Update()
    {        
        if(isPlayer && Input.GetKeyDown(KeyCode.E))
        {
            audio.Stop();
            audio.Play();
            StartCoroutine(ActiveFalse());
            GameManager.Instance.HideWeedUI();
            GameManager.Instance.DisplayScore(1);
        }
    }
    IEnumerator ActiveFalse()
    {
        yield return new WaitForSeconds(1.3f);
        gameObject.SetActive(false);
    }
}
