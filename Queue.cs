using System;
using System.Threading;
public class Queue {
  public class Node {
    public int[] data;
    public Node next;

    public Node(int[] data) {
      this.data = data;
    }
  }

  public Node head;
  public Node tail; 

  public int[] peak() {
    return head.data;
  }

  public void add(int[] data) { //this is enqueuing
    Node node = new Node(data); //creating new tail
    if(tail != null) {
      tail.next = node; //telling the old tail what its next node is
    }
    tail = node; //updating the tail of the queue
    if(head == null) {
      head = node;
    }
  }

  public int[] remove() { //this is dequeuing
    head = head.next;
    if(head == null) {
      tail = null;
    }
    return head.data;
  }

  public bool isEmpty() {
    return head == null; //if the head is empty the queue is empty
  }

}