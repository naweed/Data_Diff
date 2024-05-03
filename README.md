# DATA-DIFF: A tool to copare data in two SQL tables with (almost) same structures
Data-Diff is a tool built using .NET, which allows you to compare data in two SQL tables and identify differences (data missing in one table vs. the other, or difference in values in the same record between two tables). 

## Roadmap
This is a full working app. The following enhancements are in the pipeline:
* Add SQL Authentication (very simple to do - will take me 5 mins, but I am just lazy)
* Ability to extract data differences in CSV/Excel file
* Dynamically get columns list (along with Primary key) from two tables and compare data automatically for the common columns
* Support for Composite Primary Keys

## How to use
You need the follwing information to be provided to the tool for the comparison to work:
| Property | Data Type | Explanation |
| :--- | :----: | :--- |
| Server 1      | String       | The name of the first SQL Server + Instance    |
| Database 1   | String        | The database on Server 1 where the first table is hosted      |
| Table 1   | String        | The name of the first table used in comparison      |
| Server 2      | String       | The name of the second SQL Server + Instance    |
| Database 2   | String        | The database on Server 2 where the second table is hosted      |
| Table 2   | String        | The name of the second table used in comparison      |
| Primary Key   | String        | The primary key in the tables (e.g. ID)        |
| Columns to Cpmapre   | String        | List of (common) columns between two tables who data is to be compared       |