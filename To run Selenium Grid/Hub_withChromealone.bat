START java -jar selenium-server-standalone-2.44.0.jar -port 4444 -role hub -newSessionWaitTimeout 25000
START java -jar selenium-server-standalone-2.44.0.jar -port 4445 -role node -hub http://localhost:4444/grid/register -browser browserName=chrome,maxInstances=5 -Dwebdriver.chrome.driver=chromedriver.exe
START java -jar selenium-server-standalone-2.44.0.jar -port 4446 -role node -hub http://localhost:4444/grid/register -browser browserName=chrome,maxInstances=5 -Dwebdriver.chrome.driver=chromedriver.exe
