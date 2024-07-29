# C# UI and API Testing Setup in VS Code DevContainer

## Prerequisites

- Docker
- Visual Studio Code
- Remote - Containers extension for VS Code

## Starting the DevContainer

### 1. Clone the repository
   - Open a terminal and run:
     ```bash
     git clone https://github.com/Free1man/AutomationFramework.git
     cd AutomationFramework
     ```

### 2. Open the project in VS Code
   - Launch Visual Studio Code.
   - Select `File` > `Open Folder...` and navigate to the project directory.
   - VS Code will detect the `.devcontainer` configuration and prompt you at the bottom right to reopen in a container. Click `Reopen in Container`.

### 3. Container Setup
   - The container will start building based on the specifications in the `.devcontainer/devcontainer.json` file. This process can take a few minutes if it's the first setup or if the image needs to be rebuilt.

### 4. Start Developing
   - Once the container setup is complete, VS Code will connect to it. You are now ready to develop inside the containerized environment.

   Run test: 

   ```bash
   dotnet test AutomationFramework.sln
   ```

   Note: The tests are expected to fail  as there is no real API or UI backend implemented. This setup is meant to demonstrate the containerized environment and test configurations.

