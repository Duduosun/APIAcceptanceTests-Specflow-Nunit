This Solution Contains two projects
1.APITests project
Tests in this project checks the website through the API layer.
Tests are run by sending Http requests like GET, POST and asserts their response

This project contains two sets of tests
a)Nunit tests
These test are written with Nunit framework

b)Specflow tests
These tests are written with Specflow in Cucumber(Given/When/Then) format

2.UITests project
Tests in this project checks the website through the UI layer
These are written with Selenium webdriver in Nunit framework
They can be run with Selenium Grid , wherein Selenium server acts as a hub and browser instances can act as a node.
This framework can be used to run tests in parallel.


Prerequisites for Running API Tests:
API tests can be run either through Resharper or Ncrunch or NunitRunner

Prerequisites for Running UI Tests:
-Please install Java in your local machine
-Please run the bat file available in below path
PracticalTest\To run Selenium Grid\Hub_withChromealone.bat
This will register Selenium hub with 2 nodes. Each node containing 5 instances of chrome driver will be registered to the hub.
-Please verify if the Grid and Nodes are registered correctly by checking below path
http://localhost:4444/grid/console
-Run the UI tests either with Resharper or Nunit Runner