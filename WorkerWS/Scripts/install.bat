sc delete WorkerWS
SC.EXE CREATE WorkerWS start=delayed-auto binPath="‪C:\publish\WorkerWS.exe" obj=LocalSystem password= ""
sc start WorkerWS
@PAUSE