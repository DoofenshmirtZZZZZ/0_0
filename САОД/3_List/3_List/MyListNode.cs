using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_List
{
	class MyListNode<T>
	{
	 
		public MyListNode(T data)
		{
			Data = data;
		}
		public T Data { get; set; }
		public MyListNode<T> Next { get; set; }

    }
}
