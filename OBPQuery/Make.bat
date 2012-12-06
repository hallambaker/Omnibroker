@echo off
SETLOCAL
cd %~dp0

CommandParse OBPQuery.cli /lazy

exit /b 0