
Create SQL Database

In function app turn on System assigned Identity

In database run:
CREATE USER [func-candidates-api] FROM EXTERNAL PROVIDER
ALTER ROLE db_datareader ADD MEMBER [func-candidates-api]
ALTER ROLE db_datawriter ADD MEMBER [func-candidates-api]
GRANT EXECUTE TO [func-candidates-api]

CREATE USER [func-candidates-api/slots/staging] FROM EXTERNAL PROVIDER

adm:Cb3253f!


CREATE USER [managed-function] FROM EXTERNAL PROVIDER
ALTER ROLE db_datareader ADD MEMBER [managed-function]
ALTER ROLE db_datawriter ADD MEMBER [managed-function]
GRANT EXECUTE TO [managed-function]

CREATE TABLE demo (ID int primary key, data nvarchar(255));