# CarSimulator

## Project Description:
This a .Net 6 console application that simulates a simple car with a driver assigned to it. Application class is the main class which asks the use input for options and returns the response accordingly. Program class has host builder which injects services to the container and then call the Run method from Application class.

## Application Overview:
This simple car simulator applcation has one menu with following options:
1. Drive (Right, Left, Straight, Reverse): User of this application can instruct the driver to drive the car in these four directions. 
2. Take Rest: Every time driver performs any action the driver fatigue level increase by one level.This allows the use to order to order the drive to take rest. Taking rest resets the driver fatigue level to zero.
3. Refuel Tank: Every time car is driven in any direction or taken to the refuel the tank the fuel level reduces by one level. This command sets the fuel level to maximum fuel capacity.
4. Driver details: This lets the user to know the details of the driver.
5. Exit: Exits the application.


## Entities:
### Car entity:
1. Max fuel capacity: By default the maximum car tank capacity is set to 20.
2. Fuel status: This describes the current fuel level of the car. The tank is assumed full when application runs.
3. Direction: The direction of the car e.g. North, South, East, Or West. This direction is randomly generated when application runs.

### Driver entity:
1. Driver details such as name, gender, age, contact are randomly generated and fetched from an external API (https://randomuser.me/api/).
2. Driver has maximum fatigue capacity upto which driver can drive car. Drive cannot drive once this level is reached. This is set to 10 by default.
3. Fatigue level show current fatigue level of the driver. This increases with every action the user asks the driver to take.

## Services:
1. Driver Services class encapsulates all methods relevant to the driver.
2. Car services class has all relevant mehtods for handling car entity.
3. Driving services class has dependecny on above two classes and this class handles all the user commands and then call the required action using dependent services after implementing certain required checks. Each commands also show necessary messages to the console.

## Testing:
### 1- Car Simulator Tests (MS test):
This test project has all relevant tests for the car simulator application. It tests different possible test cases for entities as well as for all services. For Driving servcies Moq library is used to mock the dependencies.

### 2- Car Simulator Tests (NUnit):
A spearate project uses NUnit testing framework to test Driving Services. The dependencies are once again mocked through moq library.

### 3- Car Simulator Tests - Integration Testing (Ms Test):
Since driver is fetched from an external API so integration testing is performed to check that the response from API is valid and re-modelled according to the Driver Entity.

### 4- Car Simulator Tests v2.0 (MS Test):
We assume that the future version (v2) of this application will introduce a driver hunger variable. Every action will increase hunger level and after a certain level of hunger the application will exit. Eating command will reset the hunger level to zero again. This project tests the upcoming extension of this project so as to ensure the application runs fail-free.
