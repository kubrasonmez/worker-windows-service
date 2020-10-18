# worker-windows-service
.Net core worker service as windows service

# Getting started
Edit Scripts/Install.bat file, change binPath with your worker service exe path.
Run install.bat

sc delete WorkerWS
SC.EXE CREATE WorkerWS start=delayed-auto binPath="‪C:\publish\WorkerWS.exe" obj=LocalSystem password= ""
sc start WorkerWS
@PAUSE
