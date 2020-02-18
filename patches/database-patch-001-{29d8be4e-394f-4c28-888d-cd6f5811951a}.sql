SET @dbname = DATABASE();
SET @schemaname = "medalynx_db";

SET @tablename = "Cohorts";
SET @columnname = "State";
SET @after = "RequestUser";
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (table_name = @tablename)
      AND (table_schema = @dbname)
      AND (column_name = @columnname)
  ) > 0,
  "SELECT 1",
  CONCAT("ALTER TABLE ", @schemaname, ".", @tablename, " ADD ", @columnname, " INT NOT NULL DEFAULT 0 AFTER ", @after, ";")
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

SET @tablename = "Enviroments";
SET @columnname = "State";
SET @after = "Request";
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (table_name = @tablename)
      AND (table_schema = @dbname)
      AND (column_name = @columnname)
  ) > 0,
  "SELECT 1",
  CONCAT("ALTER TABLE ", @schemaname, ".", @tablename, " ADD ", @columnname, " INT NOT NULL DEFAULT 0 AFTER ", @after, ";")
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;
