CREATE TABLE medalynx_db.test_table ( f1 INT NOT NULL );

ALTER TABLE medalynx_db.test_table ADD f2 INT NOT NULL DEFAULT 0 AFTER f1;
