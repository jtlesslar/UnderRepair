using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OURInteract : Interactable
{

    bool hasMaterial = false;

    int materialCount = 0;

    bool repaired = false;

    float nextRepairTime = 0f;
    float repairDelay = 0.5f;

    ProgressBar progressBar;

    AudioSource audioSource;

    GameObject player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        progressBar = GetComponentInChildren<ProgressBar>();
    }

    public override void Interact(GameObject player)
    {
        base.Interact(player);

        this.player = player;

        Repair();
    }
    
    void Repair()
    {
        if (nextRepairTime < Time.time)
        {
            Debug.Log("Repairing OUR");

            if (hasMaterial && !repaired)
            {
                if (progressBar.BarValue < 100)
                {
                    progressBar.BarValue += 20;

                    audioSource.Play();

                    nextRepairTime = Time.time + repairDelay;

                    if (progressBar.BarValue >= 100)
                    {
                        switch (player.name) {
                            case "Player 1":
                                SceneManager.LoadScene("Blue Win Screen", LoadSceneMode.Single);
                                break;
                            case "Player 2":
                                SceneManager.LoadScene("Green Win Screen", LoadSceneMode.Single);
                                break;
                            case "Player 3":
                                SceneManager.LoadScene("Yellow Win Screen", LoadSceneMode.Single);
                                break;
                            case "Player 4":
                                SceneManager.LoadScene("Red Win Screen", LoadSceneMode.Single);
                                break;
                        }
                    }
                }    
            }
        }
    }

    private void OnTriggerEnter(Collider material)
    {
        Debug.Log(material.name);
        if (material.tag == "Material")
        {
            Debug.Log(material.tag);

            materialCount++;
            if (materialCount >=2)
            {
                hasMaterial = true;
            }
              
            Destroy(material.gameObject);
        }
    }

}

