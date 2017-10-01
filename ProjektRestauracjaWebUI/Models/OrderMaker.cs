using ProjektRestauracja.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjektRestauracja.WebUI.Models {
    public class OrderMaker {

        private List<OrderPosition> positions = new List<OrderPosition>();

        public int PositionNr { get; set; } = 1;

        public int IdToChange { get; set; }
        
        public List<OrderPosition> Positions { get { return positions; } set { positions = value; } }
        
        public IEnumerable<Product> Menu { get; set; }

        public void AddPosition(int productID) {
            bool inArray = false;
            foreach (var p in positions) {
                if (p.ProductID == productID) {
                    p.Quantity++;
                    inArray = true;
                    break;
                }
            }
            if (inArray == false) positions.Add(new OrderPosition() { OrderNr = 0, ProductID = productID, Quantity = 1, PositionNr = this.PositionNr++ }); 

        }

        public void RemovePosition(int productID) {

            OrderPosition toRemove;
            

                toRemove = positions.Find(x => x.ProductID == productID);
            if (toRemove.Quantity > 1) toRemove.Quantity--;
            else {
                positions.Remove(toRemove);
                PositionNr--;
            }
        }
        

        public decimal CalculateTotalCost () {
            decimal totalCost=0;
            foreach (var x in positions) {
                totalCost += x.Quantity * Menu.Where(p => p.ProductID == x.ProductID).Select(p => p.Price).SingleOrDefault();
            }
            return totalCost;
        }
    }
}