using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace miller0061072133
{

    public class Cart 
    {
        // Getters and Setters
        private List<CartItem> Items { get; set; }

        // Constructors
        public Cart()
        {
            Items = new List<CartItem>();
        }

        // Private
        private int ItemIndexOf(string ID)
        {
            foreach (CartItem item in Items)
            {
                if (item.GetID() == ID)
                {
                    return Items.IndexOf(item);
                }
            }
            return -1;
        }

        // Public
        public List<CartItem> GetItems()
        {
            return this.Items;
        }

        public CartItem GetItem(int index)
        {
            return this.Items[index];
        }

        public void Insert(CartItem item)
        {
            int index = ItemIndexOf(item.GetID());
            if (index == -1)
            {
                Items.Add(item);
            }
            else
            {
                Items[index].SetQuantity(Items[index].GetQuantity() + 1);
            }
        }

        public void Delete(int rowID)
        {
            Items.RemoveAt(rowID);
        }

        public void Update(int rowID, int Quantity)
        {
            if (Quantity > 0)
            {
                Items[rowID].SetQuantity(Quantity);
            }
            else
            {
                Delete(rowID);
            }
        }

        public double GrandTotal
        {
            get
            {
                if (Items == null)
                {
                    return 0;
                }
                else
                {
                    double grandTotal = 0;
                    foreach (CartItem item in Items)
                    {
                        grandTotal += item.GetQuantity() * item.GetPrice();
                    }
                    return grandTotal;
                }
            }
        }
    }
}