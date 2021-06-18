# "Project Tye to Tie Micro-services" (Solution #3)

This repository contains a solution demonstrated on .NET fwdays'21 conference on 2021-08-07. This solution demonstrates how Tye can be used to run, deploy & debug three micro-services: one, built from sources and other two (one from sources and one from Dockerfile) located on separate GibHub repository.

Here is repository structure:

1. `.vscode/launch.json` - contains a Docker debug configuration which can be used to debug `companion-containerized-api`. Pay attention to source mapping.
3. `source-api` - a weather forecast service which calls weather forecast API of `companion-source-api` and enriches response with city information. This service is built from sources.
4. `request.http` - contains predefined requests for testing the application. These requests can be executed by (REST Client)[https://github.com/Huachao/vscode-restclient] for Visual Studio Code.
5. `tye.yaml` - contains configuration for `tye` command tool.

Here is a demo scenario:

1. Take a look at `tye.yaml`. Pay attention to fixed ports in `bindings` (which are required to simplify demonstration by using `requests.http`). Pay attention to `repository` configuration. Pay attention that `name` in this `tye.yaml` should match `name` in referenced repository. Pay attention to ingress.
2. Take a look at `source-api/Startup.cs`. Pay attention to usage of Tye extension method for configuration.
3. Execute `tye run` command. Open (Project Tye Extension)[https://github.com/Microsoft/vscode-tye/]. Pay attention to `.tye/deps` directory. Demonstrate dashboard. Pay attention to ingress.
4. Navigate to `request.http`. Execute requests to `companion-containerized-api`, `companion-source-api` and `source-api`. Pay attention to differences. Execute requests to `companion-source-api` and `source-api` through ingress. Pay attention to `Host` configuration.
5. Use Tye extension to attach debugger to `companion-source-api`. Demonstrate that debugging works (in `WeatherForecastController`).
6. Use Visual Studio Code "Docker .NET Core Attach (Preview)" debug configuration to debug `companion-containerized-api` service.
7. Detach debuggers. CTRL+C to cancel `tye run`.
8. Execute `tye deploy -i` (specify required container registry).
9. Use `kubectl` to get services (`kubectl get service`). Pay attention that all services are deployed, including from repository.
10. Execute requests to deployed `companion-source-api` and `source-api` (from `request.http`).
11. Execute `tye undeploy`.