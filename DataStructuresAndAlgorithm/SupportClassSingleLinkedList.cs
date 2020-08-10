using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructuresAndAlgorithm
{
	#region Class
	public class SupportClassSingleLinkedList: IOperation
	{
		public static readonly Dictionary<int, string> menuDisplay = new Dictionary<int, string>()
		{
			{ (int)SingleLinkedListMenuEnums.displayElement, $"{(int)SingleLinkedListMenuEnums.displayElement}. Display Elements" },
			{ (int)SingleLinkedListMenuEnums.getType, $"{(int)SingleLinkedListMenuEnums.getType}. Get Linkedlist Type" },
			{ (int)SingleLinkedListMenuEnums.getLength, $"{(int)SingleLinkedListMenuEnums.getLength}. Get Length" },
			{ (int)SingleLinkedListMenuEnums.appendToEnd, $"{(int)SingleLinkedListMenuEnums.appendToEnd}. Append value at the end" },
			{ (int)SingleLinkedListMenuEnums.appendToEndMany, $"{(int)SingleLinkedListMenuEnums.appendToEndMany}. Append multiple Values at the end" },
			{ (int)SingleLinkedListMenuEnums.appendToFirst, $"{(int)SingleLinkedListMenuEnums.appendToFirst}. Append Value at the start" },
			{ (int)SingleLinkedListMenuEnums.appendToFirstMany, $"{(int)SingleLinkedListMenuEnums.appendToFirstMany}. Append multiple Values at the start" },
			{ (int)SingleLinkedListMenuEnums.RemoveFirstElement, $"{(int)SingleLinkedListMenuEnums.RemoveFirstElement}. Remove First Element" },
			{ (int)SingleLinkedListMenuEnums.RemoveLastElement, $"{(int)SingleLinkedListMenuEnums.RemoveLastElement}. Remove Last Element" },
			{ (int)SingleLinkedListMenuEnums.FindElement, $"{(int)SingleLinkedListMenuEnums.FindElement}. Find Element" },
			{ (int)SingleLinkedListMenuEnums.AddAfterElement, $"{(int)SingleLinkedListMenuEnums.AddAfterElement}. Add After Element" },
			{ (int)SingleLinkedListMenuEnums.AddBeforeElement, $"{(int)SingleLinkedListMenuEnums.AddBeforeElement}. Add Before Element" },
			{ (int)SingleLinkedListMenuEnums.RemoveElement, $"{(int)SingleLinkedListMenuEnums.RemoveElement}. Remove Element" }
		};

		#region Class Start up Supplemennts
		public void StartOperations()
		{
			dynamic obj = GetLinkedListType();
			ManageLinkedList(obj);
		}
		static dynamic GetLinkedListType()
		{
			Console.WriteLine("Single LinkedList Menu");
			Console.WriteLine("Select the type of linked list");
			Console.WriteLine("1. Int");
			Console.WriteLine("2. Float");
			Console.WriteLine("3. Double");
			Console.WriteLine("4. String");
			Console.WriteLine("5. Object");

			return CreateLinkedList(Console.ReadLine());
		}

		static dynamic CreateLinkedList(string linkedListType)
		{
			int type = Convert.ToInt32(linkedListType);
			switch (type)
			{
				case 1:
					return new SingleLinkedList<int>();
				case 2:
					return new SingleLinkedList<float>();
				case 3:
					return new SingleLinkedList<double>();
				case 4:
					return new SingleLinkedList<string>();
				case 5:
					return new SingleLinkedList<object>();
				default:
					Console.Clear();
					Console.WriteLine("Invalid Type");
					return GetLinkedListType();
			}
		}

		static void ManageLinkedList(dynamic obj)
		{
			DisplayMenu();
			int choice = Convert.ToInt32(Console.ReadLine());
			int range = 0;
			switch (choice)
			{
				case (int)SingleLinkedListMenuEnums.displayElement:
					obj.Display();
					break;
				case (int)SingleLinkedListMenuEnums.getType:
					Console.WriteLine(obj.linkedListType);
					break;
				case (int)SingleLinkedListMenuEnums.getLength:
					Console.WriteLine(obj.length);
					break;
				case (int)SingleLinkedListMenuEnums.appendToEnd:
					Console.Write("Enter the Value:");
					obj.AppendToEnd(Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.appendToEndMany:
					Console.Write("Enter number of Value you want to append:");
					range = Convert.ToInt32(Console.ReadLine());
					for (int i = 0; i < range; i++)
						obj.AppendToEnd(Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.appendToFirst:
					Console.Write("Enter the Value:");
					obj.AppendToStart(Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.appendToFirstMany:
					Console.Write("Enter number of Value you want to append:");
					range = Convert.ToInt32(Console.ReadLine());
					for (int i = 0; i < range; i++)
						obj.AppendToStart(Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.RemoveFirstElement:
					obj.RemoveFirstElement();
					break;
				case (int)SingleLinkedListMenuEnums.RemoveLastElement:
					obj.RemoveLastElement();
					break;
				case (int)SingleLinkedListMenuEnums.FindElement:
					Console.Write("Enter the Value:");
					obj.FindElement(Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.AddAfterElement:
					Console.Write("Enter the Element:");
					string element = Console.ReadLine();
					Console.Write("Enter value to be inserted:");
					obj.AddAfterElement(element, Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.AddBeforeElement:
					Console.Write("Enter the Element:");
					string element2 = Console.ReadLine();
					Console.Write("Enter value to be inserted:");
					obj.AddBeforeElement(element2, Console.ReadLine());
					break;
				case (int)SingleLinkedListMenuEnums.RemoveElement:
					Console.Write("Enter the Element:");
					obj.RemoveElement(Console.ReadLine());
					break;
				default:
					Console.WriteLine("Invalid Option");
					break;
			}
			ManageLinkedList(obj);
		}

		static void DisplayMenu()
		{
			Console.WriteLine("*** Linkedlist ***");
			foreach (int item in Enum.GetValues(typeof(SingleLinkedListMenuEnums)))
			{
				Console.WriteLine(SupportClassSingleLinkedList.menuDisplay[item]);
			}
		}
		#endregion

	}
	#endregion

	#region Enums
	public enum SingleLinkedListMenuEnums
	{
		displayElement = 1,
		getType,
		getLength,
		appendToEnd,
		appendToEndMany,
		appendToFirst,
		appendToFirstMany,
		RemoveFirstElement,
		RemoveLastElement,
		FindElement,
		AddAfterElement,
		AddBeforeElement,
		RemoveElement
	}
	#endregion
}
