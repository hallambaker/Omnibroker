@echo off
SETLOCAL

cd %~dp0
CommandParse OBPConnect.cli  /lazy

exit /b 0