#Permission Test
All compiled code can be found under the publish directory.

The executables cover two simple tests:
- If communicating using named pipe is allowed. Most probably this test will succeed as we saw commands working with the container engine. A second version of this test is comming, directly instructing the container engine to start a module
- If communicating using unix domain socket is working. The 'check' script gets frozen when this test is running.

To execute the test:
1) run PipeServer.exe from command line
2) run PipeClient.exe from a different command line

Please try the account which runs the container engine/edge service

3) run UdsServer.exe
4) run UdsClient.exe
