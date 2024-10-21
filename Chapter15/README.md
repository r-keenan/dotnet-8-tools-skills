# How to build a Docker image and container from this project

CD into the root of the project directory where the Dockerfile is
_Build Docker image_

```bash
docker build -t aboutmyenvironment-image -f Dockerfile .
```

_Build Docker container with name "ame"_

```bash
docker create --name ame aboutmyenvironment-image
```

_List Docker containers_

```bash
docker ps -a
```

_Start Docker image with name of "ame"_
This will create a random name for the container

```bash
docker start ame -ai
```

_Start Docker container with a fixed name_

```bash
docker run -it --rm aboutmyenvironment-image
```
