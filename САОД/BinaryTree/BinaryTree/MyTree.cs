using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BinaryTree
{
    class MyTree<T>
    {
        private BinaryTreeNode<T> root;
        int leafcount = 1;
        public MyTree()
        {

        }
        public void Add(T key)
        {
            Add(ref root, key);
        }
        private void Add(ref BinaryTreeNode<T> r, T key)
        {
            if (r == null)
            {
                r = new BinaryTreeNode<T>();
                r.Key = key;
            }
            else
            {
                if (Convert.ToInt32(r.Key) == Convert.ToInt32(key))
                {
                    return;
                }
                else
                {
                    if (Convert.ToInt32(r.Key) > Convert.ToInt32(key))
                    {
                        Add(ref r.Left, key);
                    }
                    else
                    {
                        Add(ref r.Right, key);
                    }
                }
                Balance(ref r, key);
            }
        }
        public void Remove(T key)
        {
            FindRemove(null, root, key);
            
        }
        private void FindRemove(BinaryTreeNode<T> parent, BinaryTreeNode<T> child, T key)
        {
            if (Convert.ToInt32(child.Key) == Convert.ToInt32(key))
            {

                if (child.Left == null && child.Right == null)
                {
                    if (parent == null)
                    {
                        root = null;
                    }
                    if (Convert.ToInt32(child.Key) < Convert.ToInt32(parent.Key))
                    {
                        parent.Left = null;
                    }
                    else
                    {
                        parent.Right = null;
                    }
                }
                else if (child.Left != null && child.Right == null)
                {
                    child.Key = child.Left.Key;
                    child.Key = child.Left.Key;
                    child.Right = child.Left.Right;
                    child.Left = child.Left.Left;

                }
                else if (child.Left == null && child.Right != null)
                {
                    child.Key = child.Right.Key;
                    child.Key = child.Right.Key;
                    child.Left = child.Right.Left;
                    child.Right = child.Right.Right;
                }
                else if (child.Left != null && child.Right != null)
                {
                    BinaryTreeNode<T> tmp = child.Right;
                    while (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                    }
                    T tkey1 = tmp.Key;
                    Remove(tmp.Key);
                    child.Key = tkey1;
                }
                
            }
            else
            {
                if (Convert.ToInt32(child.Key) > Convert.ToInt32(key) && child.Left != null)
                {
                    FindRemove(child, child.Left, key);
                }
                else
                {
                    FindRemove(child, child.Right, key);
                }
            } 
        }
        public int Level
        {
            get { return Level1(root); }
        }
        private int Level1(BinaryTreeNode<T> r)
        {
            if (r == null)
            {
                return -1;
            }
            else
            {
                return Math.Max(Level1(r.Left), Level1(r.Right)) + 1;
            }
        }
        private int GetBalance(BinaryTreeNode<T> r)
        {
            if (r == null)
            {
                return 0;
            }
            else
            {
                return (Level1(r.Left) - Level1(r.Right));
            }
        }
        public int Leaf
        {
            get { return LeafCount(root, leafcount); }
        }
        private int LeafCount(BinaryTreeNode<T> r, int leaf)
        {
            if (r == null)
            {
                return 0;
            }
            if (r != null && r.Left == null && r.Right == null)
            {
                return 1;
            }
            else
            {
                if (r.Left != null || r.Right != null)
                {
                    return LeafCount(r.Left, leaf) + LeafCount(r.Right, leaf);
                }
            }
            return leaf;
        }
        public void Draw(Graphics g, int width, int height, int EllSize)
        {
            g.Clear(Color.White);
            Draw(g, EllSize, root, 0 + width / 2, height / (Level + 2), width, height / (Level + 2));
        }
        private void Draw(Graphics g, int EllSize, BinaryTreeNode<T> r, int x, int y, int width, int LineHigh)
        {
            if (r == null)
            {
                return;
            }
            else
            {
                int xx = x; int yy = y;
                if (Convert.ToInt32(r.Key) > -10 && Convert.ToInt32(r.Key) < 10)
                {
                    xx = x + EllSize / 4 + 3;
                    yy = y + EllSize / 4 + 3;
                }
                else
                {
                    xx = x + EllSize / 4 - 3;
                    yy = y + EllSize / 4 + 3;
                }
                g.DrawEllipse(Pens.Black, x, y, EllSize, EllSize);
                g.DrawString(r.Key.ToString(), new Font("Arial", 16), Brushes.Black, xx, yy);

                if (r.Left != null)
                {
                    g.DrawLine(Pens.Black, x + EllSize / 2, y + EllSize, x - width / 4 + EllSize / 2, y + LineHigh);
                    Draw(g, EllSize, r.Left, x - width / 4, y + LineHigh, width / 2, LineHigh);
                }
                if (r.Right != null)
                {
                    g.DrawLine(Pens.Black, x + EllSize / 2, y + EllSize, x + width / 4 + EllSize / 2, y + LineHigh);
                    Draw(g, EllSize, r.Right, x + width / 4, y + LineHigh, width / 2, LineHigh);
                }
            }
        }
        public string LNRm()
        {
            string result = "";
            LNR(ref result, root);
            return result;
        }
        private void LNR(ref string Res, BinaryTreeNode<T> r)
        {
            if (r == null)
            {
                return;
            }
            else
            {
                LNR(ref Res, r.Left);
                Res += r.Key + ";";
                LNR(ref Res, r.Right);
            }
        }
        public string RNLm()
        {
            string result = "";
            RNL(ref result, root);
            return result;
        }
        private void RNL(ref string Res, BinaryTreeNode<T> r)
        {
            if (r == null)
            {
                return;
            }
            else
            {
                RNL(ref Res, r.Right);
                Res += r.Key + ";";
                RNL(ref Res, r.Left);
            }
        }
        public string NLRm()
        {
            string result = "";
            NLR(ref result, root);
            return result;
        }
        private void NLR(ref string Res, BinaryTreeNode<T> r)
        {
            if (r == null) return;
            else
            {
                Res += r.Key + ";";
                NLR(ref Res, r.Left);
                NLR(ref Res, r.Right);
            }
        }
        private void RightRotate(ref BinaryTreeNode<T> y)
        {
            BinaryTreeNode<T> x = y.Left;
            BinaryTreeNode<T> temp = x.Right;

            x.Right = y;
            y.Left = temp;
            y = x;

        }
        private void LeftRotate(ref BinaryTreeNode<T> x)
        {
            BinaryTreeNode<T> y = x.Right;
            BinaryTreeNode<T> temp = y.Left;

            y.Left = x;
            x.Right = temp;
            x = y;

        }
        public void Balance(ref BinaryTreeNode<T> r, T key)
        {
            if (r == null)
            {
                return;
            }
            else
            {
                int balance = GetBalance(r);
                // Right Right case
                if (balance > 1 && Convert.ToInt32(key) < Convert.ToInt32(r.Left.Key))
                {
                    RightRotate(ref r);
                }
                // Left Left case
                if (balance < -1 && Convert.ToInt32(key) > Convert.ToInt32(r.Right.Key))
                {
                    LeftRotate(ref r);
                }
                // Left Right case  
                if (balance > 1 && Convert.ToInt32(key) > Convert.ToInt32(r.Left.Key))
                {
                    LeftRotate(ref r.Left);
                    RightRotate(ref r);
                }
                // Right Left case
                if (balance < -1 && Convert.ToInt32(key) < Convert.ToInt32(r.Right.Key))
                {
                    RightRotate(ref r.Right);
                    LeftRotate(ref r);
                }
            }
        }
    }
}