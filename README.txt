---------------------------Build--------------------------------------------------------
the solution is built via Visual Studio 2008, using .net 3.5 framework.

click build.cmd to build it, before doing that, 
1,ensure Ruby 1.9.2 is installed.
2,ensure albocore 0.2.2 is installed, you can click installGem.bat to install it.

---------------------------projects introduction--------------------------------------------------------
there are mainly 4 project in the solution:
1,SalesTaxes.Core                 --contains all domain classes.
2,SalesTaxes.View                 --contains classes which are responsible for "Printing" the Sales Order.
3,SalesTaxes.AcceptanceTest       --implement the given three examples as integration tests.
4.SalesTaxes.UnitTest             --all unit tests.

---------------------------Main classes introduction-----------------------------------------------------
main classes in SalesTaxes.Core are(from inside out):
1,ProductDescriptor: encapsulates "name", "category" and "applicable units" of the product.
2,PurchaseItem:      encapsulates "ProductDescriptor", "purchase unit" and "IsImported"
3,Product:           encapsulates "PurchaseItem", "Sale unit", "Price". implementing IProduct interface.
4,OrderLine:         encapsulates "IProduct", "Quantity". implementing ITaxable interface and need ITaxService to calculate the tax.
5,SalesOrder:        encapsulates a list of "OrderLine".

other important classes include:
LevierFactory:   would creates the "Levier"(list of TaxItem) applicable for given ITaxable(OrderLine).
Levier:          encapsulates a list of "TaxItem"
TaxItem:         would calculate the Tax of the given Amount based on the tax rate and the given taxRounder.

---------------------------NOTE--------------------------------------------------------------------------
1, my understanding of the diffrence between "a box of imported chocolates" and "a imported box of chocolates" is:
 a box of imported chocolates: this chocolates' Sale Unit is "box", Purchase Unit is "default/unknown"
 a imported box of chocolates: this chocolates' Purchase Unit is "box", Sale Unit is the same with Purchase Unit, thus being omited here.
that's why I model "Purchase Unit" and "Sale Unit" in the classes.