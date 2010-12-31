there are mainly 4 project in the solution:
1,SalesTaxes.Core                 --contains all domain classes.
2,SalesTaxes.View                 --contains classes which are responsible for "Printing" the Sales Order.
3,SalesTaxes.AcceptanceTest       --implement the given three examples as integration tests.
4.SalesTaxes.UnitTest             --all unit test.

main classes in SalesTaxes.Core are(from inside out):
1,ProductDescriptor: encapsulates "name", "category" and "applicable units" of the product.
2,PurchaseItem:      encapsulates "ProductDescriptor", "purchase unit" and "IsImported"
3,Product:           encapsulates "PurchaseItem", "Sale unit", "Price". implementing IProduct interface.
4,OrderLine:         encapsulates "IProduct", "Quantity". implementing ITaxable interface and need ITaxService to calculate the tax.
5,SalesOrder:        encapsulates a list of "OrderLine".

other important classes include:
LevierFactory:   would creates the "Levier" applicable for given ITaxable(OrderLine).
Levier:          encapsulates a list of "Taxer"
Taxer:           