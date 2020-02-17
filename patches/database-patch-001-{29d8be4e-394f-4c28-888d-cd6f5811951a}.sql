SET @dbname = DATABASE();
SET @schemaname = "medalynx_db";
SET @tablename = "new_table";
SET @columnname = "c12";
SET @after = "c1";
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (table_name = @tablename)
      AND (table_schema = @dbname)
      AND (column_name = @columnname)
  ) > 0,
  "SELECT 1",
  CONCAT("ALTER TABLE ", @schemaname, ".", @tablename, " ADD ", @columnname, " VARCHAR(45) NULL AFTER ", @after, ";")
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;


... etc
