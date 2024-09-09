# CI/CD Pipeline with GitHub Actions

This repository demonstrates a CI/CD pipeline using GitHub Actions. The pipeline automates the process of building, testing, and deploying the application.

## Table of Contents
- [Overview](#overview)
- [Workflow](#workflow)
- [Setup](#setup)
- [Usage](#usage)
- [Contributing](#contributing)
- [License](#license)

## Overview
This project uses GitHub Actions to implement a CI/CD pipeline. The pipeline includes the following stages:
1. **Build**: Compiles the application.
2. **Test**: Runs unit tests to ensure code quality.
3. **Deploy**: Deploys the application to the test environment.

## Workflow
The CI/CD workflow is defined in the `.github/workflows/build_and_test.yml` file. Below is a summary of the workflow:

```yaml
name: Build and Test

on:
    push:
        branches: ["master"]

jobs:
    build-test:  
        runs-on: ubuntu-latest

        steps:
        - name: Checkout code on master
          uses: actions/checkout@v4
        - name: Setup .Net
          uses: actions/setup-dotnet@v4
          with:
            dotnet-version: 8.0.x
        - name: Restore app dependencies
          run: dotnet restore
        - name: Build Project
          run: dotnet build --no-restore
        - name: Check PWD
          run: pwd
        - name: List PWD
          run: ls -al
        - name: Run unit Tests
          run: dotnet test --no-restore -v normal
    deploy:
      runs-on: ubuntu-latest
      needs: build-test
      
      steps:
        - uses: actions/checkout@v2
        - uses: akhileshns/heroku-deploy@v3.12.12
          with:
            heroku_api_key: ${{secrets.HEROKU_API_KEY}}
            heroku_app_name: ${{secrets.HEROKU_APP_NAME}}
            heroku_email: ${{secrets.HEROKU_EMAIL}}
            usedocker: true
```

## Setup
To set up the CI/CD pipeline, follow these steps:

1. **Clone the repository**:
    ```sh
    git clone https://github.com/alexovonathan22/rpni.bankapp.api.git
    cd rpni.bankapp.api
    ```

2. **Create the workflow file**:
    Created a `.github/workflows/build_and_test.yml` file and added the workflow definition provided above.

3. **Configure secrets**:
    Added necessary secrets (e.g., api key) to this GitHub repository under **Settings > Secrets** as seen in yaml file above.

## Usage
To trigger the CI/CD pipeline, push changes to the `master` branch. The pipeline will automatically run the build-test, and deploy stages.
