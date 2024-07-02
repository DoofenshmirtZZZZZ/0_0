using System.Collections;
using System.Collections.Generic;

namespace _3_List 
{
	public class MyList<T> : IEnumerable<T>
	{
		MyListNode<T> head; // головной/первый элемент
		MyListNode<T> tail; // последний/хвостовой элемент
		int count;  // количество элементов в списке

		// добавление элементов начало,конец,индекс
		public void Add(T data)
		{

			MyListNode<T> node = new MyListNode<T>(data);
			MyListNode<T> node_f = new MyListNode<T>(data);

			if (head == null)
				head = node;
			else
				tail.Next = node;
			tail = node;

			count++;
		}
		public void AppendFirst(T data)
		{
			MyListNode<T> node = new MyListNode<T>(data);
			node.Next = head;
			head = node;
			if (count == 0)
				tail = head;
			count++;
		}
		public void AddBefore(T data, int indexAdd)
		{
			int leng()
			{
				int res = 0;
				MyListNode<T> t = head;
				while (t != null)
				{
					t = t.Next;
					res++;
				}
				return res++;
			}

			MyListNode<T> node = new MyListNode<T>(data);

			if (indexAdd >= leng())
			{
				return;
			}
			else
			{
				int ind = 0;
				MyListNode<T> t = head;
				while (ind < indexAdd - 1)
				{
					t = t.Next;
					ind++;
				}
				node.Next = t.Next;
				t.Next = node;
			}

			count++;
		}
		
		// возврат значения по индексу
		public string GetByIndex(int indexGet)
		{
			int i = 0;
			string blat = "N";
			var current = head;
			
			while (current != null)
			{
				if (i == indexGet)
				{
					blat = current.ToString();
					break;
				}
				current = current.Next;
				i++;
			}

			return blat;	
		}

		public override string ToString() 
		{
			return head + " ;" + tail;
		}


		// удаление элемента
		public void Remove(int indexGet)
		{
			int i = 0;			
			var current = head;
			MyListNode<T> previous = null;

			while (current != null)
			{
				
				if (i == indexGet)
				{
					
					if (previous != null)
					{
						previous.Next = current.Next;

						if (current.Next == null)
						{
							tail = previous;
						}
					}
					else
					{
						head = head.Next;

						if (head == null)
						{
							tail = null;
						}
					}

					count--;
					break;
				}

				previous = current;
				current = current.Next;
				i++;

			}
		}

		// кол-во элементов
		public int Count { get { return count; } }
		public bool IsEmpty { get { return count == 0; } }
		
		// очистка списка
		public void Clear()
		{
			head = null;
			tail = null;
			count = 0;
		}
		
		// содержит ли список элемент
		public bool Contains(T data)
		{
			MyListNode<T> current = head;
			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;
				current = current.Next;
			}
			return false;
		}

		// реализация интерфейса IEnumerable
		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)this).GetEnumerator();
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			MyListNode<T> current = head;
			while (current != null)
			{
				yield return current.Data;
				current = current.Next;
			}
		}
	}
}
