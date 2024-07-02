using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5_Plenty
{
	class MySet<T>: IEnumerable<T>
	{

		private List<T> _items = new List<T>();

		public int Count => _items.Count;

		public void Add(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			// Множество может содержать только уникальные элементы,
			// поэтому если множество уже содержит такой элемент данных, то не добавляем его.
			if (!_items.Contains(item))
			{
				_items.Add(item);
			}
		} 

		public void Remove(T item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			// Если коллекция не содержит данный элемент, то мы не можем его удалить.
			if (!_items.Contains(item))
			{
				throw new KeyNotFoundException($"Элемент {item} не найден в множестве.");
			}

			// Удаляем элемент из коллекции.
			_items.Remove(item);
		}

		public static MySet<T> Union(MySet<T> set1, MySet<T> set2)
		{
			if (set1 == null)
			{
				throw new ArgumentNullException(nameof(set1));
			}

			if (set2 == null)
			{
				throw new ArgumentNullException(nameof(set2));
			}

			var resultSet = new MySet<T>();
			var items = new List<T>();

			// Если первое входное множество содержит элементы данных,
			// то добавляем их в результирующее множество.
			if (set1._items != null && set1._items.Count > 0)
			{
				// т.к. список является ссылочным типом, 
				// то необходимо не просто передавать данные, а создавать их дубликаты.
				items.AddRange(new List<T>(set1._items));
			}

			// Если второе входное множество содержит элементы данных, 
			// то добавляем из в результирующее множество.
			if (set2._items != null && set2._items.Count > 0)
			{
				// т.к. список является ссылочным типом, 
				// то необходимо не просто передавать данные, а создавать их дубликаты.
				items.AddRange(new List<T>(set2._items));
			}

			// Удаляем все дубликаты из результирующего множества элементов данных.
			resultSet._items = items.Distinct().ToList();

			// Возвращаем результирующее множество.
			return resultSet;
		}

		public static MySet<T> Intersection(MySet<T> set1, MySet<T> set2)
		{
			if (set1 == null)
			{
				throw new ArgumentNullException(nameof(set1));
			}

			if (set2 == null)
			{
				throw new ArgumentNullException(nameof(set2));
			}

			var resultSet = new MySet<T>();

			// Выбираем множество содержащее наименьшее количество элементов.
			if (set1.Count < set2.Count)
			{
				// Первое множество меньше.
				// Проверяем все элементы выбранного множества.
				foreach (var item in set1._items)
				{
					// Если элемент из первого множества содержится во втором множестве,
					// то добавляем его в результирующее множество.
					if (set2._items.Contains(item))
					{
						resultSet.Add(item);
					}
				}
			}
			else
			{
				// Второе множество меньше или множества равны.
				// Проверяем все элементы выбранного множества.
				foreach (var item in set2._items)
				{
					// Если элемент из второго множества содержится в первом множестве,
					// то добавляем его в результирующее множество.
					if (set1._items.Contains(item))
					{
						resultSet.Add(item);
					}
				}
			}

			// Возвращаем результирующее множество.
			return resultSet;
		}

		public static MySet<T> Difference(MySet<T> set1, MySet<T> set2)
		{
			if (set1 == null)
			{
				throw new ArgumentNullException(nameof(set1));
			}

			if (set2 == null)
			{
				throw new ArgumentNullException(nameof(set2));
			}

			var resultSet = new MySet<T>();

			// Проходим по всем элементам первого множества.
			foreach (var item in set1._items)
			{
				// Если элемент из первого множества не содержится во втором множестве,
				// то добавляем его в результирующее множество.
				if (!set2._items.Contains(item))
				{
					resultSet.Add(item);
				}
			}

			// Проходим по всем элементам второго множества.
			foreach (var item in set2._items)
			{
				// Если элемент из второго множества не содержится в первом множестве,
				// то добавляем его в результирующее множество.
				if (!set1._items.Contains(item))
				{
					resultSet.Add(item);
				}
			}

			// Удаляем все дубликаты из результирующего множества элементов данных.
			resultSet._items = resultSet._items.Distinct().ToList();

			// Возвращаем результирующее множество.
			return resultSet;
		}

		public static bool Subset(MySet<T> set1, MySet<T> set2)
		{
			if (set1 == null)
			{
				throw new ArgumentNullException(nameof(set1));
			}

			if (set2 == null)
			{
				throw new ArgumentNullException(nameof(set2));
			}

			// Перебираем элементы первого множества.
			// Если все элементы первого множества содержатся во втором,
			// то это подмножество. Возвращаем истину, иначе ложь.
			var result = set1._items.All(s => set2._items.Contains(s));
			return result;
		}

		public IEnumerator<T> GetEnumerator()
		{
			// Используем перечислитель списка элементов данных множества.
			return _items.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			// Используем перечислитель списка элементов данных множества.
			return _items.GetEnumerator();
		}
	}
}
