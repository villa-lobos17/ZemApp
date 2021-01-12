# ZemApp
Repo Zemoga test Jorge Villalobos villa-lobos17@hotmail.com

### Design architecture 

For this test, the domain-oriented architecture or DDD was used, the reason for using it was the ease of being understood and being closer to the customer * it was designed not to break the head of the test reviewer * in addition to the ease of implementing unit tests , and how close it can be to solving the problem raised in the test.

![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/DDD_png_pure0.png)

they were taken into account after architectures such as clean onion and N layers.

###   Code structure
  
The code is structured in the following projects: *Client: Zemapp.Api 
* Application Layer: Zemapp.Application 
*  Domain Layer: Zemapp.Domain  
*   Infrastructure Layer: Zemapp: Infrastructure
*   The client code is structured in 2 parts in the same project, taking into account that the client code is .Net core and the view code is in the ** ClientApp ** folder

![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/client.PNG)

### Authorization 

A middleware for authentication was created using jwt and an authentication controller, the services that will communicate with the UI layer are restricted. In the case of the second point, these endpoints are not protected due to the requirements of the test.

### Test requirements

This code has been developed with .Net Core 3.1 Angular * (using the latest version of angular cli) * and MongoDB was used as data storage, the requirements to debug this code are:

* MongoDB client *Community Server Edition *  https://www.mongodb.com/try/download/community 
* Node Js 14 + https://nodejs.org/es/
* Visual studio 2017 /2019
* git-bash o vscode
* .Net core 3.1
* Angular cli - Last version https://cli.angular.io/ 

### Deployment data
  
In order to run the test, it must be opened with visual studio and compiled, if in case of an error when compiling the code in front, it would be necessary to follow the following steps: 
* go to the ZemApp.Api/ClientApp folder 
*  on that folder open a git-bash console or vscode terminal 
*   Execute the command npm install 
* Run the ng build command 
*  Try running the code again

### Test Access Data

** 
User Editor **
* Email : terminator@gmail.com
* Password : AB1234
</br>
** User Escritor **

* Email : Jhon.connor@gmail.com 
* Password : AB1234

### Development point 1
The test does not require running scripts, as soon as it starts it redirects the user to the home of the post, having the options requested in point 1

![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/App1.PNG)


### Development point 2
This test integrates swagger for the project tests by accessing the Url http://localhost:3907/swagger/index.html
![alt text](https://raw.githubusercontent.com/villa-lobos17/ZemApp/main/swa10.PNG)

The endpoint to query the pending posts is:
http://localhost:3907/api/BlogPost/query

The endpoint to update the pending posts is:
http://localhost:3907/api/BlogPost/approval


