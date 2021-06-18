# "Project Tye to Tie Micro-services" (Solution #1)

This repository contains a solution demonstrated on .NET fwdays'21 conference on 2021-08-07. This solution demonstrates how Tye can be used to run, deploy & debug simple micro-services directly from the source code.

Here is repository structure:

1. `api` - a weather forecast service. This service generates a dummy weather information.
2. `source-api` - a weather forecast service which calls weather forecast API of `api` and enriches response with city information. 
4. `request.http` - contains predefined requests for testing the application. These requests can be executed by (REST Client)[https://github.com/Huachao/vscode-restclient] for Visual Studio Code.

Here is a demo scenario:

2. Take a look at `source-api/Startup.cs`. Pay attention to usage of Tye extension method for configuration of `WeatherClient`.
3. Execute `tye run` command. Open (Project Tye Extension)[https://github.com/Microsoft/vscode-tye/]. Demonstrate dashboard, pay attention to bindings, pay attention to logs.
4. Copy `api` URL and navigate to `request.http`. Execute request to `api`. Repeat for `source-api`. Pay attention to differences.
5. Use Tye extension to attach debugger to `source-api` and `api`. Pay attention on how easy it is to do. Demonstrate that debugging works (in `WeatherForecastController`).
7. Detach debuggers. CTRL+C to cancel `tye run`.
8. Execute `tye deploy -i` (specify required container registry).
1. Pay attention to absence of `Dockerfile` and Kubernetes `.yaml`
9. Use `kubectl` to get services (`kubectl get service`) and port forward `source-api` port to 8800 port (`kubectl port-forward svc/source-api 5000:8800`).
10. Execute request to `source-api` (from `request.http`).
11. Execute `tye undeploy`.