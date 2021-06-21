# "Project Tye to Tie Micro-services" (Solution #3)

Solution demonstrates how `tye` can be used to run, deploy & debug three micro-services spread across two Git repositories - one, built from C# sources in the first repository and two (one from C# sources and one from Dockerfile) in the second repository.

Solution demonstrates two scenarios:

1. When `companion-*` services are treated as part of the same solution as `source-api` service. So run & deployment are acting on these services as whole.
2. When `companion-*` services are treated as external services from different solution. So run & deployment are acting on these services as they should already exist.

## Content

The solution contains:

* **.vscode/launch.json** - launch configuration for Docker container debugging (used in demo to debug `companion-containerized-api` service).
* **companion-containerized-api** - a .NET 5 service to generate random weather forecast information. 
* **companion-source-api** - a .NET 5 service which enriches weather forecast obtained from `companion-containerized-api` service with source information. 
* **source-api**  - a .NET 5 service which enriches weather forecast obtained from `companion-source-api` service with city information. 
* **request.http** - a list of requests for the application (used in demo). 
* **tye.yaml** - configuration of `tye` tool to consume `companion-containerized-api` and `companion-source-api` services as services from the same solution located in separate repository.
* **tye-external.yaml** - configuration of `tye` tool to consume `companion-containerized-api` and `companion-source-api` services as external services from the different solution, deployed separately.

## Demo (Scenario 1)

1. Take a look at `tye.yaml`. 
    * Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). 
    * Pay attention to `repository` configuration of `companion-source-api`. 
    * Pay attention to `name` configuration. Demonstrate it matches name in `tye.yaml` of companion solution.
    * Pay attention to ingress configuration. Describe how it works in `tye run` and `tye deploy`.
2. Take a look at `source-api/Startup.cs`. 
    * Pay attention to usage of `tye` configuration extension method.
3. Execute `tye run` command. 
    * Pay attention to newly created `.tye/deps` directory. Demonstrate it contains sources of companion solutions.
4. Open [Project Tye Extension](https://github.com/Microsoft/vscode-tye/). 
5. Navigate and demonstrate dashboard
    * Pay attention to ingress.
6. Open `request.http`. 
    * Execute request to `companion-containerized-api`.
    * Execute request to `companion-source-api`.
    * Execute request to `source-api`.
    * Pay attention to differences.
    * Execute request to `companion-source-api` through ingress.
    * Execute request to `source-api` through ingress. 
    * Pay attention to `Host` configuration.
7. Use **Tye Extension** to attach debugger to `companion-source-api`. 
    * Verify debugger works (in `WeatherForecastController`).
    * Use Visual Studio Code "Docker .NET Core Attach (Preview)" debug configuration to debug `companion-containerized-api` service.
    * Detach debuggers. 
    * CTRL+C to cancel `tye run`.
8. Execute `tye deploy -i` (specify required container registry).
9. Use `kubectl` to 
    * View services 
        * `kubectl get service`. 
        * Pay attention that all services are deployed, including `companion-*` services.
10. Open `request.http`. 
    * Execute request to deployed `companion-source-api`.
    * Execute request to deployed `source-api`.
11. Execute `tye undeploy`.

## Demo (Scenario 2)

Before executing this scenario it is required to have [companion solution](https://github.com/coherentsolutionsinc/dotnet-fwdays-2021-project-tye-to-tie-dotnet-microservices-companion) deployed to same Kubernetes cluster. Please use instructions in repository to do this.

1. Take a look at `tye-external.yaml`. 
    * Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). 
    * Pay attention to `external` configuration of `companion-source-api`. 
    * Pay attention to `external/bindings` configuration of `companion-source-api`.
    * Pay attention to `name` configuration. Demonstrate it doesn't match name in `tye.yaml` of companion solution.
    * Pay attention to ingress configuration. Describe how it works in `tye run` and `tye deploy`.
2. Take a look at `source-api/Startup.cs`. 
    * Pay attention to usage of `tye` configuration extension method.
3. Execute `tye run tye-external.yaml` command. 
4. Open [Project Tye Extension](https://github.com/Microsoft/vscode-tye/). 
5. Navigate and demonstrate dashboard
    * Pay attention to ingress.
    * Pay attention to External service.
6. Open `request.http`. 
    * Execute request to `companion-source-api` through ingress.
    * Execute request to `source-api` through ingress. 
7. CTRL+C to cancel `tye run`.
8. Execute `tye deploy tye-external.yaml -i`
    * Specify required container registry.
    * Specify required secret - put `http://companion-source-api:8800` value. Describe the value.
9. Open `request.http`. 
    * Execute request to deployed `source-api`.
10. Execute `tye undeploy tye-external.yaml`.
