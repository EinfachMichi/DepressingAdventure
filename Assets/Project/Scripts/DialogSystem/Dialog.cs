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