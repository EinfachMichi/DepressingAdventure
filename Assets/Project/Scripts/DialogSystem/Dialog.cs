using System;
using System.Collections.Generic;
using DialogSystem;

public class Dialog
{
    public List<Passage> passages;

    public Passage GetPassage(int pid)
    {
        Passage passageObject = new Passage();
        foreach (Passage dialogPassage in passages)
        {
            if (dialogPassage.pid == pid)
            {
                passageObject = dialogPassage;
                break;
            }
        }
        return passageObject;
    }

    public Conversation GetConversation(string name)
    {
        Conversation conv = new Conversation();
        foreach (Passage dialogPassage in passages)
        {
            if (dialogPassage.name.StartsWith(name))
            {
                if (dialogPassage.tags.Contains("Start"))
                {
                    //list.Add(dialogPassage);
                }
                break;
            }
        }
        return conv;
    }

    public void FromToEnd(Passage passage, List<Passage> list)
    {
        if(passage.links.Count == 0)
        {
            list.Add(passage);
            return;
        }
    }

    // public List<Passage> GetPassagesWithTag(string name, params string[] tags)
    // {
    //     List<Passage> list = GetPassages(name);
    //     for (int i = 0; i < passages.Count; i++)
    //     {
    //         int tagCount = 0;
    //         for (int j = 0; j < tags.Length; j++)
    //         {
    //             if (passages[i].tags[j] == tags[j]) tagCount++;
    //         }
    //         if(tagCount == tags.Length) list.Add(passages[i]);
    //     }
    //     return list;
    // }
}

[Serializable]
public struct Passage
{
    public string text;
    public string name;
    public List<Link> links;
    public int pid;
    public List<string> tags;

    public int GetLinkPassageID(int index) => links[index].pid;
}

[Serializable]
public struct Link
{
    public string name;
    public int pid;
}