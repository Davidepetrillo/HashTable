using HashTable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

class Hashtable
{
    private Node[] table;
    public int capacity = 16;
    public int size;


    public Hashtable()
    {
        table = new Node[capacity];
    }
    public Hashtable(int capacity)
    {
        table = new Node[capacity];
        size = 0;
        this.capacity = capacity;
    }

    private int HashCode(object key)
    {
        int num = 0;
        char[] chs = key.ToString().ToCharArray();
        for (int i = 0; i < chs.Length; i++)
        {
            num += (int)chs[i];
        }

        double avg = num * (Math.Pow(5, 0.5) - 1) / 2;
        double numeric = avg - Math.Floor(avg);
        return (int)Math.Floor(numeric * capacity);
    }

    public int Size()
    {
        return size;
    }

    public bool isEmpty()
    {
        return size == 0 ? true : false;
    }

    public void Put(Object key, Object value)
    {
        int hash = HashCode(key);
        Node newNode = new Node(key, value, hash, null);
        Node node = table[hash];

        while (node != null)
        {
            if (node.Key.Equals(key))
            {
                node.value = value;
                return;
            }
            node = node.next;
        }
        newNode.next = table[hash];
        table[hash] = newNode;
        size++;
    }

    public Object Get(Object key)
    {
        if(key == null)
        {
            return null;
        }

        int hash = HashCode(key);
        Node node = table[hash];

        while(node != null)
        {
            if (node.Key.Equals(key))
            {
                return node.value;
            }
            node = node.next;
        }
        return null;
    }

    public static void Main()
    {
        Hashtable table = new Hashtable();

        table.Put("david", "Good Boy Keep Going");
        table.Put("grace", "Cute girl Keep Going");

        Console.WriteLine("david => " + table.Get("david"));
        Console.WriteLine("grace => " + table.Get("grace"));
    }

}
