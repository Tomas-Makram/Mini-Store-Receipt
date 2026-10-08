using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mini_Store_Receipt_Program
{
    // Receipt Item
    public class ReceiptItem
    {
        public string ItemName { get; set; } = "";
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public decimal Total
        {
            get
            {
                return Price * Quantity;
            }
        }
    }

    // Store
    public class MyStore
    {
        // Category
        private class Category
        {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; } = "";
            public List<Items> Items { get; set; } = new List<Items>();
        }

        // Item
        private class Items
        {
            public int ItemId { get; set; }
            public string ItemName { get; set; } = "";
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }

        // Store Categories
        private List<Category> myStore { get; set; } = new List<Category>();

        // Store Name
        private string name = "";

        // Constructor
        public MyStore()
        {
            // =========================
            // Electronics
            // =========================

            Category electronics = new Category
            {
                CategoryId = 1,
                CategoryName = "Electronics"
            };

            electronics.Items.Add(new Items
            {
                ItemId = 1,
                ItemName = "Laptop",
                Price = 999.99m,
                Quantity = 5
            });

            electronics.Items.Add(new Items
            {
                ItemId = 2,
                ItemName = "Smartphone",
                Price = 699.99m,
                Quantity = 10
            });

            electronics.Items.Add(new Items
            {
                ItemId = 3,
                ItemName = "Headphones",
                Price = 89.99m,
                Quantity = 8
            });


            // =========================
            // Groceries
            // =========================

            Category groceries = new Category
            {
                CategoryId = 2,
                CategoryName = "Groceries"
            };

            groceries.Items.Add(new Items
            {
                ItemId = 1,
                ItemName = "Apple",
                Price = 0.99m,
                Quantity = 50
            });

            groceries.Items.Add(new Items
            {
                ItemId = 2,
                ItemName = "Milk",
                Price = 2.49m,
                Quantity = 30
            });

            groceries.Items.Add(new Items
            {
                ItemId = 3,
                ItemName = "Bread",
                Price = 1.50m,
                Quantity = 25
            });

            groceries.Items.Add(new Items
            {
                ItemId = 4,
                ItemName = "Cheese",
                Price = 4.99m,
                Quantity = 15
            });


            // =========================
            // Clothing
            // =========================

            Category clothing = new Category
            {
                CategoryId = 3,
                CategoryName = "Clothing"
            };

            clothing.Items.Add(new Items
            {
                ItemId = 1,
                ItemName = "T-Shirt",
                Price = 15.99m,
                Quantity = 20
            });

            clothing.Items.Add(new Items
            {
                ItemId = 2,
                ItemName = "Jeans",
                Price = 39.99m,
                Quantity = 12
            });


            // =========================
            // Books
            // =========================

            Category books = new Category
            {
                CategoryId = 4,
                CategoryName = "Books"
            };

            books.Items.Add(new Items
            {
                ItemId = 1,
                ItemName = "C# Programming",
                Price = 29.99m,
                Quantity = 10
            });

            books.Items.Add(new Items
            {
                ItemId = 2,
                ItemName = "Clean Code",
                Price = 34.99m,
                Quantity = 7
            });

            books.Items.Add(new Items
            {
                ItemId = 3,
                ItemName = "Design Patterns",
                Price = 39.99m,
                Quantity = 5
            });


            // Add categories to store

            myStore.Add(electronics);
            myStore.Add(groceries);
            myStore.Add(clothing);
            myStore.Add(books);
            this.name = name?.Trim() ?? "";
        }

        // Display Categories
        public void DisplayCategories()
        {
            Console.WriteLine();
            Console.WriteLine("========== Categories ==========");

            foreach (Category category in myStore)
            {
                Console.WriteLine(
                    $"{category.CategoryId}. {category.CategoryName}"
                );
            }

            Console.WriteLine("0. Finish Shopping");
        }

        // Display Items
        public void DisplayItems(int categoryId)
        {
            Category? category = GetCategory(categoryId);

            if (category == null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            Console.WriteLine();
            Console.WriteLine($"========== {category.CategoryName} ==========");

            if (category.Items.Count == 0)
            {
                Console.WriteLine("No items available.");
                return;
            }

            foreach (Items item in category.Items)
            {
                Console.WriteLine(
                    $"{item.ItemId}. {item.ItemName} - ${item.Price:F2} - Available: {item.Quantity}"
                );
            }

            Console.WriteLine("0. Back");
        }

        // Get Category
        private Category? GetCategory(int categoryId)
        {
            foreach (Category category in myStore)
            {
                if (category.CategoryId == categoryId)
                {
                    return category;
                }
            }

            return null;
        }

        // Get Item
        private Items? GetItem(int categoryId, int itemId)
        {
            Category? category = GetCategory(categoryId);

            if (category == null)
            {
                return null;
            }

            foreach (Items item in category.Items)
            {
                if (item.ItemId == itemId)
                {
                    return item;
                }
            }

            return null;
        }

        // Check Item Availability
        public bool IsItemAvailable(int categoryId, int itemId)
        {
            Items? item = GetItem(categoryId, itemId);
            if (item == null)
            {
                return false;
            }
            return true;
        }


        // Buy Item
        public ReceiptItem? BuyItem(int categoryId, int itemId, int quantity)
        {
            Items? item = GetItem(categoryId, itemId);

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return null;
            }

            if (quantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return null;
            }

            if (quantity > item.Quantity)
            {
                Console.WriteLine(
                    $"Not enough stock. Available quantity: {item.Quantity}"
                );

                return null;
            }


            // Purchase Confirmation
            decimal total = item.Price * quantity;

            Console.WriteLine();
            Console.WriteLine("========== Purchase Confirmation ==========");
            Console.WriteLine($"Product : {item.ItemName}");
            Console.WriteLine($"Price    : ${item.Price:F2}");
            Console.WriteLine($"Quantity : {quantity}");
            Console.WriteLine($"Total    : ${total:F2}");

            Console.Write("Confirm purchase? (Y/N): ");

            string confirmation = Console.ReadLine() ?? "";

            if (
                confirmation != "Y" &&
                confirmation != "y")
            {
                Console.WriteLine("Purchase cancelled.");
                return null;
            }


            // Remove purchased quantity from stock
            item.Quantity -= quantity;


            // Add item to receipt
            ReceiptItem receiptItem = new ReceiptItem
            {
                ItemName = item.ItemName,
                Price = item.Price,
                Quantity = quantity
            };

            Console.WriteLine("Purchase completed successfully!");

            return receiptItem;
        }
    }

    // Receipt
    public class Receipt
    {
        // Customer Name
        private string customerName;

        // Discount
        private decimal discount;

        private List<ReceiptItem> purchasedItems = new List<ReceiptItem>();

        // Format customer name to title case and remove extra spaces
        private string FormatName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Unknown";
            }

            string formattedName = string.Join(" ", name.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(formattedName.ToLower());
        }

        // Constructor
        public Receipt(string customerName, decimal discount)
        {
            this.customerName = FormatName(customerName);
            this.discount = discount;
        }

        // Add Item
        public void AddItem(ReceiptItem item)
        {
            purchasedItems.Add(item);
        }

        // Calculate Total
        public decimal GetTotal()
        {
            decimal total = 0;

            foreach (ReceiptItem item in purchasedItems)
            {
                total += item.Total;
            }

            return total;
        }

        // Calculate Discount Amount
        public decimal GetDiscountAmount()
        {
            return GetTotal() * discount / 100;
        }

        // Calculate Final Total After Discount
        public decimal GetFinalTotal()
        {
            return GetTotal() - GetDiscountAmount();
        }

        // Display Receipt
        public void DisplayReceipt()
        {
            Console.WriteLine();
            Console.WriteLine("""
==============================================
                 RECEIPT
==============================================
""");

            Console.WriteLine($"Customer: {customerName}");

            Console.WriteLine("----------------------------------------------");

            if (purchasedItems.Count == 0)
            {
                Console.WriteLine("No items purchased.");
            }
            else
            {
                foreach (ReceiptItem item in purchasedItems)
                {
                    Console.WriteLine($"Product  : {item.ItemName} X {item.Quantity} = ${item.Total:F2}");
                }
            }

            Console.WriteLine($"Subtotal : ${GetTotal():F2}");
            Console.WriteLine($"Discount : {discount:F0}% (-${GetDiscountAmount():F2})");
            Console.WriteLine($"TOTAL    : ${GetFinalTotal():F2}");

            Console.WriteLine("""
==============================================
            Thank You For Shopping!
==============================================
                
""");
        }
    }
}
