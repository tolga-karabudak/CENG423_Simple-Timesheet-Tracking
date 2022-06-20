FROM mcr.microsoft.com/mssql/server

# Switch to root user for access to apt-get install
USER root

RUN apt-get -y update  && \
        apt-get install -y curl && \
        apt-get install -y dos2unix


# Create init_db directory

RUN mkdir -p /usr/init_db/init-sql-scripts
WORKDIR /usr/init_db
COPY *.sh /usr/init_db/
COPY init-sql-scripts/*.sql /usr/init_db/init-sql-scripts/

# Grant permissions for the import-data script to be executable
RUN dos2unix /usr/init_db/*
RUN dos2unix /usr/init_db/init-sql-scripts/*

RUN chmod +x /usr/init_db/entrypoint.sh
RUN chmod +x /usr/init_db/import-data.sh

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=Timesheet2022
# Switch back to mssql user and run the entrypoint script
USER mssql
ENTRYPOINT /bin/bash /usr/init_db/entrypoint.sh
