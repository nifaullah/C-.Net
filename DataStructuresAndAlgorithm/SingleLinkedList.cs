using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataStructuresAndAlgorithm
{
	public class SingleLinkedList<T>
	{
		#region Properties & Variables

		#region Private Properties
		private NodeSingleLinkedList<T> start { get; set; }
		private static int lengthCounter = 0;
		private Type _type = typeof(T);
		#endregion

		#region Public Properties
		public string linkedListType
		{
			get { return typeof(T).ToString(); }
		}

		public int length
		{
			get { return lengthCounter; }
		}
		#endregion

		#endregion

		#region Methods

		#region Private Methods
		private static T ConvertType(string info)
		{
			return (T)Convert.ChangeType(info, typeof(T)); ;
		}

		private (NodeSingleLinkedList<T>, NodeSingleLinkedList<T>, int) FindPreviousAndCurrentNode(string info_string)
		{
			int index = 0;
			T info = ConvertType(info_string);
			NodeSingleLinkedList<T> prev, curr;
			curr = start;
			prev = null;
			while (curr != null)
			{
				if (curr.info.Equals(info))
					break;
				prev = curr;
				curr = curr.link;
				index++;
			}
			return (prev, curr, index);
		}

		private void HelperFind(string element, Action<NodeSingleLinkedList<T>, NodeSingleLinkedList<T>, string> CustomMethod = null, string info_string = null)
		{
			(NodeSingleLinkedList<T> prev, NodeSingleLinkedList<T> curr, int index) = FindPreviousAndCurrentNode(element);
			if (curr != null)
			{
				Console.WriteLine($"Position of the element - {curr.info}: {index + 1}");
				if(CustomMethod != null)
					CustomMethod(prev, curr, info_string);
			}
			else
				Console.WriteLine($"{element} not found !!");
		}
		#endregion

		#region Public Methods
		public void Display()
		{
			if (start == null)
			{
				Console.WriteLine("List is empty");
				return;
			}

			NodeSingleLinkedList<T> p = start;
			while (p != null)
			{
				Console.Write(p.info);
				Console.Write(" \t");
				p = p.link;
			}
			Console.WriteLine();
		}

		public void AppendToEnd(string info_string)
		{
			T info = ConvertType(info_string);
			lengthCounter++;
			if (start == null)
				start = new NodeSingleLinkedList<T>(info);
			else
			{
				NodeSingleLinkedList<T> p = start;
				while(p.link != null)
				{
					p = p.link;
				}
				p.link = new NodeSingleLinkedList<T>(info);
			}
		}

		public void AppendToStart(string info_string)
		{
			T info = ConvertType(info_string);
			lengthCounter++;
			NodeSingleLinkedList<T> p = new NodeSingleLinkedList<T>(info);
			p.link = start;
			start = p;
		}

		public void RemoveFirstElement()
		{
			if (start != null)
			{
				start = start.link;
				lengthCounter--;
			}
		}

		public void RemoveLastElement()
		{
			if (start != null)
			{
				lengthCounter--;
				if (start.link == null)
				{
					start = null;
					return;
				}

				NodeSingleLinkedList<T> curr, prev;
				curr = prev = start;
				while(curr.link != null)
				{
					prev = curr;
					curr = curr.link;
				}
				prev.link = null;
			}
		}

		public void FindElement(string element)
		{
			HelperFind(element);
		}

		public void AddAfterElement(string element, string info_string)
		{
			Action<NodeSingleLinkedList<T>, NodeSingleLinkedList<T>, string> addAfterElement = (NodeSingleLinkedList<T> prev, NodeSingleLinkedList<T> curr, string info) =>
			{
				NodeSingleLinkedList<T> node = new NodeSingleLinkedList<T>(ConvertType(info));
				node.link = curr.link;
				curr.link = node;
				lengthCounter++;
			};
			HelperFind(element, addAfterElement, info_string);
		}

		public void AddBeforeElement(string element, string info_string)
		{
			Action<NodeSingleLinkedList<T>, NodeSingleLinkedList<T>, string> addBeforeElement = (NodeSingleLinkedList<T> prev, NodeSingleLinkedList<T> curr, string info) =>
			{
				NodeSingleLinkedList<T> node = new NodeSingleLinkedList<T>(ConvertType(info));
				node.link = curr;
				if (prev != null)
					prev.link = node;
				else
					start = node;
				lengthCounter++;
			};
			HelperFind(element, addBeforeElement, info_string);
		}

		public void RemoveElement(string element)
		{
			HelperFind(element, (NodeSingleLinkedList<T> prev, NodeSingleLinkedList<T> curr, string info) =>
			{
				if (curr.link != null)
					if (prev != null)
						prev.link = curr.link;
					else
						start = curr.link;
				else
					if (prev != null)
						prev.link = null;
					else
						start = null;
				lengthCounter--;
			});
		}
		#endregion

		#endregion

	}

	public class NodeSingleLinkedList<T>
	{
		public T info { get; set; }
		public NodeSingleLinkedList<T> link { get; set; }

		public NodeSingleLinkedList(T info)
		{
			this.info = info;
			link = null;
		}
	}
}
