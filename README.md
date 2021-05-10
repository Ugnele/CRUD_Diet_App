# CRUD_Diet_App
THE APP
An implemented web app is a basic app for users to share their recipes on the internet. The app is based on CRUD (Create, Read, Update and Delete) principle, hence it is possible to Create (and Update and Delete) new user account and also View details of a particular user. Same actions may be performed with the recipes too.  
The app has a home/about page from which user is able to navigate through Recipes and user – Our Community pages.
Home page:
![Alt text](https://user-images.githubusercontent.com/46765375/117595699-6921b100-b139-11eb-875e-1ff5467fa5cc.png)
Our Community- User page:
![Alt text](https://user-images.githubusercontent.com/46765375/117595700-69ba4780-b139-11eb-9294-65d25565d4f6.png)
Details of user:
![Alt text](https://user-images.githubusercontent.com/46765375/117595694-67f08400-b139-11eb-8832-942a887d7033.png)
Recipe page:
![Alt text](https://user-images.githubusercontent.com/46765375/117595692-6626c080-b139-11eb-9b4a-14aa7cabb47f.png)
Details of recipe:
![Alt text](https://user-images.githubusercontent.com/46765375/117595693-6757ed80-b139-11eb-9c5c-17e2cb860ea4.png)

PLANNING OF THE DEVELOPMENT

To plan the development process of the app, I have chosen to use Azure DevOps tool. I have created a board with epics, user storied and tasks, and connected it with the CRUD_Diet_APP github repository. Here is the link for the Azure DevOps project: 
https://dev.azure.com/ugnesarakauskaite/CRUD_Diet_App/ 

DATABASES

This app concentrates on relation between users of the app and recipes they upload. Thus, two data tables were used for the creation of the project: users (containing Id (primary key), Username, Password, Age, About, and PictureUrl) and recipes (Id (primary key), Title, Method, Ingredients, PictureUrl, Type and CreatedById (foreign key)).

Recipe data table:
![Alt text](https://user-images.githubusercontent.com/46765375/117595697-68891a80-b139-11eb-8787-6c6390cd405e.png)

User data table
![Alt text](https://user-images.githubusercontent.com/46765375/117596452-527c5980-b13b-11eb-9c53-1b261be33282.png)

DESIGN PATTERNS 

For the design of the code, I have implemented and MVC (Model, View, Controller) principle, which ensures decoupling of the system. App has three main controllers: Home, User and Recipe. Home controller is responsible for homepage view. Similarly, User/Recipe controller is responsible for user view and actions related to user/recipe: creating, updating and deleting user account, and displaying information about the user/recipe. Each action in a controller corresponds to a view and hence provides the logic behind it. 

TESTING

To ensure the correct functionality of the code I have used xUnit Testing framework. First of all, I have written simple tests to verify classes in ‘Utility’ folder. 
Nonetheless, I had to use a slightly different approach to test controllers. While testing, the actual database should remain unmodified, hence I had to utilise the so-called mocking objects, who allow to mock the data. Then, the applicationdbcontext should not be passed in as a class, but rather as an abstract implementation.
Here, a Repository Pattern, an interface that implements the database is introduced. First, it allows to create an abstract implementation of the database, and also to test the data.

So, first I have created a contract that specifies the actions intended to perform on data (FindAll – to retrieve information about all users/recipes, FindByCondition – to retrieve information about one particular user/recipe, Create, Update and Delete). Later, a ‘Repository Wrapper’ class is created which allows the replacement of ApplicationdbContext. Now, using mock objects I was able to test the functionality of my controllers.

Below you can see auto generated test coverage report:

![Alt text](https://user-images.githubusercontent.com/46765375/117595696-68891a80-b139-11eb-97e3-d102f4c7ec9b.png)

SELF-REFLECTION

Programming is essentially continuous problem solving. Hence, as a nature of it, I had quite a few issues to overcome while developing the app. 
First, during my next project, or if needed to further develop my app, I would like to properly use TDD principle. I believe that writing tests before actual code would improve the efficiency of my work as well as assure the correct functionality about each feature that is needed to be implemented. In addition to this, I believe that more accurate controller tests would need to be written in a future.
Secondly, timing was a huge factor during the short period that was assigned for the creation of the project. I sincerely wish I had more time to spend on front-end side of the app and ‘dig’ deeper into Angular, or even to research into each topic that was needed for the completion of the project. 
Although, the practice to debug helped a lot while overcoming various functionality problems, it was not always the case. For example, while performing integration testing, I have come across the bug in ‘CreateRecipe’ method in ‘UserController’. Although it seemed to be working before, now the method looks as if it was creating a loop situation between the two databases and hence failed to execute. On top of debugging, I have also tried to apply the technique showed during the training and utilise the ‘ViewModel’ classes. However, I did not manage to fix the bug, and hence this should be noted and left as a future goal. 
Moreover, I have learned that a branch on git repository should correspond to the task on a Kanban board (in my case- Azure DevOps board) rather than a user story. This is also important to note and use this practice for any future developments. 
FUrther, the app needs some refactoring to be performed. For example, Recipe object now its configured so that it has an object of a User, which is unnecessary and may be the actual cause for the 'looping situation' described above. Thus, User object should be replaced with the id of existent user.
 
RISK ASSESMENT
![Alt text](https://user-images.githubusercontent.com/46765375/117596839-2e6d4800-b13c-11eb-973b-479019aaa754.png)
