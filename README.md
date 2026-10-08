<div align="center">

# 🛒 Mini Store Receipt Program

### A colorful console shopping experience built with C# and .NET

![C#](https://img.shields.io/badge/C%23-14.0-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Platform](https://img.shields.io/badge/Platform-Console-informational?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Complete-success?style=for-the-badge)

*Browse categories, pick products, confirm your purchase, and get a clean itemized receipt with an automatic discount.*

</div>

---

## 📖 Table of Contents

- [About](#-about)
- [Features](#-features)
- [Demo](#-demo)
- [Store Catalog](#-store-catalog)
- [Project Structure](#-project-structure)
- [How It Works](#-how-it-works)
- [Concepts Practiced](#-concepts-practiced)
- [Getting Started](#-getting-started)
- [Roadmap](#-roadmap)
- [Author](#-author)

---

## 🎯 About

**Mini Store Receipt Program** is a console application that simulates a small store. The customer enters their name, browses product categories, buys items with live stock tracking, and finishes with a professionally formatted receipt that includes a subtotal, a discount, and a final total.

The project is built around clean object-oriented design: the store, its categories and items, the receipt, and the startup logo each live in their own well-defined class.

---

## ✨ Features

| | Feature | Description |
|---|---|---|
| 🎨 | **Random ASCII Welcome Logo** | A different ASCII art banner (keyboard, book, or camera) greets you on every launch. |
| 👤 | **Smart Name Formatting** | Extra spaces are removed and names are converted to Title Case (`jOhN   dOE` becomes `John Doe`). Empty names fall back to `Unknown`. |
| 🗂️ | **Category Navigation** | Browse four categories and move back and forth between categories and items. |
| 📦 | **Live Stock Management** | Every purchase reduces the available quantity, and the program blocks orders that exceed stock. |
| ✅ | **Purchase Confirmation** | A summary (product, price, quantity, total) is shown before you confirm with `Y` or `N`. |
| 🧾 | **Itemized Receipt** | Each purchased product, the subtotal, the discount, and the final total are printed clearly. |
| 💸 | **Automatic 10% Discount** | A discount is applied to the whole receipt. |
| 🛡️ | **Input Validation** | Invalid numbers, missing items, zero or negative quantities, and over-stock requests are all handled gracefully. |

---

## 🖥️ Demo

```text
Welcome to the Mini Store
 ... (random ASCII logo) ...

Enter Customer Name: tomas   makram

========== Categories ==========
1. Electronics
2. Groceries
3. Clothing
4. Books
0. Finish Shopping

Choose Category: 2

========== Groceries ==========
1. Apple - $0.99 - Available: 50
2. Milk - $2.49 - Available: 30
3. Bread - $1.50 - Available: 25
4. Cheese - $4.99 - Available: 15
0. Back

Choose Item: 2
Enter Quantity: 3

========== Purchase Confirmation ==========
Product : Milk
Price    : $2.49
Quantity : 3
Total    : $7.47
Confirm purchase? (Y/N): y
Purchase completed successfully!

Press ENTER to continue...
```

And the final receipt after finishing shopping:

```text
==============================================
                 RECEIPT
==============================================
Customer: Tomas Makram
----------------------------------------------
Product  : Milk X 3 = $7.47
Product  : Clean Code X 1 = $34.99
Subtotal : $42.46
Discount : 10% (-$4.25)
TOTAL    : $38.21
==============================================
            Thank You For Shopping!
==============================================
```

---

## 🏪 Store Catalog

<details>
<summary><b>Click to view all products</b></summary>

<br>

### 💻 Electronics
| ID | Product | Price | Stock |
|:--:|---------|------:|:-----:|
| 1 | Laptop | $999.99 | 5 |
| 2 | Smartphone | $699.99 | 10 |
| 3 | Headphones | $89.99 | 8 |

### 🥛 Groceries
| ID | Product | Price | Stock |
|:--:|---------|------:|:-----:|
| 1 | Apple | $0.99 | 50 |
| 2 | Milk | $2.49 | 30 |
| 3 | Bread | $1.50 | 25 |
| 4 | Cheese | $4.99 | 15 |

### 👕 Clothing
| ID | Product | Price | Stock |
|:--:|---------|------:|:-----:|
| 1 | T-Shirt | $15.99 | 20 |
| 2 | Jeans | $39.99 | 12 |

### 📚 Books
| ID | Product | Price | Stock |
|:--:|---------|------:|:-----:|
| 1 | C# Programming | $29.99 | 10 |
| 2 | Clean Code | $34.99 | 7 |
| 3 | Design Patterns | $39.99 | 5 |

</details>

---

## 📁 Project Structure

```text
Mini Store Receipt Program/
├── Program.cs     # Entry point: main shopping loop and user input handling
├── MyStore.cs     # Store, Category, Items, ReceiptItem, and Receipt classes
└── Logo.cs        # Random ASCII art welcome banner
```

### Class Overview

| Class | Responsibility |
|-------|----------------|
| `Program` | Runs the main loop: reads input, validates it, and coordinates the store and receipt. |
| `MyStore` | Holds the categories and items, displays menus, checks availability, and processes purchases. |
| `ReceiptItem` | Represents one purchased line (name, price, quantity, and a computed `Total`). |
| `Receipt` | Collects purchased items, formats the customer name, and calculates subtotal, discount, and final total. |
| `Logo` | Picks and prints a random ASCII banner using raw string literals. |

---

## ⚙️ How It Works

```text
        ┌──────────────────┐
        │  Show Logo       │
        └────────┬─────────┘
                 ▼
        ┌──────────────────┐
        │ Enter Name       │
        └────────┬─────────┘
                 ▼
   ┌────────────────────────────┐
   │  Choose Category (0 = Exit)│◄───────────┐
   └────────────┬───────────────┘            │
                ▼                            │
   ┌────────────────────────────┐            │
   │  Choose Item (0 = Back)    │────────────┤
   └────────────┬───────────────┘            │
                ▼                            │
   ┌────────────────────────────┐            │
   │  Enter Quantity            │            │
   └────────────┬───────────────┘            │
                ▼                            │
   ┌────────────────────────────┐            │
   │  Confirm Purchase (Y/N)    │────────────┘
   └────────────────────────────┘
                │ (Category 0)
                ▼
   ┌────────────────────────────┐
   │  Print Final Receipt       │
   └────────────────────────────┘
```

**Pricing formula**

```text
Subtotal       = Σ (Price × Quantity)
Discount       = Subtotal × 10%
Final Total    = Subtotal − Discount
```

---

## 🧠 Concepts Practiced

- Object-Oriented Programming: encapsulation, classes, and private nested classes
- Properties, including computed (read-only) properties
- Collections with `List<T>`
- Nullable reference types (`Category?`, `Items?`, `ReceiptItem?`)
- Input validation with `int.TryParse`
- String handling: `TextInfo.ToTitleCase`, `Split`, `Join`, and formatting with `:F2`
- C# raw string literals (`"""`) for ASCII art and receipt layout
- Separation of concerns across multiple files

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK 10.0](https://dotnet.microsoft.com/download) (or the version set in the `.csproj`)
- Any terminal, or Visual Studio / VS Code / Rider

### Run from the terminal

```bash
# 1. Clone the repository
git clone https://github.com/Tomas-Makram/Mini-Store-Receipt.git

# 2. Move into the project folder
cd Mini-Store-Receipt

# 3. Run it
dotnet run
```

### Run from Visual Studio

1. Open the project folder (or the `.csproj`) in Visual Studio.
2. Press **F5** or **Ctrl + F5**.

> 💡 For the ASCII art to look right, use a terminal with a monospaced font and a window wide enough for the banner.

---

## 🗺️ Roadmap

- [ ] Support multiple items from the same category without returning to the menu
- [ ] Remove or edit items from the receipt before checkout
- [ ] Save receipts to a `.txt` file
- [ ] Load products from a JSON file instead of hard-coding them
- [ ] Configurable discount rules (by total, by category, or coupon code)
- [ ] Add colors to the console output
- [ ] Unit tests for `Receipt` and `MyStore`

---

## 👨‍💻 Author

**Tomas Makram**

[![GitHub](https://img.shields.io/badge/GitHub-Tomas--Makram-181717?style=for-the-badge&logo=github)](https://github.com/Tomas-Makram)

---

<div align="center">

⭐ If you found this project useful, consider giving it a star!

</div>