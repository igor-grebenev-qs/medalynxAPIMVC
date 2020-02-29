ALTER TABLE `medalynx_db2`.`Notifications` 
ADD COLUMN `Request` INT NULL DEFAULT 0 AFTER `Processing`,
CHANGE COLUMN `Status` `Status` INT(11) NULL DEFAULT 0 COMMENT 'Created = 0, Read = 1, Cancelld = 2\\n' ;