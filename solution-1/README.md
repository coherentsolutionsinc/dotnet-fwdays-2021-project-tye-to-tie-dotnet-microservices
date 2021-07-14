# "Project Tye to Tie Micro-services" (Solution #1)

Solution demonstrated how `tye` can be used to run, deploy & debug a solution of two micro-services built from the source code.

## Content

This solution contains:

* **api** - a .NET 5 service to generate random weather forecast information.
* **source-api** - a .NET 5 service which enriches weather forecast obtained from `api` service with city information.
* **request.http** - a list of requests for the application (used in demo). 

## Details

* `api` and `source-api` services are built from `api/api.csproj` and `source-api/source-api.csproj` respectively.

## Prerequisites

Please ensure to install:

* [REST Client](https://github.com/Huachao/vscode-restclient) extension for Visual Studio Code.

> Developer's comment 
>
> This is required to execute requests from `request.http` file.

* [Project Tye](https://github.com/dotnet/tye) is installed and getting started [tutorial](https://github.com/dotnet/tye/blob/main/docs/tutorials/hello-tye/00_run_locally.md) is finished.

## Demo

1. Take a look at `source-api/Startup.cs`. 
    * Pay attention to usage of tye extension method for configuration of `WeatherClient`.
2. Execute `tye run` command. 
3. Open [Project Tye Extension](https://github.com/Microsoft/vscode-tye/). 
4. Navigate and demonstrate dashboard
    * Pay attention to services bindings.
    * Pay attention to ability to view logs.
6. Copy a URL of `api` service from dashboard, paste it to `request.http` and execute it.
7. Copy a URL of `source-api` service from dashboard, paste it to `request.http` and execute it. 
8. Use Tye extension to attach debugger to `source-api` and `api`. 
    * Pay attention on how easy it is. 
    * Verify debugger works (in `WeatherForecastController`).
    * Detach debuggers. 
    * CTRL+C to cancel `tye run`.
11. Execute `tye deploy -i` (specify required container registry).
    * Pay attention to absence of `Dockerfile` and Kubernetes `.yaml`.
13. Use `kubectl` to
    * View services
        * `kubectl get service`
    * Establish port forwarding for `source-api`
        * `kubectl port-forward svc/source-api 80:8800`.
15. Open `request.http` and execute request to `source-api`.
16. Execute `tye undeploy`.
