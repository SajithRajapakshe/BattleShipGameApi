# BattleShipGameApi
This application is built according to the following points as per the RQS.

1. Solution contains 2 layers (Api, Business Layer) and a separate class library as unit tests.
2. Api layer facilitates the api end points as actions inside the API controller. Routes are defined for each method.
3. A separate service has been used to facilitate the functionalities like locating ships, shoot etc.
4. To run the full application,
	1.	Download or clone the API code
	2.  Open it using visual studio 2022 (.Net core 8.0 is used)
	3.  Debug and Run the code
	4.  Swagger configuration has been done and you will see the API home page with developed api methods.
	5.  If you need to run the UI layer( uploaded separately), First the API application should be started.
5. Added customized sections for Authentication and Exception middlewares.
    1.  Api authentication middleware is disabled in the pipeline, in order to run it using the swagger, please do the correct configuration.
	2.  A hardcoded API key has been passed from UI and added in the application.json file, in case you need to check the authentication part.
6. Added  
    1.A separate Extension class for DI pipeline configurations
    2.A helper class for json conversion
    3.A separate exception class for handling API errors.
