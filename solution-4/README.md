# "Project Tye to Tie Micro-services" (Solution #4)

This repository contains a solution demonstrated on .NET fwdays'21 conference on 2021-08-07. This solution demonstrates how Tye can be used to run a simple services backed up with image based redis storage.

Here is repository structure:

1. `api` - a weather forecast service. This service generates a dummy weather information and caches it in `redis` for 5 seconds.
4. `request.http` - contains predefined requests for testing the application. These requests can be executed by (REST Client)[https://github.com/Huachao/vscode-restclient] for Visual Studio Code.

Here is a demo scenario:

1. Take a look at `tye.yaml`. Pay attention to `image` and `redis` configuration.
2. Take a look at `api/Startup.cs`. Pay attention to usage of Tye extension method for configuration of `redis`.
3. Execute `tye run` command. Open (Project Tye Extension)[https://github.com/Microsoft/vscode-tye/].
4. Execute request to `api`. Repeat a few times to demonstrate that request is cached.
5. CTRL + C. Stop `tye` execution.