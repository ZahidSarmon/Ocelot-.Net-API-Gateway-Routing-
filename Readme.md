## Ocelot API Gateway with .Net 6

first of all create ssl certificate with **dotnet dev-certs https --trust**

Here create two web api project one is **Api.Order** and other is **Api.Product**

and there are some endpoints like 

**/api/Product**

**/api/Product/1**

**/api/Order**

**/api/Order/1**


and then create **Api.Gateway** web api project for configure **Ocelot**

here the dotnet cli for add Ocelot nuget

**dotnet add package Ocelot**

and then register the Ocelot and add Ocelot to the middleware of the service.
Create  a json like **Ocelot.json** and register the json.

after that Run the **Api.Gateway** with this host and port and check the Upstream path.