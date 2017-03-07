@ECHO OFF
del /F /Q coverage
..\..\..\packages\ReportGenerator.2.5.5\tools\reportgenerator.exe -reports:results.xml -targetdir:coverage
EXIT