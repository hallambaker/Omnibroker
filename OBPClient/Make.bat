@echo off
SETLOCAL
cd %~dp0

CommandParse OBPClient.cli /lazy

exit /b 0
