#!/bin/bash

# Aguarda até que o SQL Server esteja pronto para aceitar conexões
until /opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 'Pass@w0rd' -Q 'SELECT 1'; do
  echo 'waiting for sql server to start...'
  sleep 1
done

# Executa o script SQL
/opt/mssql-tools/bin/sqlcmd -S sql-server -U sa -P 'Pass@w0rd' -i /tmp/createdatabase.sql
