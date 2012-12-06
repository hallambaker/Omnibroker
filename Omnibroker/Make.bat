echo Make script file
SETLOCAL

cd %~dp0
:: NB the lazy option does not work here for some reason
ProtoGen OBP-Connection.protocol /xml OBP-Connection.xml /cs Connection.cs /lazy
ProtoGen OBP-Query.protocol /xml OBP-Query.xml /cs Query.cs  /lazy 
Goedel3 Configure.gdl /cs Configure.cs /lazy
exit /b 0
