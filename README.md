# Steam Automation Project

This project contains automated tests for [Steam Store](https://store.steampowered.com) implemented using **Aquality Selenium**, **NUnit**, and **SpecFlow** with **Gherkin BDD** syntax.

---

## Project Overview

The automation covers the following test cases on the Steam Store:

### Steam Tests

- **Test Case 1: Privacy Policy**
  - Navigate to main page.
  - Open the Privacy Policy page in a new tab.
  - Verify language selection options and supported languages.
  - Confirm the policy revision is signed in the current year.

- **Test Case 2: Browsing Top Sellers**
  - Navigate to main page.
  - Select ‘Top Sellers’ under "BROWSE CATEGORIES".
  - Filter by price "Under $5.00".
  - Filter by tags: 'Puzzle', '2D', 'Fantasy' and OS: 'SteamOS + Linux'.
  - Verify checkboxes and search results count.
  - Extract and validate first game’s name, release date, and price.
  - Verify game details page matches extracted info.

- **Test Case 3: Community Market Search**
  - Navigate to main page.
  - Open Community Market.
  - Use advanced search filters (game, hero, rarity, search term).
  - Verify filters applied correctly.
  - Save first item info and validate it after removing filters.

### Steam Game List Search and Sorting

- Navigate to main page.
- Search games by name.
- Verify search results are not empty.
- Sort games by price descending.
- Verify sorting correctness for first N games.
- Test data includes games “The Witcher” and “Fallout” with respective top N results.

---

## Tech Stack

- **Aquality Selenium** — Browser automation framework  
- **NUnit** — Testing framework  
- **SpecFlow** — BDD automation with Gherkin syntax  
- **C#** — Programming language  
- **ChromeDriver** — Chrome browser driver (replaceable with other drivers)  

---

## Setup & Running Tests

### Prerequisites

- [.NET 6+ SDK](https://dotnet.microsoft.com/download)  
- Chrome browser installed  
- Compatible ChromeDriver executable  
- IDE like Visual Studio or VS Code (recommended)  

### Running tests

1. Clone the repository:

   ```bash
   git clone https://github.com/yourusername/SteamAutomation.git
   cd SteamAutomation
2. Run tests
