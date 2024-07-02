using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue<T>
    {
        public List<T> nums = new List<T>();
        public int capacity;
        public int tek = -1;
        public void Push(T a)
        {
            nums.Add(a);
            tek++;
        }
        public void Pop()
        {
            nums.Remove(nums[0]);
            tek--;
        }
        public int Top()
        {
            return 0;
        }
        public void Clear()
        {
            nums.Clear();
            tek = -1;
        }
    }
}
