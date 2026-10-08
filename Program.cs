namespace Mini_Store_Receipt_Program
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Logo logo = new Logo();
            logo.Display();

            // Get customer name
            Console.Write("Enter Customer Name: ");

            string customerName = Console.ReadLine() ?? "";

            // Create Receipt
            Receipt receipt = new Receipt(customerName, 10);

            // Create Store
            MyStore store = new MyStore();

            // Main Shopping Loop
            bool shopping = true;

            while (shopping)
            {
                store.DisplayCategories();

                Console.WriteLine();

                Console.Write("Choose Category: ");

                string categoryInput = Console.ReadLine() ?? "";

                // Validate category input
                if (!int.TryParse(categoryInput, out int categoryId))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                // Exit Shopping
                if (categoryId == 0)
                {
                    shopping = false;
                    break;
                }

                // Check Category
                store.DisplayItems(categoryId);

                Console.WriteLine();

                Console.Write("Choose Item: ");

                string itemInput = Console.ReadLine() ?? "";

                // validate item input
                if (!int.TryParse(itemInput, out int itemId))
                {
                    Console.WriteLine("Please enter a valid number.");
                    continue;
                }

                // Back to Categories
                if (itemId == 0)
                    continue;

                // Check Item Availability
                if (!store.IsItemAvailable(categoryId, itemId))
                {
                    Console.WriteLine("Item not available.");
                    continue;
                }

                // Get Quantity
                Console.Write("Enter Quantity: ");

                string quantityInput = Console.ReadLine() ?? "";

                // Validate Quantity
                if (!int.TryParse(quantityInput, out int quantity))
                {
                    Console.WriteLine("Please enter a valid quantity.");
                    continue;
                }

                // Purchase
                ReceiptItem? purchasedItem = store.BuyItem(categoryId, itemId, quantity);

                // Add to Receipt
                if (purchasedItem != null)
                    receipt.AddItem(purchasedItem);

                // Ask if user wants to continue
                Console.WriteLine("\nPress ENTER to continue...");
                Console.ReadLine();
            }

            // Final Receipt
            receipt.DisplayReceipt();
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}