# ItemShopAgentWeb
This is a master Project developing a multi-agent systems using a C# .net framework 4.5 and implement the concept of Foundation of Intelligent physical Agent (FIPA)

The project is an ASP.Net implemented on visual studio 2012 and database is implemented on SQL Server 2012

The solution has two projects

1.A windows application which shows the communication between agents

2.An asp.net project which has two folders called:

  a. Model which is the system
  b. Pages which is the interface

Install and run the project

1.Go to folder DB. There is a file Called "Query" open it in SQL Server and execute it.

2.Open The project on visual studio.

3.The project called "AgentLogApp", open AgentLogWindow form.

4.In AgentLogWindow go to the code behind, there is a variable called "agentLogPath" change the path to the current path on hard disk
like
from
"C:\Users\waleed\Documents\Visual Studio 2012\Projects\ItemShopAgentWeb\ItemShopAgentWeb\AgentWatchLog"
to
" your path on disk\ItemShopAgentWeb\ItemShopAgentWeb\AgentWatchLog"

3. Press CTRL+F5 to run the project, another screen will open will show the conversation between agents.
