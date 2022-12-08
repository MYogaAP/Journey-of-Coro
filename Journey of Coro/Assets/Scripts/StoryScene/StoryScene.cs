using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoryScene : MonoBehaviour
{
    [SerializeField] private Sprite[] sprite;
    [SerializeField] private GameObject upTextObj, bottomTextObj, nextInfo, dialogObj;
    [SerializeField] private TextMeshProUGUI upText, bottomText, chatText, chatName;
    private int imageNum;
    private float wait;
    private int currentStoryPage, currentWord;
    Dictionary<int, List<string>> story = new Dictionary<int, List<string>>();

    void Start()
    {
        wait = 3;
        imageNum = 0;
        gameObject.GetComponent<Image>().sprite = sprite[imageNum];
        currentWord = -1;
        currentStoryPage = 0;
        InitializeWords();
    }

    private void Update()
    {
        wait += Time.deltaTime;

        NextInfo(wait > 0.5);

        if (Input.anyKey && wait > 0.5)
        {
            wait = 0;
            gameObject.GetComponent<AudioSource>().Play();
            currentWord += 1;

            DialogBox();
        }

        if (currentWord == -1)
        {
            HideAllBoxes();
        }

        if (currentStoryPage != imageNum && imageNum + 1 < sprite.Length)
        {
            ChangeStoryImage();
        }
    }

    private void DialogBox()
    {
        if (currentStoryPage >= story.Count)
        {
            ChangeScene();
        }
        else
        {
            if (currentWord >= story[currentStoryPage].Count)
            {
                currentStoryPage += 1;
                currentWord = -1;
            }

            if (currentWord != -1)
            {
                if (currentStoryPage < 7)
                {
                    if (currentWord <= 0)
                    {
                        bottomTextObj.SetActive(true);
                        upTextObj.SetActive(false);
                        bottomText.text = story[currentStoryPage][currentWord];
                    }
                    else
                    {
                        upTextObj.SetActive(true);
                        bottomTextObj.SetActive(false);
                        upText.text = story[currentStoryPage][currentWord];
                    }
                }
                else
                {
                    dialogObj.SetActive(true);
                    chatName.text = story[currentStoryPage][currentWord];
                    currentWord++;
                    chatText.text = story[currentStoryPage][currentWord];

                    currentStoryPage += 1;
                    currentWord = -1;
                }
            }
        }  
    }

    private void NextInfo(bool active)
    {
        nextInfo.SetActive(active);
    }

    private void HideAllBoxes()
    {
        upTextObj.SetActive(false);
        bottomTextObj.SetActive(false);
    }

    private void ChangeScene()
    {
        TrackGameState.ActiveState = "Level 1";
        SceneManager.LoadScene("LoadingScene");
    }

    private void ChangeStoryImage()
    {
        imageNum++;
        wait = 2;
        gameObject.GetComponent<Image>().sprite = sprite[imageNum];
    }

    private void InitializeWords()
    {
        int i = 0;
        story.Add(i++, new List<string> {
            "The story start as Coro and his friends are wandering around in someone's bathroom.",
            "Without any warning, the human suddenly entered and manage to kill one of them."
        });
        story.Add(i++, new List<string> {
            "Cori and his other friend managed to flee from the human's house and found another house to enter.",
            "They nonchalantly decided to enter the house even after what happends to their one friend."
        });
        story.Add(i++, new List<string> {
            "Everything was fine until the human of the house entered.",
            "The human instantly kill Coro's friend by crushing him. At the last moment, Coro managed to flee from the house."
        });
        story.Add(i++, new List<string> {
            "And the front of the house, Coro found a sewer drainage and decided to enter it.",
            "With all of his energy depleted, he decided to sleep inside the sewer until a certain time has passed."
        });
        story.Add(i++, new List<string> {
            "When Coro woke up, he decided to take a stroll towards another way of the sewer.",
            "After a certain time has passed, Coro decided to go up to the surface."
        }); 
        story.Add(i++, new List<string> {
            "Coro was surprised. He have arrived at a military base.",
            "When Coro was wondering around, he met another roach by the name of Kori."
        });
        story.Add(i++, new List<string> {
            "Kori tells coro to follow him to his base.",
            "When they arrive, a rat by the name of Curut and a lizard by the name of Awak was waiting for them."
        });
        story.Add(i++, new List<string> {
            "Curut",
            "Well now, who is this new fellow that you have brought in?"
        });
        story.Add(i++, new List<string> {
            "Kori",
            "I just found him wandering around the place, I was worried if he got caught or something, so I brought him here."
        });
        story.Add(i++, new List<string> {
            "Coro",
            "N-nice to meet you all. I am thankful that Kori let me follow him here."
        });
        story.Add(i++, new List<string> {
            "Awak",
            "Hmm, what stroke of luck we have. Kori, how about we give him some job to do?"
        });
        story.Add(i++, new List<string> {
            "Curut",
            "Oh yeah! That's a great idea! That way we can get double the efficient on the job that is yours Kori!"
        });
        story.Add(i++, new List<string> {
            "Kori",
            "I see that as an absolute win. Less job for me."
        });
        story.Add(i++, new List<string> {
            "Coro",
            "Wait, wait, wait! What kind of job?"
        });
        story.Add(i++, new List<string> {
            "Awak",
            "Let me tell you. We decided to raid this place's food storage. Thus we need to get the tools ready."
        });
        story.Add(i++, new List<string> {
            "Awak",
            "You and Kori will be gathering the tools as me and Curut get some things ready."
        });
        story.Add(i++, new List<string> {
            "Curut",
            "So? How about it? Of course when we get the food, we will share them!"
        });
        story.Add(i++, new List<string> {
            "Coro",
            "Hmm. Sure, i'll help you guys out."
        });
        story.Add(i++, new List<string> {
            "Kori",
            "Ok then, follow me and we will start your first mission!"
        });
    }
}
