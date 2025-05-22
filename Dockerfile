ARG NET_SDK_VERSION=9.0

FROM mcr.microsoft.com/dotnet/sdk:${NET_SDK_VERSION}

WORKDIR /src
COPY . .

CMD [ "sh", "-c", "bash" ]