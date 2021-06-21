# "Project Tye to Tie Micro-services" (Solution #2)

Solution demonstrated how `tye` can be used to run, deploy & debug solution of two microservices, when one service is built from C# source files and another one is built from Dockerfile.

## Content

The solution contains:

* **.vscode/launch.json** - launch configuration for Docker container debugging (used in demo to debug `companion-containerized-api` service).
* **companion-containerized-api** - a .NET 5 service to generate random weather forecast information. 
* **companion-source-api** - a .NET 5 service which enriches weather forecast obtained from `companion-containerized-api` service city information. 
* **request.http** - a list of requests for the application (used in demo). 
* **tye.yaml** - configuration of `tye` tool.

## Details

* `companion-containerized-api` service is built from `companion-containerized-api/Dockerfile`.
* `companion-source-api` service is built from C# source code.
* Requests from `request.http` can be executed by [REST Client](https://github.com/Huachao/vscode-restclient) extension for Visual Studio Code.

## Demo

1. Take a look at `tye.yaml`. 
    * Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). 
    * Pay attention to `containerPort` configuration.
3. Take a look at `companion-source-api/Startup.cs`. 
    * Pay attention to usage of Tye extension method for configuration.
5. Execute `tye run` command. 
6. Open [Project Tye Extension](https://github.com/Microsoft/vscode-tye/). 
7. Navigate and demonstrate dashboard
    * Pay attention to `Project` vs `Container`.
    * Pay attention to bindings.
9. Open to `request.http`. 
    * Execute request to `companion-containerized-api`. 
    * Execute request to `companion-source-api`. 
    * Pay attention to differences.
11. Use Tye extension to attach debugger to `companion-source-api`. 
    * Pay attention that currently there is no built in way to attach debugger to container. 
    * Verify debugger works (in `WeatherForecastController`).
    * Use Visual Studio Code "Docker .NET Core Attach (Preview)" debug configuration to debug `companion-containerized-api` service.
    * Detach debuggers. 
    * CTRL+C to cancel `tye run`.
15. Execute `tye deploy -i` (specify required container registry).
16. Use `kubectl` to
    * Get services (`kubectl get service`)
    * Establish port forwarding for `companion-source-api` (`kubectl port-forward svc/companion-source-api 8800:8800`).
18. Open to `request.http` and execute request to `companion-containerized-api`.
19. Execute `tye undeploy`.
