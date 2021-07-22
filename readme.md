# E - Market
	this project was in collaboration with 3 other students from my university
	
## Installation
You first have to set Microsoft SQL Server Manager 
[Download SQL Server Management Studio (SSMS) - SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
![8afcd9952bf1a39a20e92419ca938bdc.png](/_resources/47a9d2401d48466d97923d63e596626f.png)
Connect to the local database 
![14d94930241319ba03c0fd07d36e1a5e.png](/_resources/159a02682713475ab01665786c9d7517.png)

```
(LocalDB)\MSSQLLocalDB
```
the name is important to be exactly the same as that is the name that is contained in the connection string

![2d97a8f557f44cf9e51e9d76396aa889.png](/_resources/9d2a737557fc470387256811314eda12.png)
Create a database with the name 
```
emarket
```
same case here, the name of the database is in the connection string

Now  that we have the database ready time to fill it,
![ab0f25328eb93f3b9abafd8a20929623.png](/_resources/6fddc844c3c74dbfad679bfe09d68038.png)

Click new query and import the final.sql file that has all the sql statements we need
![4031ce0bb32f08d71ca901b59db2df71.png](/_resources/60669f1fe93948759e6c75991650543d.png)

![960de183697569aff442f806fa66e885.png](/_resources/d6591d80d4ca431d847e096dc6754a99.png)
and click execute.

Our database is ready.

For the code part, all you have to do is open the emarket.sln with visual studio (tested with VS 2019 Enterprise)
and all should be ready! 
![895be7c41ac3da508cdc70dc588a072a.png](/_resources/f1b0bd8d87d74a82b2abcbad6adc912c.png)
![df2fd876a42ce13e741cb77af0a5e53c.png](/_resources/c0429716a4f34ed8a4b358f4ebd958b4.png)