# Online Store - A C# MVC4 Application that connects to SQL Server.
### Also uses jQuery, Knockoutjs and JavaScript

This project is an online photography store. As a new developer, this is the most complex project I have done to date. Thus, if you see anything that may be incorrect please do not hesitate to reach out. I've design this online store to mimic enterprise level applications. By having additional layers, there's more security and loosely coupled features that allow you to fix/change pieces without completely breaking the application.  

### Learning Insights
While building this project I learned some valuable insight into building and designing a C# program. I believe it's crucial to have these tips in the forefront of your mind if you attempt to replicate or build a store similar to this one. If you're an expert in C# or OOP (Object Oriented Programming) please feel free to skip this section. 

1. The first rule I think is important is single responsibility code. Make sure your code doesn't make more than one job. This helps with testing and your fellow developers understand what the code is doing. Single responsibility code is cleaner and easier to maintain. 
2. Organizing your code into projects and libraries. By separating your code into different projects within the application, you'll easily pinpoint what is happening in each layer of your project. This helps to decouple your code so that minor changes will not break the entire project. This project is design to emulate an enterprise level application. There are multiple layers for security and functionality. 
3. Understanding the flow of the application and the corresponding responsibilties. Each layer of this application has a responsiblity. One layer will interact with the Database, another will work with the business logic, another with the view and so on. Understanding the flow between the layers will help you understand what is happen and help with debugging. 
4. The object factory is probably still the hardest concept for me to wrap my mind around. Every object in this application comes from the object factory. The object factory creates the object and the object's interface. The Object registration makes sure that when an object is created it a name and an interface to go with it. And if it is not implemented yet, it will throw an error to remind you to build out this functionality at a later date. The Products in the store use this, every transaction/purhcase uses this, and even the state taxes uses the object factory. If it has properties (and/or methods), it will be created by the object factory. 

### Application Architechure/Flow
This project is an MVC (Model-View-Controller) design that connects to SQL server. It has three distinct layers, and additional layers within it to comply with the enterprise format. The three overarching layers are:
1. Client - composed of the View, the Controller, the View Models, and the View Model Controller (VMCs)
* The View is what is displayed in the browser to the user
* The Controller decides what is shown based on the actions and the URL
* The View Models or VMs are the shape of the objects being displayed. 
2. Business - composed of Entities or POCOs (Plain Old C# Object), and Business Logic, and the Object factory.
* The entities are the shape of the objects being use in this program and the shape the objects will be in the database.
* The business logic is any logic assigned from the business. This can be arbitrary rules, taxes etc.
* The object factory simply creates objects(and their interfaces) to be formed in whatever context they are needed. This is an abstract idea, but it allows the rest of the application to function and pass data to the user from the database and vice versa. 
3. Data - composed of the Data Access Layer and the Database
* The data access layer is the connection to the database. It provides the connection and the commands. It also manipulates the data so that it will comply with SQL commands and terminology. 
* The database includes the tables we need to keep inventory, customer orders and tax information. The data base also has stored procedures created to execute orders and their corresponding tax needs. 




