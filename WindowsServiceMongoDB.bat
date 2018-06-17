rem Creating & starting MongoDB service (Windows 10)
rem needs run Admin Mode !
c:
rem Verify dirs exists.
rem md c:\data\db
rem md c:\data\log

rem Create config files.
echo logpath=c:\data\log\mongod.log>> "C:\Program Files\MongoDB\Server\3.6\mongod.cfg"
echo dbpath=c:\data\db>> "C:\Program Files\MongoDB\Server\3.6\mongod.cfg"

rem Create service.
sc.exe Create MongoDB binPath="\"C:\Program Files\MongoDB\Server\3.6\bin\mongod.exe\" --service --config=\"C:\Program Files\MongoDB\Server\3.6\mongod.cfg\"" DisplayName="MongoDB" start="auto"

rem Launch MongoDB service : net start MongoDB ;

rem Test service with MongoDBCli
rem start C:\Program Files\MongoDB\Server\3.6\bin\mongo.exe

rem stop MongoDB service : net stop MongoDB ;

rem Suppr MongoDB service : sc.exe delete MongoDB. (needs service stopped)