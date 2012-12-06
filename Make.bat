@echo off
SETLOCAL
cd %~dp0

call Omnibroker\Make
call OBPConnect\Make
call OBPQuery\Make
call OBPClient\Make

exit /b 0