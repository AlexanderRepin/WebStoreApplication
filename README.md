Web Store Application Documentation:

1.	Contains 2 Main Web pages, others have no function.

  a.	Produce: 
  
    i.	View current available products
    ii.	Display detail information for each individual product.
    iii.	Create a brand-new product.
    iv.	Checkout link at the bottom providing direct access to shopping cart.
    
  b.	Order:
  
    i.	Display Shopping list (initially empty)
    ii.	View contents of each order that includes OrderID, OrderName, Quantity, Price

2.	Resources/Packages/Libraries used

  a.	Visual Studio 2015
  
    i.	AutoMapper 4.1.1(Later versions change the mapping format)
    ii.	Biggy(JSON)
    iii.	Entity Framework
    iv.	JQuery Ajax(HTTP POST forms)

3.	Main files used

  a.	Models
  
    i.	ProduceOrderModel
    
  b.	Controllers
  
    i.	Manager
    ii.	ProduceController
    iii.	Produce_VM(view model)
    iv.	OrderController
    v.	Order_VM(view model)
  
  c.	Views
  
    i.	Order
      1.	AddToCart
      2.	Index
      
    ii.	Produce
      1.	Create
      2.	Details
      3.	Index
      
4.	Final Thoughts

  a.	Overall, an interesting project that providing a lengthy challenge for POST forms since Razor would not allow ActionLink to pass a POST method after clicking “Add to Cart”. Spent hours experimenting and looking up various other methods before moving on to Ajax. Models and Controllers especially the getters and setters with research/refresher was not a problem. Some other features I would have wanted to add were a second part of a checkout system that included a payment system.
