# Use SDK image to build solution
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build-env

ARG RID=linux-x64

# mongo db url for tests
ARG CI_MONGO_DB=ci_url

ENV OSDR_MONGO_DB=$CI_MONGO_DB

WORKDIR /build

COPY Leanda.Microscopy/Leanda.Microscopy.csproj Leanda.Microscopy/
COPY Leanda.Categories/Leanda.CategoryTree.csproj Leanda.Categories/
COPY Sds.Osdr.Chemicals/Sds.Osdr.Chemicals.csproj Sds.Osdr.Chemicals/
COPY Sds.Osdr.Crystals/Sds.Osdr.Crystals.csproj Sds.Osdr.Crystals/
COPY Sds.Osdr.Domain/Sds.Osdr.Domain.csproj Sds.Osdr.Domain/
COPY Sds.Osdr.Generic/Sds.Osdr.Generic.csproj Sds.Osdr.Generic/
COPY Sds.Osdr.Image/Sds.Osdr.Images.csproj Sds.Osdr.Image/
COPY Sds.Osdr.Infrastructure/Sds.Osdr.Infrastructure.csproj Sds.Osdr.Infrastructure/
COPY Sds.Osdr.MachineLearning/Sds.Osdr.MachineLearning.csproj Sds.Osdr.MachineLearning/
COPY Sds.Osdr.Office/Sds.Osdr.Office.csproj Sds.Osdr.Office/
COPY Sds.Osdr.Pdf/Sds.Osdr.Pdf.csproj Sds.Osdr.Pdf/
COPY Sds.Osdr.Reactions/Sds.Osdr.Reactions.csproj Sds.Osdr.Reactions/
COPY Sds.Osdr.RecordsFile/Sds.Osdr.RecordsFile.csproj Sds.Osdr.RecordsFile/
COPY Sds.Osdr.Spectra/Sds.Osdr.Spectra.csproj Sds.Osdr.Spectra/
COPY Sds.Osdr.Tabular/Sds.Osdr.Tabular.csproj Sds.Osdr.Tabular/
COPY Sds.Osdr.WebPage/Sds.Osdr.WebPage.csproj Sds.Osdr.WebPage/
COPY Sds.Osdr.WebApi/Sds.Osdr.WebApi.csproj Sds.Osdr.WebApi/
COPY Nuget.config .

RUN dotnet restore --configfile Nuget.config Sds.Osdr.WebApi/Sds.Osdr.WebApi.csproj

COPY Leanda.Microscopy Leanda.Microscopy
COPY Leanda.Categories Leanda.Categories
COPY Sds.Osdr.Chemicals Sds.Osdr.Chemicals
COPY Sds.Osdr.Crystals Sds.Osdr.Crystals
COPY Sds.Osdr.Domain Sds.Osdr.Domain
COPY Sds.Osdr.Generic Sds.Osdr.Generic
COPY Sds.Osdr.Image Sds.Osdr.Image
COPY Sds.Osdr.Infrastructure Sds.Osdr.Infrastructure
COPY Sds.Osdr.MachineLearning Sds.Osdr.MachineLearning
COPY Sds.Osdr.Office Sds.Osdr.Office
COPY Sds.Osdr.Pdf Sds.Osdr.Pdf
COPY Sds.Osdr.Reactions Sds.Osdr.Reactions
COPY Sds.Osdr.RecordsFile Sds.Osdr.RecordsFile
COPY Sds.Osdr.Spectra Sds.Osdr.Spectra
COPY Sds.Osdr.Tabular Sds.Osdr.Tabular
COPY Sds.Osdr.WebPage Sds.Osdr.WebPage
COPY Sds.Osdr.WebApi Sds.Osdr.WebApi

RUN dotnet publish Sds.Osdr.WebApi/Sds.Osdr.WebApi.csproj -r $RID -c Release -o /dist

# Build runtime image
FROM mcr.microsoft.com/dotnet/runtime-deps:3.1

LABEL maintainer="rick.zakharov@gmail.com"

WORKDIR /app

RUN apt-get update && apt-get install -y curl
RUN curl https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh > /app/wait-for-it.sh && chmod 777 /app/wait-for-it.sh

COPY --from=build-env /dist ./

ENV ASPNETCORE_URLS http://+:18006
EXPOSE 18006

ENTRYPOINT ["./Sds.Osdr.WebApi"]

