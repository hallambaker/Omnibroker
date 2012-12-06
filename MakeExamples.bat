

echo Make the Connection Protocol
ProtoGen Omnibroker\OBP-Connection.protocol OBP-Connection.xml

echo Make the Query Protocol
ProtoGen Omnibroker\OBP-Query.protocol  OBP-Query.xml

HTML2RFC omnibroker.xml draft-hallambaker-omnibroker-04.xml



exit /b 0