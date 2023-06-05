using System;
using System.Collections;
using System.Collections.Generic;
using Main;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StorySystem
{
    public class StoryManager : Singleton<StoryManager>
{
    public event Action OnStoryBegin;
    public event Action OnStoryEnd;
    public event Action OnChoiceOver; 
    public Action<string> OnTextChanged;
    public Action<string> OnSpeakerChanged;
    public Action<string, string> OnChoice;

    public PassageList PassageList;

    public float CharactersPerSecond;
    
    private TextAsset[] stories;
    private Passage currentPassage;
    private string choice1;
    private string choice2;
    private bool lineFinished = true;
    private bool hasChoosen = true;
    private bool storyFinished = true;
    private bool isBreak = false;
    private int choose;
    
    protected override void Awake()
    {
        base.Awake();
        stories = Resources.LoadAll<TextAsset>("Dialogs");

        UpdateStory(1);
    }

    public void UpdateStory(int storyIndex = 0)
    {
        PassageList = JsonUtility.FromJson<PassageList>(stories[storyIndex].text);
    }

    public void RunStory(Passage passage)
    {
        if (!storyFinished) return;
        
        storyFinished = false;
        OnStoryBegin?.Invoke();
        StartCoroutine(WriteStory(passage));
    }
    
    public void NextPassage(InputAction.CallbackContext value)
    {
        if (!value.started) return;
        
        if (!lineFinished || !hasChoosen || storyFinished) return;
        
        if (currentPassage.links.Count == 0)
        {
            OnStoryEnd?.Invoke();
            storyFinished = true;
            return;
        }

        if (currentPassage.links.Count == 1)
        {
            StartCoroutine(WriteStory(GetPassage(currentPassage.links[0].pid)));
            return;
        }

        if (currentPassage.links.Count == 2)
        {
            StartCoroutine(WriteStory(GetPassage(currentPassage.links[choose].pid)));
            OnChoiceOver?.Invoke();
        }
    }

    public void Choose(int ans)
    {
        choose = ans;
        hasChoosen = true;
        StartCoroutine(WriteStory(GetPassage(currentPassage.links[choose].pid)));
        OnChoiceOver?.Invoke();
    }

    private IEnumerator WriteStory(Passage passage)
    {
        lineFinished = false;
        currentPassage = passage;
        if (passage.tags.Contains("Break")) isBreak = true;
        
        string text = CompilePassage(passage);
        string result = "";
        for (int i = 0; i < text.Length; i++)
        {
            result += text[i];
            OnTextChanged?.Invoke(result);
            yield return new WaitForSeconds(1 / CharactersPerSecond);
        }
        
        if(passage.links.Count == 2) OnChoice?.Invoke(choice1, choice2);
        
        lineFinished = true;
    }

    private string CompilePassage(Passage passage)
    {
        string text = passage.text;

        string speakerName = HandleSpeakerName();
        string result = HandleChoices(passage.links.Count);
        
        OnSpeakerChanged?.Invoke(speakerName);
        
        string HandleSpeakerName()
        {
            int charsToDelete = 0;
            string speakerName = "";
            for (int i = 0; i < text.Length; i++)
            {
                charsToDelete++;
                if (text[i] == ':') break;
                speakerName += text[i];
            }
            text = text.Remove(0, charsToDelete + 1);
            return speakerName;
        }
        string HandleChoices(int linksCount)
        {
            string s = "";
            if (linksCount < 2)
            {
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '[') break;
                    s += text[i];
                }
            }
            else if (linksCount == 2)
            {
                hasChoosen = false;
                
                choice1 = "";
                choice2 = "";
            
                int index = 0;
                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '[')
                    {
                        index = i;
                        break;
                    }
                    s += text[i];
                }

                int openBracketsCount = 0;
                int closedBracketsCount = 0;
                for (int i = index; i < text.Length; i++)
                {
                    if(text[i] == '[')
                    {
                        openBracketsCount++;
                        continue;
                    }

                    if (text[i] == ']')
                    {
                        closedBracketsCount++;
                        continue;
                    }

                    if (openBracketsCount == 2 && closedBracketsCount == 0) choice1 += text[i];
                    if (openBracketsCount == 4 && closedBracketsCount == 2) choice2 += text[i];
                }
            }
            return s;
        }

        return result;
    }

    private Passage GetPassage(int pid)
    {
        foreach (Passage passage in PassageList.passages)
        {
            if (passage.pid == pid) return passage;
        }
        return default;
    }
}

public class Story
{
    private PassageList passageList = new PassageList();
    private int storyIndex;

    public Story(string name)
    {
        PassageList list = StoryManager.Instance.PassageList;
        
        foreach (Passage passage in list.passages)
        {
            if (passage.name.StartsWith(name))
                if (passage.tags.Contains("Start"))
                    passageList.passages.Add(passage);
        }
        storyIndex = 0;
    }

    public Passage GetStory() => passageList.passages[storyIndex];
    public void Next() => storyIndex++;
}

[Serializable]
public class PassageList
{
    public List<Passage> passages;

    public PassageList()
    {
        passages = new List<Passage>();
    }
}

[Serializable]
public struct Passage
{
    public string text;
    public string name;
    public List<Link> links;
    public int pid;
    public List<string> tags;
}

[Serializable]
public struct Link
{
    public string name;
    public int pid;
}
}