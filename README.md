Task: Compare electricity tariffs.

This service processes the user input and do the appropriate calculations depending on the tariff type.

The service can be accessed using this web url: http://13.60.97.207/swagger/index.html

In case you want to run the repository on your local computer, you must first clone this github repository. After successfully cloning the repository you can run the project in two ways:
1- You must have Visual Studio and Docker Desktop running.
   Open the visual studio solution and run the project using the docker option and after the container is successfully started you can open http:localhost:8080/swagger/index.html
2- You must have Docker running on your computer and run the project using Command Prompt by executing the following commands:
  - Open Command Prompt
  - Go to the path where you cloned the project inside TariffComparision.API folder Command: cd .../TariffComparision.API
  - Command: docker build -f "AwsDockerfile" --force-rm -t tariff-comparison .
  - Command: docker run -d -p 80:80 -e ASPNETCORE_URLS=http://+:80 --name tariff-comparison-api tariff-comparison
  - Open browser http:localhost:80/swagger/index.html
   
