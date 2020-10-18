sc delete WorkerWS
SC.EXE CREATE Cornea.AirlinePortal.LogReceiver start=delayed-auto binPath="D:\kubra\worker-windows-service\WorkerWS\bin\Debug\netcoreapp3.1\WorkerWS.exe" obj="NT AUTHORITY\LocalService" password= ""
sc start WorkerWS
@PAUSE