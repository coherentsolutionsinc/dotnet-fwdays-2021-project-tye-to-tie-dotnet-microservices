# "Project Tye to Tie Micro-services" (Solution #4)

Solution demonstrates how `tye` can be used to run a service backed up with image based redis storage.

## Content

The repository contains:

* **api** - a .NET 5 service to generate random weather forecast information and cache it in `redis` for 5 seconds.
* **request.http** - a list of requests for the application (used in demo). 

## Prerequisites

Please ensure to install:

* [REST Client](https://github.com/Huachao/vscode-restclient) extension for Visual Studio Code.
* [Project Tye](https://github.com/dotnet/tye) is installed and getting started [tutorial](https://github.com/dotnet/tye/blob/main/docs/tutorials/hello-tye/00_run_locally.md) is finished.

## Demo

1. Take a look at `tye.yaml`. 
    * Pay attention to `image` and `redis` configuration.
3. Take a look at `api/Startup.cs`. 
    * Pay attention to usage of `tye` configuration extension method to configure `redis`.
5. Execute `tye run` command.
6. Open to `request.http` and execute request to `api` several times to ensure result is indeed cached.
8. CTRL + C to cancel `tye run`.
