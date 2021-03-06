﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StacksAndQueues.Classes
{
    public class Queue<T>
    {
        /// <summary>
        /// A queue needs both a reference to the front and rear of the queue, since we enqueue from the rear and dequeue/peek from the front; if we only had one or the other - missing either reference makes it impossible to do either in constant time
        /// </summary>
        public Node<T> Front { get; set; }
        public Node<T> Rear { get; set; }

        /// <summary>
        /// Basic implementation of a queue with an initial node. Since we need to declare both a Front and Rear reference to instantiate a queue and we have no methods that assign something to both the Front and Rear references through their invokation, there's no way to gracefully instantiate and interact with an empty queue. 
        /// </summary>
        /// <param name="node">Node to instantiate the queue with.</param>
        public Queue(Node<T> node)
        {
            Front = node;
            Rear = node;
        }

        /// <summary>
        /// Basic implementation of a queue with an initial node with a given value. 
        /// </summary>
        /// <param name="node">Value of node to instantiate the queue with.</param>
        public Queue(T value)
        {
            Node<T> newNode = new Node<T>(value);
            Front = newNode;
            Rear = newNode;
        }

        /// <summary>
        /// Basic construction of an empty queue.
        /// </summary>
        public Queue()
        {
            Front = null;
            Rear = null;
        }

        /// <summary>
        /// Adds a node with the given value to the rear of the queue. Since nodes in a queue point backwards (that is, the Front node points backwards to the next node in line, and the Rear node points to null), we need to assign the previous rear to point to the new rear as the next node, and the rear reference needs to be reassigned to point to the newly created node.
        /// </summary>
        /// <param name="value">Value of the node to be added to the rear of the queue.</param>
        public void Enqueue(T value)
        {
            Node<T> node = new Node<T>(value);
            if (Front == null)
            {
                Front = node;
                Front.Next = null;
                Rear = node;
                Rear.Next = null;
            }
            else {
                Rear.Next = node;
                Rear = node;
            }
            
        }

        /// <summary>
        /// Adds a node to the rear of the queue. 
        /// </summary>
        /// <param name="value">Previously created node to be added to the rear of the queue.</param>
        public void Enqueue(Node<T> newNode)
        {
            if (Front == null)
            {
                Front = newNode;
                Front.Next = null;
                Rear = newNode;
                Rear.Next = null;
            }
            else
            {
                Rear.Next = newNode;
                Rear = newNode;
            }
        }

        /// <summary>
        /// Removes a node from the front of the queue, and returns it. Throws a null reference exception if performed on an empty queue.
        /// </summary>
        /// <returns>The node representing the previous front of the queue.</returns>
        public Node<T> Dequeue()
        {
            if (Front == null)
            {
                return null;
            }
            //Only occurs when queue has one member
            else if (Front.Next == null)
            {
                Node<T> singleton = Front;
                Front = null;
                Rear = null;
                singleton.Next = null;
                return singleton;
            }
            else
            {
                // create a temp to keep track of the original front
                Node<T> temp = Front;
                // change our front reference to the next node
                Front = Front.Next;
                // clear our next reference for standalone
                temp.Next = null;
                //return the temp to the user
                return temp;
            }
        }

        /// <summary>
        /// Returns the node at the front of the queue without removing it.
        /// </summary>
        /// <returns>The node representing the previous front of the queue.</returns>
        public Node<T> Peek()
        {
            return Front;
        }
    }
}
