# Simple Inventory Management System

![MicrosoftSQLServer](https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white)

## Architecture

![Component Diagram](designs/Excalidraw-ComponentDiagram.png)

Explore it interactively [here](https://excalidraw.com/#json=FHVbiyNho8wcwSi_oFxpQ,eC3zLhxj9dGv2hAzjH4mjQ).

## Setup

1. **Preparing The Database:**
    1. Create the database - With any name on any environment,
       as long as you have its connection string.
    2. Switch context to it.
    3. Run `db/scripts/TABLES.sql` to create the schema.
    4. Run `db/scripts/DATA.sql` if you want sample data.
2. Add the environmental variable: `SQL_CONNECTION_STRING`.

## Description

In this console-based application, you'll create a basic inventory management system. This system will
allow a user to manage a list of products, where each product has a name, price, and quantity in stock.

**GitHub requirements:** You must use Git for version control and host your project on GitHub. Commit and push your
changes to GitHub at the end of each phase, with meaningful commit messages describing what you have implemented in each
commit.

Here are the main functionalities the system should have:

1. **Add a product:** Prompt the user for the product name, price, and quantity, then add the product to the inventory.
   *Commit the changes and push them to GitHub.*
2. **View all products:** Display a list of all products in the inventory, along with their prices and quantities.
   *Commit and push.*
3. **Edit a product:** Ask the user for a product name. If the product is in the inventory, allow the user to update its
   name, price, or quantity. *Commit and push.*
4. **Delete a product:** Ask the user for a product name. If the product is in the inventory, remove it. *Commit and
   push.*
5. **Search for a product:** Ask the user for a product name. If the product is in the inventory, display its name,
   price, and quantity. If not, let the user know the product was not found. *Commit and push.*
6. **Exit:** Close the application. *Final commit and push.*

For this project, you'll want to create a **`Product`** class with the appropriate properties (name, price, quantity)
and methods. You'll also want to create an **`Inventory`** class which maintains a list of **`Product`** objects and
provides methods for adding, deleting, and editing products.

This will give you practice with object-oriented programming, basic data structures (like lists), user input/output,
control flow, and version control using Git and GitHub.
