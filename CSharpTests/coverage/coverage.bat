@echo OFF
if not "%1" == "" (
	set DLL=%1
	REM Execute code coverage
	start /wait script-coverage.bat
	REM Create a code coverage report
	start /wait script-report.bat
) else (
	REM Please, inform the DLL. Example:
	REM covarega.bat example.dll
)