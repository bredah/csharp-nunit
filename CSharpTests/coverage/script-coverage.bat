@ECHO OFF
..\..\..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe -target:script-tests.bat -register:user -filter:+[*]* 
EXIT