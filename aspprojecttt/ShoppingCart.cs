using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace aspprojecttt {
    public class ShoppingCart {
        private List<int> productList;

        public ShoppingCart() {
            productList = new List<int>();
        }

        public void AddItem(String itemId) {
            int id = int.Parse(itemId);
            productList.Add(id);
        }

        public void RemoveItem(String itemId) {
            int id = int.Parse(itemId);
            productList.Add(id);
        }

        public void AddItem(int itemId) {
            productList.Add(itemId);
        }

        public void RemoveItem(int itemId) {
            productList.Add(itemId);
        }

        public List<int> getProductList() {
            return productList;
        }

        public int getProductListSize() {
            return productList.Count;
        }
    }
}